using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Country
{
    public class CountryInfo
    {

        public CountryInfo()
        {
            
        }

        public int CountryId { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }
}
