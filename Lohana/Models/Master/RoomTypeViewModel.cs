using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.RoomType;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Master
{
    public class RoomTypeViewModel
    {

        public RoomTypeViewModel()
        {

            RoomType = new RoomTypeInfo();

            RoomTypes = new List<RoomTypeInfo>();

            Filter = new RoomTypeFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

        }

        public RoomTypeInfo RoomType { get; set; }

        public List<RoomTypeInfo> RoomTypes { get; set; }

        public PaginationInfo Pager { get; set; }

        public RoomTypeFilter Filter { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }

    public class RoomTypeFilter
    {
        public string RoomTypeName { get; set; }       
    }
}