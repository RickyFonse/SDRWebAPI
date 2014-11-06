namespace SDRDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class File
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? FileTypeId { get; set; }

        public virtual FileType FileType { get; set; }
    }
}
