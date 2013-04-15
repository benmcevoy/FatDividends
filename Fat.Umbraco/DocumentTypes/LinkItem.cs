using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType(IconUrl = "developerPython.gif")]
    public class LinkItem : Item
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = true, Tab = "Link")]
        public string Title { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.ContentPicker, Mandatory = false, Tab = "Link", Name = "Local Link Url", Description = "A local link will take precedence over an external link.")]
        public int LocalHref { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = false, Tab = "Link", Name = "External Link Url")]
        public string ExternalHref { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.TrueFalse, Mandatory = false, Tab = "Link", Name = "Open In New Window?")]
        public bool IsNewTarget { get; set; }

        public string RenderTitle
        {
            get { return string.IsNullOrEmpty(Title) ? Name : Title; }
        }

        public string Target
        {
            get { return IsNewTarget ? "target=_blank" : ""; }
        }

        public string EffectiveUrl
        {
            get { return LocalHref <= 0 ? ExternalHref : umbraco.library.NiceUrl(LocalHref); }
        }
    }
}