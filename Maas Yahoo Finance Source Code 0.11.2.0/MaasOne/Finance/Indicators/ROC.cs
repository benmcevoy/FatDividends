// ******************************************************************************
// ** 
// **  MaasOne WebServices
// **  Written by Marius H�usler 2012
// **  It would be pleasant, if you contact me when you are using this code.
// **  Contact: YahooFinanceManaged@gmail.com
// **  Project Home: http://code.google.com/p/yahoo-finance-managed/
// **  
// ******************************************************************************
// **  
// **  Copyright 2012 Marius H�usler
// **  
// **  Licensed under the Apache License, Version 2.0 (the "License");
// **  you may not use this file except in compliance with the License.
// **  You may obtain a copy of the License at
// **  
// **    http://www.apache.org/licenses/LICENSE-2.0
// **  
// **  Unless required by applicable law or agreed to in writing, software
// **  distributed under the License is distributed on an "AS IS" BASIS,
// **  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// **  See the License for the specific language governing permissions and
// **  limitations under the License.
// ** 
// ******************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;


namespace MaasOne.Finance.Indicators
{


    public class ROC : ISingleValueIndicator
    {


        public string Name { get { return "Rate of Change"; } }
        public bool IsRealative { get { return true; } }
        public double ScaleMaximum { get { return 100; } }
        public double ScaleMinimum { get { return -100; } }
        public int Period { get; set; }

        public ROC()
        {
            this.Period = 12;
        }

        public Dictionary<System.DateTime, double>[] Calculate(IEnumerable<KeyValuePair<System.DateTime, double>> values)
        {
            Dictionary<System.DateTime, double> rocResult = new Dictionary<System.DateTime, double>();

            List<KeyValuePair<System.DateTime, double>> quoteValues = new List<KeyValuePair<System.DateTime, double>>(values);
            quoteValues.Sort(new QuotesSorter());

            if (quoteValues.Count > 0)
            {
                for (int i = 0; i <= quoteValues.Count - 1; i++)
                {
                    if (i >= this.Period)
                    {
                        rocResult.Add(quoteValues[i].Key, ((quoteValues[i].Value - quoteValues[i - this.Period].Value) / quoteValues[i - this.Period].Value) * 100);
                    }
                    else
                    {
                        rocResult.Add(quoteValues[i].Key, ((quoteValues[i].Value - quoteValues[0].Value) / quoteValues[0].Value) * 100);
                    }
                }
            }

            return new Dictionary<System.DateTime, double>[] { rocResult };
        }

        public override string ToString()
        {
            return this.Name + " " + this.Period;
        }
    }

}
