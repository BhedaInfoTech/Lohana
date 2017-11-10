using LohanaBusinessEntities.Module;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LohanaBusinessEntities
{
    public class UserInfo
    {
        public UserInfo()
        {
            LstModule = new List<ModuleInfo>();
        }
        
        public int UserId { get; set; }

        public int TeamLeadId { get; set; }

        public string Teamleads { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        
        public int CityId { get; set; }

        public string Locations { get; set; }

        public string MobileNo { get; set; }

        public string PhoneNo { get; set; }

        public string EmailId { get; set; }

        public string PermanentAddress { get; set; }

        public string ResidenceAddress { get; set; }

        public int RoleId { get; set; }

        public string UserName { get; set; }

        public string ConfirmPassword { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public string AppFunctionList { get; set; }

        public List<ModuleInfo> LstModule { get; set; }

        public string SpecializationType { get; set; }

    }
}
