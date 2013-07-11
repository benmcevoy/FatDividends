using System;
using Fat.Services.Models;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.Stock
{
    public partial class CreateStockPage : UmbracoEnsuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearMessage();
        }

        private void ClearMessage()
        {
            MessagePlaceHolder.Visible = false;
            MessageLabel.Text = "";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomePage.aspx");
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            using (var context = new FatDataContext())
            {
                var code = CodeTextBox.Text;
                var existingStock = context.Stocks.Find(code);

                if (existingStock != null)
                {
                    SetMessage("Stock {0} already exists.", code);
                    return;
                }

                var newStock = context.Stocks.Create();

                newStock.Code = code;
                newStock.CreatedUtcDate = DateTime.UtcNow;
                newStock.Industry = IndustryTextBox.Text;
                newStock.IsActive = true;
                newStock.Name = NameTextBox.Text;

                context.Stocks.Add(newStock);
                context.SaveChanges();

                SetMessage("Stock {0} created.", code);

                CodeTextBox.Text = "";
                IndustryTextBox.Text = "";
                NameTextBox.Text = "";
            }
        }

        private void SetMessage(string message, params object[] values)
        {
            MessagePlaceHolder.Visible = true;
            MessageLabel.Text = string.Format(message, values);
        }
    }
}