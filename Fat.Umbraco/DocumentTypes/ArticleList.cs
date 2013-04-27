﻿using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType(DefaultTemplate = typeof(masterpages.ArticleList), IconUrl = "folder_table.png")]
    public class ArticleList : Page
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring, Mandatory = true, Tab = "Content")]
        public string Tag { get; set; }
    }
}