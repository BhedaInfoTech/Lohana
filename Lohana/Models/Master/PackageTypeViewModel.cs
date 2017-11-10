using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using LohanaBusinessEntities;
using LohanaBusinessEntities.PackageType;
using LohanaBusinessEntities.Common;

namespace Lohana.Models.Master
{
    public class PackageTypeViewModel
    {

        public PackageTypeViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            PackageType = new PackageTypeInfo();

            PackageTypes = new List<PackageTypeInfo>();

        }


        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public PackageTypeInfo PackageType { get; set; }

        public List<PackageTypeInfo> PackageTypes { get; set; }

    }
}