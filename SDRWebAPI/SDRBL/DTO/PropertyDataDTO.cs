using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRBL.DTO
{
    public class PropertyDataDTO
    {
        //Property Info
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Phone { get; set; }
        public short? Beds { get; set; }
        public short? Baths { get; set; }
        public short? SqFt { get; set; }
        public bool Active { get; set; }


        //Address Info          
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }


        //State Info
        public int StateId { get; set; } 
    }
}
