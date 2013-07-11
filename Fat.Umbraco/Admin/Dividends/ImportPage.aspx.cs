using System;
using System.IO;
using umbraco.BasePages;

namespace Fat.Umbraco.Admin.Dividends
{
    public partial class ImportPage : UmbracoEnsuredPage
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

        private void SetMessage(string message, params object[] values)
        {
            MessagePlaceHolder.Visible = true;
            MessageLabel.Text = string.Format(message, values);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomePage.aspx");
        }

        protected void Import_Click(object sender, EventArgs e)
        {
            if (!DividendFileUpload.HasFile) return;

            if (!DividendFileUpload.FileName.EndsWith(".csv"))
            {
                SetMessage("File must be a csv");
                return;
            }

            try
            {
                using (var stream = new MemoryStream(DividendFileUpload.FileBytes))
                {
                    var reader = new StreamReader(stream);
                    var csv = reader.ReadToEnd();

                    Fat.Import.DividendCalendarImporter.Import(csv);
                }

                SetMessage("Dividends imported successfully");
            }
            catch (Exception ex)
            {
                SetMessage("Shiiiit: {0}", ex.Message);
            }
        }
    }
}