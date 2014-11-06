using System.Collections.Generic;

namespace SDRBL.DTO
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Phone { get; set; }
        public short? Beds { get; set; }
        public short? Baths { get; set; }
        public short? SqFt { get; set; }
        public bool Active { get; set; }
        public ICollection<AddressDTO> Addresses { get; set; }
        public ICollection<PropertyPicDTO> PropertyPics { get; set; }
    }
}
