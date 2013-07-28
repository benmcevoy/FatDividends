using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.UI.WebControls;
using Fat.Services.Models;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.Dividends
{
    public partial class ListPage : UmbracoEnsuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StockCodeLabel.Text = Request.QueryString["name"];
        }

        protected void StocksEntityDataSource_OnContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            var db = new FatDataContext();
            e.Context = (db as IObjectContextAdapter).ObjectContext;
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateDividendPage.aspx?code=" + Request.QueryString["code"] + "&name=" + Request.QueryString["name"]);
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            using (var context = new FatDataContext())
            {
                var code = Request.QueryString["code"];
                var dividends = context.StockDividends.Where(
                    s => s.StockCode == code)
                    .Select(d => new
                        {
                            d.StockCode,
                            d.FormattedExDate,
                            d.Amount,
                            d.Franked,
                            d.FormattedRecordDate,
                            d.FormattedPayableDate,
                            d.FrankingCredit,
                            d.ClosingPrice
                        }).AsQueryable();

                DownloadHelper.DownloadAsCsv(Context, dividends,  code + "_dividends.csv");
            }
        }

        protected void Import_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportPage.aspx");
        }
    }
}