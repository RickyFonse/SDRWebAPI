namespace SDRDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class State
    {
        public State()
        {
            Addresses = new HashSet<Address>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string abbreviation { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? sort { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string occupied { get; set; }

        [StringLength(255)]
        public string notes { get; set; }

        [StringLength(255)]
        public string fips_state { get; set; }

        [StringLength(255)]
        public string assoc_press { get; set; }

        [StringLength(255)]
        public string standard_federal_region { get; set; }

        [StringLength(255)]
        public string census_region { get; set; }

        [StringLength(255)]
        public string census_region_name { get; set; }

        [StringLength(255)]
        public string census_division { get; set; }

        [StringLength(255)]
        public string census_division_name { get; set; }

        [StringLength(255)]
        public string circuit_court { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
