using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.State;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.Common;

namespace Lohana.Models.Master
{
    public class StateViewModel
    {
        public StateViewModel()
        {
            State = new StateInfo();

            Filter = new StateFilter();

            States = new List<StateInfo>();

            Countries = new List<CountryInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public StateInfo State { get; set; }

        public StateFilter Filter { get; set; }

        public List<StateInfo> States { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<CountryInfo> Countries { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

    }

    public class StateFilter
    {
        public string StateName { get; set; }

        //public string StateId { get; set; }

    }

}