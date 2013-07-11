using System;
using Fat.Services.Models;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.Dividends
{
    public partial class CreateDividendPage : UmbracoEnsuredPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StockCodeLabel.Text = Request.QueryString["name"];
            ClearMessage();
        }

        private void ClearMessage()
        {
            MessagePlaceHolder.Visible = false;
            MessageLabel.Text = "";
        }

        private void SetMessage(string message, params object[] values)
        {
            MessagePlaceHolder.Visible = true;
            MessageLabel.Text = string.Format(message, values);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPage.aspx?code=" + Request.QueryString["code"] + "&name=" + Request.QueryString["name"]);
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            using (var context = new FatDataContext())
            {
                var code = Request.QueryString["code"];
                var exDate = ExDateTextBox.Text.ToDate();
                var existingDividend = context.StockDividends.Find(code, exDate);

                if (existingDividend != null)
                {
                    SetMessage("Dividend already exists for this stock and ex date.");
                    return;
                }

                var newDividend = context.StockDividends.Create();
                
                newDividend.StockCode = code;
                newDividend.CreatedUtcDate = DateTime.UtcNow;
                newDividend.Amount = AmountTextBox.Text.ToDecimal();
                newDividend.ExDate = exDate.Value;
                newDividend.Franked = FrankedTextBox.Text.ToDecimal();
                newDividend.FrankingCredit = FrankingCreditTextBox.Text.ToDecimal();
                newDividend.PayableDate = PayableDateTextBox.Text.ToDate().Value;
                newDividend.RecordDate = RecordDateTextBox.Text.ToDate();

                Fat.Import.DividendCalendarImporter.Import(newDividend);

                SetMessage("Dividend created.");

                ExDateTextBox.Text = "";
                AmountTextBox.Text = "";
                FrankedTextBox.Text = "";
                FrankingCreditTextBox.Text = "";
                RecordDateTextBox.Text = "";
                PayableDateTextBox.Text = "";
            }
        }
    }
}