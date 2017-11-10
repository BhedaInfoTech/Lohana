using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.Dashboard;
using LohanaBusinessEntities.Common;

namespace Lohana.Models.Dashboard
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            Task_Grid = new List<TaskInfo>();

            Filter = new TaskFilter();

            QuotationGrid = new List<TaskInfo>();
        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<TaskInfo> Task_Grid { get; set; }

        public TaskFilter Filter { get; set; }

        public List<TaskInfo> QuotationGrid { get; set; }

        public int QuotationItemId { get; set; }
        public int QuotationStatus { get; set; }
        public int TaskId { get; set; }
        public bool IsApproval { get; set; }
    }

    public class TaskFilter
    {
        public int TaskId { get; set; }
    }
}