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
            //var properties = from p in db.Properties
            var properties = db.Properties
                .Include(i => i.Addresses.Select(s => s.State))
                .Include(i => i.PropertyPics)
                .Where(i => i.Active)
                .OrderBy(i => i.Price);
                
                //             select new PropertyDTO
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    Price = p.Price,
                //    Phone = p.Phone,
                //    Beds = p.Beds,
                //    Baths = p.Baths,
                //    SqFt = p.SqFt,
                //    Active = p.Active
                //};


            //ICollection<PropertyDTO> propertyDTOList = new ICollection<PropertyDTO>();
            var propertyDTOList = new List<PropertyDTO>();

            var propertyPicDTOList = new List<PropertyPicDTO>() ;

            foreach (var property in properties)
            {
                var propertyDTO = new PropertyDTO
                {
                    Id = property.Id,
                    Name = property.Name,
                    Price = property.Price,
                    Phone = property.Phone,
                    Beds = property.Beds,
                    Baths = property.Baths,
                    SqFt = property.SqFt,
                    Active = property.Active,
                };

                //for each navigation collection you will have to do this
            //    if (property.PropertyPics.Count == 0)
            //{
                foreach (var propertyPic in property.PropertyPics)
                {
                    var propertyPicDTO = new PropertyPicDTO
                    {
                        Id = propertyPic.Id,
                        Name = propertyPic.Name,
                        PropertyId = propertyPic.PropertyId
                    };
                     propertyPicDTOList.Add(propertyPicDTO);
                }
                propertyDTO.PropertyPics = propertyPicDTOList;
                //for each navigation collection you will have to do this


                propertyDTOList.Add(propertyDTO);
            }

            return propertyDTOList;
        }

       

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
