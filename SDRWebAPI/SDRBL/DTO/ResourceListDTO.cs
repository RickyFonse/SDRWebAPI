using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDRBL.DTO
{
    public class ResourceListDTO
    {
        public IEnumerable<FileDTO> TenantFiles{ get; set; }
        public IEnumerable<FileDTO> OwnerFiles { get; set; }
    }
}
