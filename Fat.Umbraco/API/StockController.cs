using Fat.Services.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fat.Umbraco.API
{
    public class StockController : ApiController
    {
        private readonly Entities _context;

        public StockController()
        {
            _context = new Entities();
        }

        // GET api/Stock
        /// <summary>
        /// Get all stock information
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> GetStocks()
        {
            return _context.Stocks.AsEnumerable();
        }

        // GET api/Stock/5
        /// <summary>
        /// Get stock information for the given stockCode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stock GetStock(string id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return stock;
        }

        //// PUT api/Stock/5
        //public HttpResponseMessage PutStock(string id, Stock stock)
        //{
        //    if (ModelState.IsValid && id == stock.Code)
        //    {
        //        _context.Entry(stock).State = EntityState.Modified;

        //        try
        //        {
        //            _context.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        //// POST api/Stock
        //public HttpResponseMessage PostStock(Stock stock)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Stocks.Add(stock);
        //        _context.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, stock);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = stock.Code }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        //// DELETE api/Stock/5
        //public HttpResponseMessage DeleteStock(string id)
        //{
        //    Stock stock = _context.Stocks.Find(id);
        //    if (stock == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    _context.Stocks.Remove(stock);

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, stock);
        //}

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}