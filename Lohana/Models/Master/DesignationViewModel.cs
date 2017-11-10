using LohanaBusinessEntities;
using LohanaBusinessEntities.Designation;
using LohanaBusinessEntities.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class DesignationViewModel
    {

        public DesignationViewModel()
        {
            Designation = new DesignationInfo();

            Designations = new List<DesignationInfo>();

            Filter = new DesignationFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public DesignationInfo Designation { get; set; }

        public List<DesignationInfo> Designations { get; set; }

        public PaginationInfo Pager { get; set; }

        public DesignationFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class DesignationFilter
    {

        public string DesignationName { get; set; }

    }

}