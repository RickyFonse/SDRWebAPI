namespace SDRDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Property
    {
        public Property()
        {
            Addresses = new HashSet<Address>();
            PropertyPics = new HashSet<PropertyPic>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? Price { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public short? Beds { get; set; }

        public short? Baths { get; set; }

        public short? SqFt { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<PropertyPic> PropertyPics { get; set; }
    }
}
