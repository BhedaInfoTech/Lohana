using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Dashboard;
using LohanaBusinessEntities.Common; 

namespace Lohana.Models.TaskManagement
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
            Task = new TaskInfo();

            Tasks = new List<TaskInfo>();

            Users = new List<UserInfo>();

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();
        }

        public TaskInfo Task { get; set; }

        public List<TaskInfo> Tasks { get; set; }

        public List<UserInfo> Users { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }
    }
}