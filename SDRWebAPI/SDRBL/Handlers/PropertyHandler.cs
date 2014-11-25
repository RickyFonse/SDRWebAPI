using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
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

        public PropertyDataDTO GetProperty(int id)
        {
            var property = (from p in db.Properties
                .Include(i => i.Addresses.Select(s => s.State))
                .Where(i => i.Id == id)
                            select new PropertyDataDTO
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price,
                                Phone = p.Phone,
                                Beds = p.Beds,
                                Baths = p.Baths,
                                SqFt = p.SqFt,
                                Active = p.Active,
                                Address1 = p.Addresses.FirstOrDefault().Address1,//just for studying purposes... Addresses should not be a list if there is only one address 
                                Address2 = p.Addresses.FirstOrDefault().Address2,
                                City = p.Addresses.FirstOrDefault().City,
                                PostalCode = p.Addresses.FirstOrDefault().PostalCode,
                                StateId = p.Addresses.FirstOrDefault().StateId
                            }).FirstOrDefault();

            return property;
        }

        public async Task<bool> SaveProperty(PropertyDataDTO propertyData)        
        {
            if (propertyData.Address1 != null)
            {
                var property = new Property
                {
                    Id = propertyData.Id,
                    Name = propertyData.Name,
                    Price = propertyData.Price,
                    Phone = propertyData.Phone,
                    Beds = propertyData.Beds,
                    Baths = propertyData.Baths,
                    SqFt = propertyData.SqFt,
                    Active = propertyData.Active,
                };


                if (!String.IsNullOrWhiteSpace(propertyData.Address1))
                {
                    var address = new Address()
                    {
                        Address1 = propertyData.Address1,
                        Address2 = propertyData.Address2,
                        City = propertyData.City,
                        PostalCode = propertyData.PostalCode,
                        StateId = propertyData.StateId
                    };

                    property.Addresses.Add(address);
                }


                db.Properties.Add(property);

                await db.SaveChangesAsync();                
            }
            return true;//need to properly handle when no data is coming in...dont want to return true all the time..just for study purposes ;)
            
        }
        #region GetPropertiesWithRelatedObjects
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
        #endregion

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
