using LohanaBusinessEntities;
using LohanaBusinessEntities.CustomerCategory;
using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class CustomerCategoryViewModel
    {
        public CustomerCategoryViewModel()
        {
            CustomerCategory = new CustomerCategoryInfo();

            Filter = new CustomerCategoryFilter();

            CustomerCategories = new List<CustomerCategoryInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public CustomerCategoryInfo CustomerCategory
        {
            get;
            set;
        }

        public CustomerCategoryFilter Filter
        {
            get;
            set;
        }

        public List<CustomerCategoryInfo> CustomerCategories
        {
            get;
            set;
        }

        public PaginationInfo Pager { get; set; }

        public IEnumerable<string> Items { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }


    }

    public class CustomerCategoryFilter
    {
        public string CustomerCategoryName { get; set; }

        public string CustomerCategoryId { get; set; }

    }
}

