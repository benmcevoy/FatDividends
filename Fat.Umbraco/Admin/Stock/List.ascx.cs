using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Fat.Services.Models;

namespace Fat.Umbraco.Admin.Stock
{
    public partial class List : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StocksEntityDataSource_OnContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            var db = new FatDataContext();
            e.Context = (db as IObjectContextAdapter).ObjectContext;
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stock/CreateStockPage.aspx");
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            using (var context = new FatDataContext())
            {
                IEnumerable<Services.Models.Stock> stocks;
                var filter = FilterTextBox.Text;

                if (string.IsNullOrWhiteSpace(filter))
                {
                    stocks = context.Stocks;
                }
                else
                {
                    stocks = context.Stocks.Where(
                           s => s.Code.StartsWith(FilterTextBox.Text)
                                || s.Name.StartsWith(FilterTextBox.Text));
                }

                // TODO: move to repository?
                var csv = stocks.Select(s => new
                    {
                        s.Code,
                        s.Name,
                        s.Industry,
                        Active = s.IsActive ? "active" : "inactive"
                    }).AsQueryable();

                DownloadHelper.DownloadAsCsv(Context, csv, "stock.csv");
            }
        }
    }
}