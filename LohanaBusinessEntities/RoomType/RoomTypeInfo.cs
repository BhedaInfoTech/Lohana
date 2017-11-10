using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.RoomType
{
    public class RoomTypeInfo
    {
        public RoomTypeInfo()
        {

        }

        public int RoomTypeId { get; set; }

        public string RoomTypeName { get; set; }

        public int CheckActive { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

}
