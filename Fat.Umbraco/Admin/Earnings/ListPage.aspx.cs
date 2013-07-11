using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fat.Services.Models;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.Earnings
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

        }

        protected void Download_Click(object sender, EventArgs e)
        {

        }

        protected void Import_Click(object sender, EventArgs e)
        {

        }
    }
}