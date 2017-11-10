using LohanaBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaRepo.Utilities
{
    public class AutoCompleteRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public AutoCompleteRepo()
		{
			_sqlHelper = new SQLHelperRepo();
		}

		public DataTable GetTableData(string q, int page, string idFieldName, string textFieldName, string tableName, string dependentFieldName, string dependentFieldValue, string extraFields)
        {
			List<IdTextInfo> autoList = new List<IdTextInfo>();

            string query = "";

			query += " select " + idFieldName + " as id, " + textFieldName + " as text ";
			
			if(!string.IsNullOrEmpty(extraFields))
			{
				query += ", "+extraFields;
			}
			
			query += " from " + tableName + " ";

			query += "where "+  textFieldName + "  like '%" + q + "%' ";

			if(!string.IsNullOrEmpty(dependentFieldName))
			{
				string[] dependentFields = dependentFieldName.Split(',');

				string[] dependentFieldValues = dependentFieldValue.Split(',');

				for(int i = 0; i < dependentFields.Length; i++)
				{
					query += " and " + dependentFields[i] + " = '" + dependentFieldValues[i] + "' ";
				}

				query += ";";
			}

            DataTable dt = _sqlHelper.ExecuteDataTable(null, query, System.Data.CommandType.Text);

            dt = dt.Select().Skip((page - 1) * 10).Take(10).CopyToDataTable();

			//foreach (DataRow dr in dt.Rows)
			//{
			//	IdTextInfo aInfo = new IdTextInfo();

			//	dynamic expando = new ExpandoObject();
			//	expando = 42.0;
			//	expando.ItemName = "Shoes";

			//	aInfo.Id = Convert.ToInt32(dr["Id"]);

			//	aInfo.Text = Convert.ToString(dr["Text"]);

			//	autoList.Add(aInfo);
			//}

			return dt;
        }

		public DataTable GetTableDataById(string id, string idFieldName, string textFieldName, string tableName, string extraFields)
		{
			List<IdTextInfo> autoList = new List<IdTextInfo>();

			string query = "";

			query += " select " + idFieldName + " as id, " + textFieldName + " as text ";
			
			if(!string.IsNullOrEmpty(extraFields))
			{
				query += ", "+extraFields;
			}
			
			query += " from "+tableName+"  where ";

			if(!id.Contains(','))
			{
				query += idFieldName + " = " + id + " ;";
			}
			else
			{
				query += idFieldName + " in (";

				foreach(var itm in id.Split(','))
				{
					query +=  itm + ",";
				}

				query = query.Substring(0, query.Length - 1);

				query += ")";
			}

			DataTable dt = _sqlHelper.ExecuteDataTable(null, query, System.Data.CommandType.Text);

			//dt = dt.Select().Skip((page - 1) * 10).Take(10).CopyToDataTable();

			//foreach(DataRow dr in dt.Rows)
			//{
			//	IdTextInfo aInfo = new IdTextInfo();

			//	aInfo.Id = Convert.ToInt32(dr["Id"]);

			//	aInfo.Text = Convert.ToString(dr["Text"]);

			//	autoList.Add(aInfo);
			//}

			return dt;
		}

		public List<AutocompleteInfo> GetAutocompletesByPageName(string pageName)
		{
			List<AutocompleteInfo> autocompletes = new List<AutocompleteInfo>();

			List<SqlParameter> sqlParam = new List<SqlParameter>();

			sqlParam.Add(new SqlParameter("@PageName", pageName));

			DataTable dt = _sqlHelper.ExecuteDataTable(sqlParam, Storeprocedures.spGetAutocompleteByPageName.ToString(), CommandType.StoredProcedure);

			foreach(DataRow dr in dt.Rows)
			{
				autocompletes.Add(Get_Autocomplete_Values(dr));
			}
			return autocompletes;
		}

		private AutocompleteInfo Get_Autocomplete_Values(DataRow dr)
		{
			AutocompleteInfo autocomplete = new AutocompleteInfo();

			autocomplete.AutocompleteId = Convert.ToInt32(dr["AutocompleteId"]);

			autocomplete.PageName = Convert.ToString(dr["PageName"]);

			autocomplete.ControlName = Convert.ToString(dr["ControlName"]);

			autocomplete.TableName = Convert.ToString(dr["TableName"]);

			autocomplete.TextFieldName = Convert.ToString(dr["TextFieldName"]);

			autocomplete.IdFieldName = Convert.ToString(dr["IdFieldName"]);

			autocomplete.DependentControlName = Convert.ToString(dr["DependentControlName"]);

			autocomplete.DependentFieldName = Convert.ToString(dr["DependentFieldName"]);

			autocomplete.ExtraFields = Convert.ToString(dr["ExtraFields"]);

			if(dr["IsMultiselect"] != DBNull.Value)
			{
				autocomplete.IsMultiselect = Convert.ToBoolean(dr["IsMultiselect"]);
			}

			if(dr["CreatedBy"] != DBNull.Value)
			{
				autocomplete.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
			}

			if(dr["CreatedDate"] != DBNull.Value)
			{
				autocomplete.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
			}

			if(dr["UpdatedBy"] != DBNull.Value)
			{
				autocomplete.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
			}

			if(dr["UpdatedDate"] != DBNull.Value)
			{
				autocomplete.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
			}

			return autocomplete;
		}

		public List<IdTextInfo> GetTableDataById(string id, string idFieldName, string textFieldName, string tableName, string dependentFieldName, string dependentFieldValue)
		{
			List<IdTextInfo> autoList = new List<IdTextInfo>();

			string query = "";

			query += " select " + idFieldName + " as id, " + textFieldName + " as text from " + tableName + "  where ";

			if(!id.Contains(','))
			{
				query += idFieldName + " = " + id + " ;";
			}
			else
			{
				query += idFieldName + " in (";

				foreach(var itm in id.Split(','))
				{
					query += itm + ",";
				}

				query = query.Substring(0, query.Length - 1);

				query += ")";
			}

			if(!string.IsNullOrEmpty(dependentFieldName))
			{
				string[] dependentFields = dependentFieldName.Split(',');

				string[] dependentFieldValues = dependentFieldValue.Split(',');

				for(int i = 0; i < dependentFields.Length; i++)
				{
					query += " and " + dependentFields[i] + " = '" + dependentFieldValues[i] + "' ";
				}

				query += ";";
			}

			DataTable dt = _sqlHelper.ExecuteDataTable(null, query, System.Data.CommandType.Text);

			//dt = dt.Select().Skip((page - 1) * 10).Take(10).CopyToDataTable();

			foreach(DataRow dr in dt.Rows)
			{
				IdTextInfo aInfo = new IdTextInfo();

				aInfo.Id = Convert.ToInt32(dr["Id"]);

				aInfo.Text = Convert.ToString(dr["Text"]);

				autoList.Add(aInfo);
			}

			return autoList;
		}
    }
}
