using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fat.Services.Models;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.Stock
{
    public partial class CreateStockPage : UmbracoEnsuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomePage.aspx");
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomePage.aspx");
        }
    }
}