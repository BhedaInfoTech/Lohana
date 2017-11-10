using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.HotelTypeInfo
{
    public class HotelTypeInfo
    {
        public HotelTypeInfo()
        { }

      public int HotelTypeId{get;set;}
      public string HotelType{get;set;}
      public DateTime CreatedDate{get;set;}
      public int CreatedBy{get;set;}
      public DateTime UpdatedDate{get;set;}
      public int UpdatedBy{get;set;}
      public bool IsActive {get;set;}
    } 
}
