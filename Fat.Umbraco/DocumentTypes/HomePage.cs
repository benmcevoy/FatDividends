using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    public class HomePage : Page
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = false, Tab = "Hero")]
        public string HeroCaption { get; set; }
    }
}