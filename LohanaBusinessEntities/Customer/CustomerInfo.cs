using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Customer
{
    public class CustomerInfo
    {            
            public int CustomerId { get; set; }

            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }

            public int Gender { get; set; }

            public bool IsActive { get; set; }

            public DateTime DOB { get; set; }

            public string EmailId { get; set; }

            public string PhoneNo { get; set; }

            public string MobileNo { get; set; }

            public string PanNo { get; set; }

            public string AadharCardNo { get; set; }

            public string PassportNo { get; set; }

            public string Address { get; set; }

            public int CustomerCategoryId { get; set; }

            public DateTime CreatedDate { get; set; }

            public int CreatedBy { get; set; }

            public DateTime UpdatedDate { get; set; }

            public int UpdatedBy { get; set; }

            public string CustomerCategoryName { get; set; }

        
    }
}
