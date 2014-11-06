namespace SDRDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PropertyPic
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
