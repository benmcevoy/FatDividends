using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    #warning "allowed child nodes does not seem to work in v6. set it manually"
    [DocumentType(AllowedChildNodeTypes = new[] { typeof(Folder), typeof(Item) })]
    public class Folder : Item
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = true, Tab = "Folder")]
        public string Title { get; set; }
    }
}