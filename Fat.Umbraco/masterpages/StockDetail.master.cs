using System;
using Vega.USiteBuilder;

namespace Fat.Umbraco.masterpages
{
    public partial class StockDetail : TemplateBase<DocumentTypes.StockDetail>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitle();
        }

        private void SetTitle()
        {
            var stock = Data.StockRepository.GetStock(null);

            if (stock != null)
            {
                TitleLiteral.Text = string.Format("{0} ({1})", stock.Name, stock.Code);
            }
        }
    }
}