using DepoAPI.DesignPatterns.SingletonPattern;
using DepoAPI.DTOClasses;
using DepoAPI.Models.Context;
using DepoAPI.Models.Entities;
using DepoAPI.Tools;
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
        public IHttpActionResult AddStocks(List<StockDTO> item)
        {
            foreach (StockDTO element in item)
            {
                if (element.ID <= 0 || element.ProductName == null || element.UnitPrice <= 0 || element.UnitInStock <= 0)
                    return BadRequest("Mandatory fields cannot be null");
            }

            _db.Storages.AddRange(item.Select(x => new Storage
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitInStock = x.UnitInStock
            }).ToList());

            _db.SaveChanges();
            return Ok();

            
            //if(item.ID > 0 && item.ProductName != null && item.UnitInStock > 0 && item.UnitPrice > 0)
            //{
            //    Storage product = new Storage
            //    {
            //        ID = item.ID,
            //        ProductName = item.ProductName,
            //        UnitInStock = item.UnitInStock,
            //        UnitPrice = item.UnitPrice
            //    };

            //    _db.Storages.Add(product);
            //    _db.SaveChanges();

            //    return Ok();
            //}
            //return BadRequest("Mandatory fields cannot be null");
        }

        public IHttpActionResult StockDrop(List<StockDropDTO> item)
        {
            foreach (StockDropDTO element in item)
            {
                if (element.ID <= 0 || element.Quantity <= 0)
                    return BadRequest("Mandatory fields cannot be null");
            }

            foreach (StockDropDTO element in item)
            {
                Storage toBeUpdated = _db.Storages.Find(element.ID);
                if (toBeUpdated.UnitInStock <= 0) return BadRequest("No stock"); //Satın alınacak ürünün stoğu yoksa, engellenir
                toBeUpdated.UnitInStock -= element.Quantity;
                if (toBeUpdated.UnitInStock < 0) return BadRequest("Insufficient stock"); //Satın alınacak miktarda stok yoksa, engellenir
                else if (toBeUpdated.UnitInStock <= 5)
                {
                    //Burada receiver'a depo sorumlusunun mail'i girilmelidir
                    //Stoklar azalınca sorumluya mail atılır
                    MailService.Send(subject: "Depo'dan mesaj var!", body: $"{toBeUpdated.ProductName} ürününün stoğu azalmıştır, lütfen stokları güncelleyiniz", receiver: "tugberkmehdioglu@yandex.com");
                }
            }
            _db.SaveChanges();
            return Ok();
        }
    }
}
