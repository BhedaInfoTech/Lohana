using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Meal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class MealViewModel
    {

        public MealViewModel()
        {

            Meal = new MealInfo();

            Meals = new List<MealInfo>();

            Filter = new MealFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public MealInfo Meal { get; set; }

        public List<MealInfo> Meals { get; set; }

        public PaginationInfo Pager { get; set; }

        public MealFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class MealFilter
    {
        public string MealName { get; set; }
    }
}