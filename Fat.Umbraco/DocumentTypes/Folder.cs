using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType(AllowedChildNodeTypes = new[] { typeof(Folder), typeof(Item), typeof(StockSummaryItem) })]
    public class Folder : Item
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = false, Tab = "Folder")]
        public string Title { get; set; }
    }
}