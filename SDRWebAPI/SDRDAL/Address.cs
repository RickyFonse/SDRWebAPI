namespace SDRDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Address1 { get; set; }

        [StringLength(120)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        public int StateId { get; set; }

        [Required]
        [StringLength(16)]
        public string PostalCode { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public virtual State State { get; set; }
    }
}
