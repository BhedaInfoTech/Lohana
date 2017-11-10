using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.FacilityType
{
    public class FacilityTypeInfo
    {

        public FacilityTypeInfo()
        {

        }

        public int FacilityTypeId { get; set; }

        public string FacilityTypeName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public bool IsActive { get; set; }

    }

}
