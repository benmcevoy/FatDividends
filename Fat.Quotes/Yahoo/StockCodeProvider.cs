using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaasOne.Base;
using MaasOne.Finance.YahooFinance;

namespace Fat.Quotes.Yahoo
{
    public class StockCodeProvider : IStockCodeProvider
    {
        public string Search(string value)
        {
            var dl = new IDSearchDownload();
            
            var resp = dl.Download(value);

            //Response/Result
            if (resp.Connection.State == ConnectionState.Success)
            {
                foreach (var res in resp.Result.Items)
                {
                    string id = res.ID;
                    string name = res.Name;
                    var type = res.Type;
                    string exchange = res.Exchange;
                    
                }
            }

            return "???";
        }
    }
}
