using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Fat.Import.Data
{
    public class CsvMapper
    {
        // TOOD: should use stream to avoid memory hit and increase speed
        // http://www.codeproject.com/Articles/9258/A-Fast-CSV-Reader
        // handle more delimiters - not really csv then is it? | tab etc
        // handle identifers (e.g. "sdfdf,sdff" is a value)
        // handle more types
        // handle "single line" csv, ala google docs  has values like "col1","col2\nand more"\n"next line","col2"

        private bool _concatenateNextRow;
        private string _value;

        /// <summary>
        /// Map CSV records to an object
        /// </summary>
        /// <typeparam name="T">The type to map</typeparam>
        /// <param name="mapping">A map of Property names to the CSV column ordinal</param>
        /// <param name="csv">The raw CSV</param>
        /// <param name="skipFirstRow"></param>
        /// <param name="lineDelimiter"></param>
        /// <returns></returns>
        public IEnumerable<T> MapCsvTo<T>(Dictionary<string, int> mapping, string csv, bool skipFirstRow = false, string lineDelimiter = "\r\n")
            where T : new()
        {
            var properties = new T().GetType().GetProperties();
            var propertyMap = GetPropertyMap(properties);
            var results = new List<T>();
            var records = Regex.Split(csv, lineDelimiter);
            var columns = new List<string>();

            foreach (var row in records)
            {
                if (skipFirstRow)
                {
                    skipFirstRow = false;
                    continue;
                }

                if (string.IsNullOrEmpty(row.Trim()))  continue; 

                if (_concatenateNextRow)
                {
                    columns.AddRange(ParseRow(row));
                }
                else
                {
                    columns = ParseRow(row);
                }

                if (columns.Count == 0)continue;
                if (_concatenateNextRow) continue;

                var item = new T();

                foreach (var map in mapping)
                {
                    var property = propertyMap[map.Key];
                    property.SetValue(item, ConvertToType(property.PropertyType, columns[map.Value]), null);
                }

                results.Add(item);
            }

            return results;
        }

        private List<string> ParseRow(string row)
        {
            var results = new List<string>();
            var position = 0;

            while (position < row.Length)
            {
                if (!_concatenateNextRow)
                {
                    _value = "";
                }

                // Special handling for quoted field
                if (row[position] == '"' || _concatenateNextRow)
                {
                    // Skip initial quote unless we are concatenting to the previous row
                    if (!_concatenateNextRow)
                    {
                        position++;
                    }

                    // Parse quoted value
                    var start = position;
                    var isEndFound = false;

                    while (position < row.Length)
                    {
                        // Test for quote character
                        if (row[position] == '"')
                        {
                            // Found one
                            position++;

                            // If two quotes together, keep one
                            // Otherwise, indicates end of value
                            if (position >= row.Length || row[position] != '"')
                            {
                                isEndFound = true;
                                position--;
                                break;
                            }
                        }
                        position++;
                    }

                    if (isEndFound)
                    {
                        _value += row.Substring(start, position - start);
                        _value = _value.Replace("\"\"", "\"");
                        _concatenateNextRow = false;
                    }
                    else
                    {
                        _value += row.Substring(start, position - start);
                        _value += Environment.NewLine;
                        _concatenateNextRow = true;
                    }
                }
                else
                {
                    // Parse unquoted value
                    var start = position;

                    while (position < row.Length && row[position] != ',')
                    {
                        position++;
                    }

                    _value += row.Substring(start, position - start);
                }

                results.Add(_value);

                // Eat up to and including next comma
                while (position < row.Length && row[position] != ',')
                {
                    position++;
                }
                if (position < row.Length)
                {
                    position++;
                }
            }

            return results;
        }

        private object ConvertToType(Type type, string value)
        {
            switch (type.Name)
            {
                case "String":
                    return value;

                case "Int32":
                    value = value.Replace("%", "").Replace(",", "").Replace("$", "");
                    return Convert.ToInt32(value);

                case "Double":
                    value = value.Replace("%", "").Replace(",", "").Replace("$", "");
                    return Convert.ToDouble(value);

                case "Decimal":
                    value = value.Replace("%", "").Replace(",", "").Replace("$", "");
                    return Convert.ToDecimal(value);

                case "DateTime":
                    return DateTime.Parse(value);
                //// Monday, July  2, 2012 00:38:41 UTC
            }

            return value;
        }

        private Dictionary<string, PropertyInfo> GetPropertyMap(IEnumerable<PropertyInfo> properties)
        {
            return properties.ToDictionary(property => property.Name);
        }
    }
}