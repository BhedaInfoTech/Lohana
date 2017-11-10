using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Dashboard;
using LohanaRepo.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaRepo.TaskManagementRepo
{
    public class TaskManagementRepo
    {

        SQLHelperRepo _sqlHelper = null;

        public TaskManagementRepo()
        {
            _sqlHelper = new SQLHelperRepo();
        }

        //public List<TaskInfo> GetTasks(int UserId)
        
        public List<TaskInfo> GetTasks(TaskInfo task)
        {
            List<TaskInfo> tasks = new List<TaskInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@UserId", task.UserId));

            sqlParams.Add(new SqlParameter("@CustomerName", task.CustomerName));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetTeamLeadUsersTask.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tasks.Add(GetTask(dr));
                }
            }

            return tasks;
        }

        private TaskInfo GetTask(DataRow dr)
        {
            TaskInfo task = new TaskInfo();

            if (dr["TaskId"] != DBNull.Value)
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
            else if (dr["CompanyName"] != DBNull.Value)
            {
                task.CustomerName = Convert.ToString(dr["CompanyName"]);
            }
            else
            {
                task.CustomerName = Convert.ToString(dr["GuestName"]);
            }

            task.Status = Convert.ToString(dr["EnquiryStatusStr"]);

            if (dr["FollowUpDate"] != DBNull.Value)
                task.FollowUpDate = Convert.ToDateTime(dr["FollowUpDate"]); 

            if (dr["LastUpdatedDate"] != DBNull.Value)
                task.LastUpdatedDate = Convert.ToDateTime(dr["LastUpdatedDate"]); 

            if (dr["IsFollowed"] != DBNull.Value)
                task.IsFollowed = Convert.ToBoolean(dr["IsFollowed"]);

            return task;
        }

        public TaskInfo GetTaskByTaskId(int TaskNo)
        {
            TaskInfo task = new TaskInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@TaskId", TaskNo));

            DataTable dt = _sqlHelper.ExecuteDataTable(sqlParams, Storeprocedures.spGetTaskByTaskId.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["TaskId"] != DBNull.Value)
                    task.TaskNo = Convert.ToInt32(dt.Rows[0]["TaskId"]);

                if (dt.Rows[0]["CustomerName"] != DBNull.Value)
                    task.CustomerName = Convert.ToString(dt.Rows[0]["CustomerName"]);
                else if (dt.Rows[0]["CompanyName"] != DBNull.Value)
                    task.CustomerName = Convert.ToString(dt.Rows[0]["CompanyName"]);
                else
                    task.CustomerName = Convert.ToString(dt.Rows[0]["GuestName"]);

                task.Status = Convert.ToString(dt.Rows[0]["EnquiryStatusStr"]);

                task.AssigneeToId = Convert.ToInt32(dt.Rows[0]["AssigneeToId"]);

                if (dt.Rows[0]["IsFollowed"] != DBNull.Value)
                    task.IsFollowed = Convert.ToBoolean(dt.Rows[0]["IsFollowed"]);

                //if (Convert.ToDateTime(dt.Rows[0]["FollowUpDate"]) != DateTime.MinValue)
                if (dt.Rows[0]["FollowUpDate"] != DBNull.Value)
                    task.FollowUpDate = Convert.ToDateTime(dt.Rows[0]["FollowUpDate"]);
            }

            return task;
        }

        public void UpdateTask(TaskInfo taskInfo)
        {
            //throw new NotImplementedException();
            List<SqlParameter> sqlParams = new List<SqlParameter>();

           // int id = 0;

            sqlParams.Add(new SqlParameter("@TaskId", taskInfo.TaskNo));

            sqlParams.Add(new SqlParameter("@TaskType", (int)TaskType.Enquiry));

            sqlParams.Add(new SqlParameter("@UserId", taskInfo.UserId));

            sqlParams.Add(new SqlParameter("@FollowUpDate", taskInfo.FollowUpDate));
                  
            sqlParams.Add(new SqlParameter("@UpdatedBy", taskInfo.UpdatedBy));

            sqlParams.Add(new SqlParameter("@UpdatedDate", DateTime.Today));

            _sqlHelper.ExecuteScalerObj(sqlParams, Storeprocedures.spUpdateTask.ToString(), CommandType.StoredProcedure);
           
        }
    }
}
