using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using SDRBL.DTO;
using SDRDAL;

namespace SDRBL.Handlers
{
    public class PropertyHandler : IDisposable
    {
        private SDRDbContext db = new SDRDbContext();

        public IEnumerable<PropertyListDataDTO> GetProperties()
        {
            var properties = (from p in db.Properties                               
                .Include(i => i.Addresses.Select(s => s.State))
                .Include(i => i.PropertyPics)
                .Where(i => i.Active)
                .OrderBy(i => i.Price)
                             select new PropertyListDataDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Phone = p.Phone,
                Beds = p.Beds,
                Baths = p.Baths,
                SqFt = p.SqFt,
                Active = p.Active,
                PropertyPicId = p.PropertyPics.FirstOrDefault().Id,//its ok just to grab the first pic, as i only want to show the first pic
                Address1 = p.Addresses.FirstOrDefault().Address1,//just for studying purposes... Addresses should not be a list if there is only one address 
                Address2 = p.Addresses.FirstOrDefault().Address2,
                City = p.Addresses.FirstOrDefault().City,
                PostalCode = p.Addresses.FirstOrDefault().PostalCode,
                State = p.Addresses.FirstOrDefault().State.name
            }).ToList();

            return properties;           
        }

        //#region GetPropertiesWithRelatedObjects
        //public IEnumerable<PropertyDTO> GetPropertiesWithRelatedObjects()
        //{
        //    //var properties = from p in db.Properties
        //    var properties = db.Properties
        //        .Include(i => i.Addresses.Select(s => s.State))
        //        .Include(i => i.PropertyPics)
        //        .Where(i => i.Active)
        //        .OrderBy(i => i.Price);


        //    var propertyDTOList = new List<PropertyDTO>();

        //    var propertyPicDTOList = new List<PropertyPicDTO>();

        //    //for each navigation collection you will have to do this
        //    foreach (var property in properties)
        //    {
        //        var propertyDTO = new PropertyDTO
        //        {
        //            Id = property.Id,
        //            Name = property.Name,
        //            Price = property.Price,
        //            Phone = property.Phone,
        //            Beds = property.Beds,
        //            Baths = property.Baths,
        //            SqFt = property.SqFt,
        //            Active = property.Active,
        //        };


        //        foreach (var propertyPic in property.PropertyPics)
        //        {
        //            var propertyPicDTO = new PropertyPicDTO
        //            {
        //                Id = propertyPic.Id,
        //                Name = propertyPic.Name,
        //                PropertyId = propertyPic.PropertyId
        //            };
        //            propertyPicDTOList.Add(propertyPicDTO);
        //        }
        //        propertyDTO.PropertyPics = propertyPicDTOList;
        //        //for each navigation collection you will have to do this


        //        propertyDTOList.Add(propertyDTO);
        //    }

        //    return propertyDTOList;
        //}
        //#endregion
        #region Dispose Region
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion
    }
}
