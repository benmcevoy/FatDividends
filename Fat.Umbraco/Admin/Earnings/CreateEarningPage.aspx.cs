using System;
using Fat.Services.Models;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.Earnings
{
    public partial class CreateEarningPage : UmbracoEnsuredPage
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
                var reportedDate = ReportedDateTextBox.Text.ToDate();
                var existingEarning = context.StockEarnings.Find(code, reportedDate);

                if (existingEarning != null)
                {
                    SetMessage("Earning already exists for this stock and reported date.");
                    return;
                }

                var newEarning = context.StockEarnings.Create();

                newEarning.StockCode = code;
                newEarning.CreatedUtcDate = DateTime.UtcNow;
                newEarning.ReportedDate = ReportedDateTextBox.Text.ToDate().Value;
                newEarning.Year = YearTextBox.Text;
                newEarning.Period = PeriodTextBox.Text;
                newEarning.NPAT = NPATTextBox.Text.ToDecimal();
                newEarning.Margin = MarginTextBox.Text;
                newEarning.CashFlow = CashFlowTextBox.Text;
                newEarning.EPS = EPSTextBox.Text.ToDecimal();
                newEarning.DPS = DPSTextBox.Text.ToDecimal();
                newEarning.ROE = ROETextBox.Text.ToDecimal();

                Fat.Import.EarningsCalendarImporter.Import(newEarning);

                SetMessage("Earning created.");

                ReportedDateTextBox.Text = "";
                YearTextBox.Text = "";
                PeriodTextBox.Text = "";
                NPATTextBox.Text = "";
                MarginTextBox.Text = "";
                CashFlowTextBox.Text = "";
                EPSTextBox.Text = "";
                DPSTextBox.Text = "";
                ROETextBox.Text = "";
            }
        }
    }
}