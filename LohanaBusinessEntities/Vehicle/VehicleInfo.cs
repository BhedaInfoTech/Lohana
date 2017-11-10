using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Vehicle
{
    public class VehicleInfo
    {
        public VehicleInfo()
        {

        }


        public int VehicleId { get; set; }

        public string VehicleName { get; set; }

        public int SeatCapacity { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int VehicleTypeId { get; set; }

        public int VehicleBrandId { get; set; }

        public bool IsActive { get; set; }


        public string VehicleTypeName { get; set; }

        public string VehicleBrandName { get; set; }
    }
}
