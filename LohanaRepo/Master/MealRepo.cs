using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;
using LohanaRepo.Utilities;
using LohanaBusinessLogic.Utilities;
using LohanaHelper.Logging;


namespace LohanaRepo.Master
{
    public class MealRepo
    {

         SQLHelperRepo _sqlHelper = null;

        public MealRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public int Insert(MealInfo meal)
        {
            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(SetValuesInMeal(meal), Storeprocedures.spInsertMeal.ToString(), CommandType.StoredProcedure));
        }

        public List<SqlParameter> SetValuesInMeal(MealInfo meal)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (meal.MealId != 0)
            {
                sqlParam.Add(new SqlParameter("MealId", meal.MealId));
            }
            else
            {
                sqlParam.Add(new SqlParameter("CreatedDate", meal.CreatedDate));

                sqlParam.Add(new SqlParameter("CreatedBy", meal.CreatedBy));
            }

            sqlParam.Add(new SqlParameter("MealName", meal.MealName));

            Logger.Debug("Meal Controller MealName:" + meal.MealName);

            sqlParam.Add(new SqlParameter("MealDescription", meal.MealDescription));

            Logger.Debug("Meal Controller MealDescription:" + meal.MealDescription);

            sqlParam.Add(new SqlParameter("@IsActive", meal.IsActive));

            Logger.Debug("Meal Controller IsActive:" + meal.IsActive);

            sqlParam.Add(new SqlParameter("UpdatedBy", meal.UpdatedBy));

            sqlParam.Add(new SqlParameter("UpdatedDate", meal.UpdatedDate));

            return sqlParam;
        }

        public DataTable GetMeals (string mealName,ref PaginationInfo pager)
        {

            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@MealName", mealName));
        
            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetMeals.ToString(), CommandType.StoredProcedure);

            return CommonMethods.GetPaginatedTable(dt, ref pager);         

        }      

        public void Update(MealInfo meal)
        {
            _sqlHelper.ExecuteNonQuery(SetValuesInMeal(meal), Storeprocedures.spUpdateMeal.ToString(), CommandType.StoredProcedure);
        }

        public bool CheckMealNameExist(string mealName)
        {

            string ProcedureName = string.Empty;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@MealName", mealName));

            Logger.Debug("Meal Controller MealName:" + mealName);

            return Convert.ToBoolean(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckMealNameExist.ToString(), CommandType.StoredProcedure));

        }


    }
}
