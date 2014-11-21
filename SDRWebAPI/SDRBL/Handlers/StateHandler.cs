using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDRBL.DTO;
using SDRDAL;

namespace SDRBL.Handlers
{
    public class StateHandler
    {
        private SDRDbContext db = new SDRDbContext();

        public IEnumerable<StateDTO> GetStates()
        {

            var states = (from s in db.States
                          orderby s.name
                          select new StateDTO()
             {
                 Id = s.Id,
                 name = s.name,
                 abbreviation = s.abbreviation
             }).ToList();

            return states;
        }

        #region Dispose Region
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
