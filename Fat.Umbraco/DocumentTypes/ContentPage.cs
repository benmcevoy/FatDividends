using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType(AllowedChildNodeTypes = new[] { typeof(ContentPage) }, DefaultTemplate = typeof(masterpages.Content), IconUrl = "doc4.gif")]
    public class ContentPage : Page
    {
    }
}