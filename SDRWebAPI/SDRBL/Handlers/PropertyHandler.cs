using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using SDRBL.DTO;
using SDRDAL;

namespace SDRBL.Handlers
{
    public class PropertyHandler:IDisposable
    {
        private SDRDbContext db = new SDRDbContext();

        public IEnumerable<PropertyDTO> GetProperties()
        {

            var properties = from p in db.Properties
                .Include(i => i.Addresses.Select(s => s.StateId))
                .Include(i => i.PropertyPics.Select(c => c.PropertyId))
                .Where(i => i.Active)
                .OrderBy(i => i.Price)
                select new PropertyDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Phone = p.Phone,
                    Beds = p.Beds,
                    Baths = p.Baths,
                    SqFt = p.SqFt,
                    Active = p.Active
                };
               
                

             //foreach (var property in properties)
             //{
             //    //Console.WriteLine("Name: {0}", order.LastName);
             //    foreach (var orderInfo in property.PropertyPics)
             //    {
             //        //Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}",
             //           // orderInfo.SalesOrderID, orderInfo.OrderDate, orderInfo.TotalDue);
             //    }
             //    //Console.WriteLine("");
             //}

            return properties;
        }

       
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
