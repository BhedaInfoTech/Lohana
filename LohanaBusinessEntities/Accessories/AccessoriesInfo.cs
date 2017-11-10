using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Accessories
{
  public  class AccessoriesInfo
    {

        
            public int AttachmentId { get; set; }

            public int RefId { get; set; }

            public int RefType { get; set; }

            public string RefCategory { get; set; }

            public string RefTypeName { get; set; }

            public string AttachmentName { get; set; }

            public string UniqueAttachmentId { get; set; }

            public int CreatedBy { get; set; }

            public DateTime CreatedDate { get; set; }

            public int UpdatedBy { get; set; }

            public DateTime UpdatedDate { get; set; }

           

        
    }
}
