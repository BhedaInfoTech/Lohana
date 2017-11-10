using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.VehicleBrand
{
    public class VehicleBrandInfo
    {

        public VehicleBrandInfo()
        {
            
        }

        public int VehicleBrandId { get; set; }

        public string VehicleBrandName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }
}
