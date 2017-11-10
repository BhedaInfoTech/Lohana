using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.CustomerCategory
{
    public class CustomerCategoryInfo
    {
        public CustomerCategoryInfo()
        {

        }

        public int CustomerCategoryId { get; set; }

        // public string CustomerCategoryCode { get; set; }

        public string CustomerCategoryName { get; set; }

        public decimal Margin { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public bool IsActive { get; set; }


        public int CustomerCategory { get; set; }
    }

}
