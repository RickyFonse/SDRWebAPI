using System.Collections.Generic;

namespace SDRBL.DTO
{
    public class PropertyListDataDTO
    {
        public class InstructorIndexData
        {
            public IEnumerable<PropertyDTO> Properties { get; set; }
            public IEnumerable<AddressDTO> Addresses { get; set; }
            public IEnumerable<StateDTO> States { get; set; }


        }
    }
}
