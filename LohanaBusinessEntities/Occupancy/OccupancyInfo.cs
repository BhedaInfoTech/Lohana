using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Occupancy
{
    public class OccupancyInfo
    {

        public OccupancyInfo()
        {

        }

        public int OccupancyId { get; set; }

        public string OccupancyName { get; set; }

        public int OccupancyValue { get; set; }

        public int OccupancyType { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public string OccupancyTypeStr
        {
            get
            {
                if (OccupancyType != 0)
                {
                    return LookupInfo.Get_Occupancy_Type().Where(a => a.Key == OccupancyType).Select(a => a.Value).FirstOrDefault();
                }
                else
                {

                    return "";
                }

            }
            set { }
        }
    }
}
