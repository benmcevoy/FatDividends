using System.Configuration;

namespace Fat.Umbraco
{
    public class FatConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("mainNavigationStartNodeId", IsRequired = true)]
        public int MainNavigationStartNodeId
        {
            get { return (int)this["mainNavigationStartNodeId"]; }
            set { this["mainNavigationStartNodeId"] = value; }
        }

        [ConfigurationProperty("homeNodeId", IsRequired = true)]
        public int HomeNodeId
        {
            get { return (int)this["homeNodeId"]; }
            set { this["homeNodeId"] = value; }
        }

        [ConfigurationProperty("defaultStockSummaryNodeId", IsRequired = true)]
        public int DefaultStockSummaryNodeId
        {
            get { return (int)this["defaultStockSummaryNodeId"]; }
            set { this["defaultStockSummaryNodeId"] = value; }
        }

        public string Get(string key)
        {
            return this[key].ToString();
        }
    }
}