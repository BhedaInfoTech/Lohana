using LohanaBusinessEntities;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Role;
using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.Enquiry;

namespace Lohana.Models.Master
{
    public class UserViewModel
    {
    
     public UserViewModel()
        {
            User = new UserInfo();

            Users = new List<UserInfo>();

            Cities = new List<CityInfo>();

            Role= new List<RoleInfo>();

            Filter = new UserFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            Specialization = new List<SpecializationInfo>();
        }

        public UserInfo User { get; set; }

        public List<UserInfo> Users { get; set; }

        public List<CityInfo> Cities { get; set; }

        public List<SpecializationInfo> Specialization { get; set; }

        public List<RoleInfo> Role { get; set; }

        public PaginationInfo Pager { get; set; }

        public UserFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class UserFilter
    {
        public int UserId {get; set;}

    }
    
}