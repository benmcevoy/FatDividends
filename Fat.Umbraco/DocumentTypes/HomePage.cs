﻿using umbraco.cms.businesslogic.media;
using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType(AllowedChildNodeTypes = new[] { typeof(ContentPage), typeof(SearchPage), 
            typeof(StockDetail), typeof(InvestmentNewsPage), typeof(DividendDetail), typeof(EarningsDetail) }, 
        DefaultTemplate = typeof(masterpages.Home), IconUrl = "settingDomain.gif")]
    public class HomePage : Page
    {
        [DocumentTypeProperty(UmbracoPropertyType.MediaPicker, Mandatory = false, Tab = "Hero", Name = "Hero Image")]
        public int HeroImage { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = false, Tab = "Hero", Name = "Hero Caption")]
        public string HeroCaption { get; set; }

        public string HeroImageUrl
        {
            get
            {
                return HeroImage <= 0
                           ? string.Empty
                           : new Media(HeroImage).getProperty("umbracoFile").Value.ToString();
            }
        }

        public bool HasHero
        {
            get { return HeroImage > 0; }
        }
    }
}