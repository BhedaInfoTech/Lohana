using LohanaBusinessEntities.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Role
{
    public class RoleInfo
    {
        public RoleInfo()
        {
            Modules = new List<ModuleInfo>();
        }
            public int RoleId{ get; set;}

            public string RoleName { get; set;}

            public DateTime CreatedDate { get; set; }

            public int CreatedBy { get; set; }

            public DateTime UpdatedDate { get; set; }

            public int UpdatedBy { get; set; }

            public bool IsActive { get; set; }

        
           public List<ModuleInfo> Modules { get; set; }


           public System.Data.DataRow ModuleId { get; set; }
    }
    
}
