using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDRBL.DTO;
using SDRDAL;

namespace SDRBL.Handlers
{
    public class FileHandler : IDisposable
    {
        private SDRDbContext db = new SDRDbContext();

        public ResourceListDTO GetResourceList()
        {
            var resourceListDTO = new ResourceListDTO();
            var tenantFiles = new List<FileDTO>();
            var ownerFiles = new List<FileDTO>();


            var files = from f in db.Files
                where f.FileTypeId == 1 || f.FileTypeId == 2    //resourceFileIds     
                orderby f.FileTypeId
                select f;

            foreach (var file in files)
            {
                if (file.FileTypeId == 1)
                {
                    var tenantFileDTO = new FileDTO()
                    {
                        Id = file.Id,
                        Name = file.Name,
                    };

                    tenantFiles.Add(tenantFileDTO);
                }
                else
                {
                    var ownerFileDTO = new FileDTO()
                    {
                        Id = file.Id,
                        Name = file.Name,
                    };

                    ownerFiles.Add(ownerFileDTO);
                }                               
            }

            if(files.Any())
            {
                resourceListDTO.TenantFiles = tenantFiles;
                resourceListDTO.OwnerFiles = ownerFiles;
            }
            return resourceListDTO;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
