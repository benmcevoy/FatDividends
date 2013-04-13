using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vega.USiteBuilder;

namespace Fat.Umbraco.DocumentTypes
{
    [DocumentType( DefaultTemplate = typeof(masterpages.StockDetail), IconUrl = "doc4.gif")]
    public class StockDetail : Page
    {
    }
}