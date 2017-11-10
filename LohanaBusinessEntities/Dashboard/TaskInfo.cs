using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.Dashboard
{
    public class TaskInfo
    {
        public int UserId { get; set; }

        public int TaskNo { get; set; }

        public int AssigneeToId { get; set; }

        public int TaskType { get; set; }

        public string CustomerName { get; set; }

        public string Status { get; set; }

        public int StatusId { get; set; }

        public int RefId { get; set; }

        public int EnquiryId { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public DateTime FollowUpDate { get; set; }

        public bool IsFollowed { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
