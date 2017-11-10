using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Module;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaRepo.Master
{
   public class AuthenticationRepo
    {
       SQLHelperRepo _sqlHelper = null;

       public AuthenticationRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

       public SessionInfo AuthernticateLogin(SessionInfo session)
       {
           SessionInfo user = new SessionInfo();

           List<SqlParameter> sqlParam = new List<SqlParameter>();

           List<ModuleInfo> LstModule = new List<ModuleInfo>();

           sqlParam.Add(new SqlParameter("@UserName", session.UserName));

           sqlParam.Add(new SqlParameter("@Password", session.Password));

           DataSet ds = _sqlHelper.ExecuteDataSet(sqlParam, Storeprocedures.AuthenticationLogin.ToString(), CommandType.StoredProcedure);

           if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
           {
               #region User Detail

               DataTable dt = ds.Tables[0];
               
               DataRow dr = dt.AsEnumerable().FirstOrDefault();

               if (dr != null)
               {  
                   user.UserId = Convert.ToInt32(dr["UserId"]);
                                    
                   user.RoleId = Convert.ToInt32(dr["RoleId"]);
                  
                   user.FirstName = Convert.ToString(dr["FirstName"]);

                   if (dr["MiddleName"] != DBNull.Value)
                   {
                       user.MiddleName = Convert.ToString(dr["MiddleName"]);
                   }

                   user.LastName = Convert.ToString(dr["LastName"]);
                
                   user.UserName = Convert.ToString(dr["UserName"]);

                   if (dr["IsActive"] != DBNull.Value)
                   {
                       user.IsActive = Convert.ToBoolean(dr["IsActive"]);
                   }

                   user.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);

                   user.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);


                   user.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

                   user.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
               }

               #endregion

               # region Module Detail

               if (ds != null && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
               {
                   DataTable dtModule = ds.Tables[1]; 

                   foreach(DataRow row in dtModule.Rows)
                   {
                       LstModule.Add(new ModuleInfo() {

                           ModuleId = Convert.ToInt32(row["ModuleId"]),

                           HasAccess = Convert.ToBoolean(row["HasAccess"]),

                           IsCreate = Convert.ToBoolean(row["IsCreate"]),

                           IsEdit = Convert.ToBoolean(row["IsEdit"]),

                           IsView = Convert.ToBoolean(row["IsView"])                       
                       });
                   }                        
               }

               user.LstModule = LstModule;

               #endregion
           }

           return user;
       }

   
   }
}
