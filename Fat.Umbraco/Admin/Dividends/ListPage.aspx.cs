using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            Response.Redirect("CreateDividendPage.aspx");
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            using (var context = new FatDataContext())
            {
                var code = Request.QueryString["code"];
                var dividends = context.StockDividends.Where(
                    s => s.StockCode == code).ToList()
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
                        });

                // TODO: move to repository?
                var csv = dividends.ToCsv();

                csv = csv.Insert(0, "Code, Ex Date, Amount, Franked, Record Date, Payable Date, Franking Credit, Closing Price\r\n");

                // TODO: move to handler and reuse for all 
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + code + "_dividends.csv");
                Response.ContentType = "text/comma-separated-values";

                Response.Write(csv);
                Response.End();
            }
        }

        protected void Import_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportPage.aspx");
        }
    }
}