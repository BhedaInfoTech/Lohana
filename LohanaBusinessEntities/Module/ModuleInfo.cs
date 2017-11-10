using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LohanaBusinessEntities.Module
{
    public class ModuleInfo
    {
        public ModuleInfo()
        {

        }

        public int ModuleId { get; set; }

        public int RoleId { get; set; }

        public string ModuleName { get; set; }

        public bool HasAccess { get; set; }

        public bool IsCreate { get; set; }

        public bool IsEdit { get; set; }

        public bool IsView { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }
}
