using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType(IconUrl = "settingLanguage.gif")]
    public class StockSummaryItem : Item
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = true, Tab = "Summary", Name = "ASX Stock Code")]
        public string StockCode { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RichtextEditor, Mandatory = true, Tab = "Summary", Name = "Stock Summary")]
        public string Summary { get; set; }
    }
}