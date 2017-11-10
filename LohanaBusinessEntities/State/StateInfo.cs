using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.State
{
    public class StateInfo
    {

        public StateInfo()
        {
            
        }

        public int StateId { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }

        public bool IsActive { get; set; }

        //Country

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }


    }

   
}
