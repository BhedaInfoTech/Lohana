using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Customer;
using LohanaBusinessEntities.CustomerCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Lohana.Models.Master
{
    public class CustomerViewModel
    {
    
     public CustomerViewModel()
        {
            Customer = new CustomerInfo();

            Customers = new List<CustomerInfo>();

            CustomerCategory = new List<CustomerCategoryInfo>();

            Filter = new CustomerFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public CustomerInfo Customer { get; set; }

        public List<CustomerInfo> Customers { get; set; }

        public List<CustomerCategoryInfo> CustomerCategory { get; set; }

        public PaginationInfo Pager { get; set; }

        public CustomerFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class CustomerFilter
    {
        public int CustomerId {get; set;}

        public string CustomerName { get; set; }

        public string MobileNo { get; set; }
    }

    }
