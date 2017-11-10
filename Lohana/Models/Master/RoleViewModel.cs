using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Module;
using LohanaBusinessEntities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Role = new RoleInfo();

            Filter = new RoleFilter();

            Roles = new List<RoleInfo>();
                     
            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public RoleInfo Role
        {
            get;
            set;
        }

        public RoleFilter Filter
        {
            get;
            set;
        }

        public List<RoleInfo> Roles
        {
            get;
            set;
        }

        public PaginationInfo Pager { get; set; }

        public IEnumerable<string> Items { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }


        public List<ModuleInfo> Modules { get; set; }

        public object Module { get; set; }
    }

    public class RoleFilter
    {
        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    
    }
}