using DepoAPI.DesignPatterns.SingletonPattern;
using DepoAPI.DTOClasses;
using DepoAPI.Models.Context;
using DepoAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DepoAPI.Controllers
{
    public class HomeController : ApiController
    {
        MyContext _db;
        public HomeController()
        {
            _db = DBTool.DBInstance;
        }

        [HttpPost]
        public IHttpActionResult StockControl(StockDTO item)
        {
            if(item.ID > 0 && item.ProductName != null && item.UnitInStock > 0 && item.UnitPrice > 0)
            {
                Storage product = new Storage
                {
                    ID = item.ID,
                    ProductName = item.ProductName,
                    UnitInStock = item.UnitInStock,
                    UnitPrice = item.UnitPrice
                };

                _db.Storages.Add(product);
                _db.SaveChanges();

                return Ok();
            }
            return BadRequest("Mandatory fields cannot be null");
        }
    }
}
