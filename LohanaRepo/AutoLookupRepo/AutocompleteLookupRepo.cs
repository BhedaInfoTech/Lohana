using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessLogic.Utilities;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaHelper;
//using LohanaHelper.PageHelper;


namespace LohanaRepo.AutoLookupRepo
{
    public class AutocompleteLookupRepo
    {
        SQLHelperRepo _sqlHelper = null;

        public AutocompleteLookupRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        public DataTable Get_Lookup_Data(string table_Name, string[] cols, string fieldValue, string fieldName, int entity_Id)
         {

            string strquery = "";

            strquery = "select ";

            for (int i = 0; i < cols.Length; i++)
            {
                strquery += cols[i] + ",";
            }

            char[] removeCh = { ',', ' ' };

            strquery = strquery.TrimEnd(removeCh);

            strquery += " from " + table_Name;

            List<SqlParameter> paramList = new List<SqlParameter>();

            if (fieldValue != "0" && !string.IsNullOrEmpty(fieldValue))
            {

              
            }

            DataTable dt = _sqlHelper.ExecuteDataTable(paramList, strquery, CommandType.Text);

            return dt;
        }

        public string Get_Lookup_Data_Country(string field_Value, string table_Name, string[] columns)
        {
            string Value = "";

            string strquery = "";

            string col_Id = "";

            string col_Value = "";

            strquery = "select ";

            for (int i = 0; i < columns.Length; i++)
            {
                strquery += columns[i] + ",";

                col_Id = columns[0].ToString();

                col_Value = columns[1].ToString();
            }

            char[] removeCh = { ',', ' ' };

            strquery = strquery.TrimEnd(removeCh);

            strquery += " from " + table_Name;

            strquery += " where " + table_Name + "." + col_Value + "='" + field_Value + "'";

            DataTable dt = _sqlHelper.ExecuteDataTable(null, strquery, CommandType.Text);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    Value = Convert.ToString(dr[col_Value]) + "_" + dr[col_Id];

                    //Value = Convert.ToString(dr[col_Value]);
                }
            }

            return Value;
        }

        

    }
}
