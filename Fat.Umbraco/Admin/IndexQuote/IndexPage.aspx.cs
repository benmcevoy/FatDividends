using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fat.Services;
using Fat.Services.Models;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.IndexQuote
{
    public partial class IndexPage : UmbracoEnsuredPage
    {
        private readonly IndexQuoteService _indexQuoteService = new IndexQuoteService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Download_Click(object sender, EventArgs e)
        {
            int quotesToShow = 30;

            int.TryParse(QuotesToShow.Value, out quotesToShow);

            var quotes = _indexQuoteService.Get(quotesToShow).Select(q =>
                new
                {
                    Date = q.ClosingDate.ToString("dd MMM"),
                    ClosingPrice = q.Price
                }).OrderByDescending(x => x.Date).AsQueryable();

            DownloadHelper.DownloadAsCsv(Context, quotes, "asx_quotes.csv");
        }
    }
}