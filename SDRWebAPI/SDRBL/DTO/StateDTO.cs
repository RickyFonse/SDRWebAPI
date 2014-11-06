using System.Collections.Generic;

namespace SDRBL.DTO
{
    public class StateDTO
    {
        public StateDTO()
        {
            Addresses = new HashSet<AddressDTO>();
        }

        public int Id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public  ICollection<AddressDTO> Addresses { get; set; }
    }
}
