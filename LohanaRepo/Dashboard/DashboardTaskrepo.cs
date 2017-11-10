using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LohanaBusinessEntities.Dashboard;
using System.Data;
using System.Data.SqlClient;
using LohanaRepo.Utilities;
using LohanaBusinessEntities.Common;

namespace LohanaRepo.Dashboard
{
    public class DashboardTaskRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public DashboardTaskRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }
        
        public List<TaskInfo> GetUserEnquiryTask(int UserId)
        {
            List<TaskInfo> Tasks = new List<TaskInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@UserId", UserId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetUserEnquiryTask.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tasks.Add(GetUserEnquiryTask(dr));
                }
            }
            return Tasks; 
        }

        public List<TaskInfo> GetUserQuotationTask(int UserId)
        {
            List<TaskInfo> Tasks = new List<TaskInfo>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@UserId", UserId));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetUserQuotationTask.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tasks.Add(GetUserQuotationTask(dr));
                }
            }
            return Tasks;
        }

        private TaskInfo GetUserEnquiryTask(DataRow dr)
        {
            TaskInfo task = new TaskInfo();

            if(dr["TaskId"] != DBNull.Value)
            {
                task.TaskNo = Convert.ToInt32(dr["TaskId"]);
            }

            //if (dr["TaskType"] != DBNull.Value)
            //{
            //    task.TaskType = Convert.ToInt32(dr["TaskId"]);
            //}

            if (dr["CustomerName"] != DBNull.Value)
            {
                task.CustomerName = Convert.ToString(dr["CustomerName"]);
            }
            else if(dr["CompanyName"] != DBNull.Value)
            {
                task.CustomerName = Convert.ToString(dr["CompanyName"]);
            }
            else
            {
                task.CustomerName = Convert.ToString(dr["GuestName"]);
            }

            task.Status = Convert.ToString(dr["EnquiryStatusStr"]);

            if (dr["QuotationId"] != DBNull.Value)
            {
                task.RefId = Convert.ToInt32(dr["QuotationId"]); 
            }
            task.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (dr["FollowUpDate"] != DBNull.Value)
                task.FollowUpDate = Convert.ToDateTime(dr["FollowUpDate"]);
            //else
            //    task.FollowUpDate = Convert.ToDateTime(" ");

            if (dr["LastUpdatedDate"] != DBNull.Value)
                task.LastUpdatedDate = Convert.ToDateTime(dr["LastUpdatedDate"]);
            //else
            //    task.LastUpdatedDate = Convert.ToDateTime(" ");

            return task;
        }

        private TaskInfo GetUserQuotationTask(DataRow dr)
        {
            TaskInfo task = new TaskInfo();

            if (dr["TaskId"] != DBNull.Value)
            {
                task.TaskNo = Convert.ToInt32(dr["TaskId"]);
            }

            if (dr["CustomerName"] != DBNull.Value)
            {
                task.CustomerName = Convert.ToString(dr["CustomerName"]);
            }
            else if (dr["CompanyName"] != DBNull.Value)
            {
                task.CustomerName = Convert.ToString(dr["CompanyName"]);
            }
            else
            {
                task.CustomerName = Convert.ToString(dr["GuestName"]);
            }

            task.StatusId = Convert.ToInt32(dr["QuotationStatus"]);

            task.RefId = Convert.ToInt32(dr["QuotationId"]);
            task.EnquiryId = Convert.ToInt32(dr["EnquiryId"]);

            if (dr["FollowUpDate"] != DBNull.Value)
                task.FollowUpDate = Convert.ToDateTime(dr["FollowUpDate"]);
            //else
            //    task.FollowUpDate = Convert.ToDateTime(" ");

            if (dr["LastUpdatedDate"] != DBNull.Value)
                task.LastUpdatedDate = Convert.ToDateTime(dr["LastUpdatedDate"]);
            //else
            //    task.LastUpdatedDate = Convert.ToDateTime(" ");

            return task;
        }

        public bool UpdateQuotationStatus(int TaskId, int QuotationItemId, int StatusId , int UserId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@TaskId", TaskId));
            sqlParams.Add(new SqlParameter("@QuotationItemId", QuotationItemId));
            sqlParams.Add(new SqlParameter("@QuotationStatus", StatusId));
            sqlParams.Add(new SqlParameter("@UpdatedBy", UserId));
            sqlParams.Add(new SqlParameter("@UpdatedDate", DateTime.Now));

            _sqlHelper.ExecuteNonQuery(sqlParams, Storeprocedures.spUpdateQuotationStatus.ToString(), CommandType.StoredProcedure);
            
            return true;
        }

        public int CheckIsUserApproval(int UserId)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@UserId", UserId));
            sqlParams.Add(new SqlParameter("@ModuleName", "Quotation Approval"));

            return Convert.ToInt32(_sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spCheckWorkFlow.ToString(), CommandType.StoredProcedure));
        }

        public List<TaskInfo> GetApprovalQuotationTask()
        {
            List<TaskInfo> Tasks = new List<TaskInfo>();

            DataTable dt = _sqlHelper.ExecuteDataTable(null, Storeprocedures.spGetUserApprovalTask.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tasks.Add(GetUserQuotationTask(dr));
                }
            }
            return Tasks;
        }
    }
}
