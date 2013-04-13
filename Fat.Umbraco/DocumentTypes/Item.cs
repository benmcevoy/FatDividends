using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType(AllowedChildNodeTypes = new[] { typeof(Item) }, IconUrl = "doc.gif")]
    public class Item :  DocumentTypeBase
    {
        
    }
}