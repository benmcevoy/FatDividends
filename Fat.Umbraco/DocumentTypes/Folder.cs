using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    #warning "allowed child nodes does not seem to work in v6. set it manually"
    [DocumentType(AllowedChildNodeTypes = new[] { typeof(Folder), typeof(Item), typeof(StockSummaryItem) })]
    public class Folder : Item
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = false, Tab = "Folder")]
        public string Title { get; set; }
    }
}