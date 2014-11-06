using System.Collections.Generic;

namespace SDRBL.DTO
{
    public class PropertyListDataDTO
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

            //PropertPic Info
            public int? PropertyPicId { get; set; }            


            //Address Info          
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }          
            public string PostalCode { get; set; }
            

            //State Info
            public string State { get; set; }
                
    }
}
