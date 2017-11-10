using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.State;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.SupplierHotelTariff;
using LohanaBusinessEntities.SupplierSearch;


namespace Lohana.Models.Master
{
    public class SupplierSearchViewModel
    {
         public SupplierSearchViewModel()
        {

            FriendlyMessage = new List<FriendlyMessage>();

            SupplierSearch = new SupplierSearchInfo();

            SupplierSearchList = new List<SupplierSearchInfo>();

            SupplierList = new List<SupplierSearchInfo>();

            SupplierHotelList = new List<SupplierSearchInfo>();

            SupplierSearchRoomList = new List<SupplierSearchInfo>();

            SupplierSearchExtraList = new List<SupplierSearchInfo>();

            SupplierSearchExtraChildList = new List<SupplierSearchInfo>();

            SupplierSearchFilter = new SupplierSearchFilter();

            SupplierSearchFilterList = new List<SupplierSearchFilter>();

            SupplierHotelTariff = new SupplierHotelTariffInfo();

            SupplierHotelTariffs = new List<SupplierHotelTariffInfo>();

        

            Cities = new List<CityInfo>();

            Countries = new List<CountryInfo>();

            States = new List<StateInfo>();

            Pager = new PaginationInfo();

        }
         public List<FriendlyMessage> FriendlyMessage { get; set; }

         public SupplierSearchInfo SupplierSearch { get; set; }

         public List<SupplierSearchInfo> SupplierSearchList { get; set; }

         public List<SupplierSearchInfo> SupplierList { get; set; }

         public List<SupplierSearchInfo> SupplierSearchRoomList { get; set; }

         public List<SupplierSearchInfo> SupplierHotelList { get; set; }

         public List<SupplierSearchInfo> SupplierSearchExtraList { get; set; }

         public List<SupplierSearchInfo> SupplierSearchExtraChildList { get; set; }
             
         public SupplierSearchFilter SupplierSearchFilter { get; set; }

         public List<SupplierSearchFilter> SupplierSearchFilterList { get; set; }

         public SupplierHotelTariffInfo SupplierHotelTariff { get; set; }

         public List<SupplierHotelTariffInfo> SupplierHotelTariffs { get; set; }

         public List<CityInfo> Cities { get; set; }

         public PaginationInfo Pager { get; set; }

         public List<CountryInfo> Countries { get; set; }

         public List<StateInfo> States { get; set; }

         public bool IsAddToQuotation { get; set; }


    }
}