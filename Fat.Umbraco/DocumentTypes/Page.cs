using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType]
    public class Page : DocumentTypeBase
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = true, Tab = "Content")]
        public string Title { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.TextboxMultiple, Mandatory = false, Tab = "Content")]
        public string Description { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = false, Tab = "Content")]
        public string Keywords { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.RichtextEditor, Mandatory = false, Tab = "Content")]
        public string Content { get; set; }
    }
}