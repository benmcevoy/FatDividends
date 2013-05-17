using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fat.Services.Models;

namespace Fat.Umbraco.usercontrols.FatDividends.Stock
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
            int i = 0;
        }
    }
}