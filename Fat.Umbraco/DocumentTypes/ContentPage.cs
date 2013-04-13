using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    #warning "allowed child nodes does not seem to work in v6. set it manually"
    [DocumentType(AllowedChildNodeTypes = new[] { typeof(ContentPage) }, DefaultTemplate = typeof(masterpages.Content), IconUrl = "doc4.gif")]
    public class ContentPage : Page
    {
    }
}