using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Meal
{
    public class MealInfo
    {

        public MealInfo()
        {

        }

        public int MealId { get; set; }

        public string MealName { get; set; }

        public string MealDescription { get; set; }

        public bool IsActive { get; set; }      
    
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }
}
