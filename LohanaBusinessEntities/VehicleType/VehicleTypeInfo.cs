using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.VehicleType
{
    public class VehicleTypeInfo
    {

        public VehicleTypeInfo()
        {
            
        }

        public int VehicleTypeId { get; set; }

        public string VehicleTypeName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }
}
