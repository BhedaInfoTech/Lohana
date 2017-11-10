function SaveSightSeeingTariffOccupancy() {

    $("#frmSightSeeingTariffOccupancy").blur();

    var sstViewModel = {

        SightSeeingTariffOccupancy: {

            SightSeeingTariffOccupancyId: $("[name='SightSeeingTariffOccupancyFilter.SightSeeingTariffOccupancyId']").val(),

            SightSeeingTariffId: $("[name='SightSeeingTariffOccupancy.SightSeeingTariffId']").val(),
            
            OccupancyId: $("#drpOccupancy").val(),

            AgeFrom: $("[name='SightSeeingTariffOccupancy.AgeFrom']").val(),

            AgeTo: $("[name='SightSeeingTariffOccupancy.AgeTo']").val(),

            MealId: $("#drpMeal").val(),

            Inclusion: $("[name='SightSeeingTariffOccupancy.Inclusion']").val(),
           
            Exclusion: $("[name='SightSeeingTariffOccupancy.Exclusion']").val(),
        }
    }
    var url = "";

    if ($("[name='SightSeeingTariffOccupancyFilter.SightSeeingTariffOccupancyId']").val() == 0) {

        url = "/SightSeeingTariff/InsertSightSeeingTariffOccupancy"
    }
    else {

        url = "/SightSeeingTariff/UpdateSightSeeingTariffOccupancy"
    }
    PostAjaxJson(url, sstViewModel, AfterOccupancySave);
}


function AfterOccupancySave(data) {

    FriendlyMessage(data);

    ResetBasic();

    GetSightSeeingTariffOccupancy();

}

function ResetOccupancy() {

    $("[name='SightSeeingTariffOccupancyFilter.SightSeeingTariffOccupancyId']").val('');

    $("#drpOccupancy").html('');

    $("#txtAgeFrom").val('');

    $("#txtAgeTo").val('');

    $("#drpMeal").html('');

    $("#txtInclusion").val('');

    $("#txtExclusion").val('');

}


function GetSightSeeingTariffOccupancy() {

    var sstViewModel =
		{
		    SightSeeingTariffOccupancy: {

		        SightSeeingTariffId: $("[name='SightSeeingTariffOccupancy.SightSeeingTariffId']").val(),

		    },
		    Pager: {

		        CurrentPage: $('#tblSightSeeingTariffOccupancy').attr("data-current-page"),
		    },
		}
  
    PostAjaxJson("/SightSeeingTariff/GetSightSeeingTariffOccupancy", sstViewModel, BindSightSeeingTariffOccupancy);
}

function BindSightSeeingTariffOccupancy(data) {

    var list = JSON.parse(data);
    
    var kTable = {
        dataList: ["OccupancyName", "MealName", "Inclusion", "Exclusion"],
        primayKey: ["SightSeeingTariffOccupancyId", "SightSeeingTariffId"],
        hiddenFields: ["SightSeeingTariffId", "SightSeeingTariffOccupancyId", "OccupancyId", "OccupancyName", "AgeFrom", "AgeTo", "MealId", "MealName", "Inclusion", "Exclusion"],
        headerNames: ["Occupancy", "Meal Plan", "Inclusion", "Exclusion"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblSightSeeingTariffOccupancy'));

    BindPagination(list.Pager, $('#tblSightSeeingTariffOccupancy'), "SightSeeingTariffOccupancyPagination");

}

function GetSetSightSeeingTariffOccupancyValues(obj) {

    var id = $(obj).attr("data-sightseeingtariffoccupancyid");   

    var sightseeingtariffid = $(obj).attr("data-sightseeingtariffid");
    
    var occupancyid = $(obj).attr("data-occupancyid");
   
    var occupancyname = $(obj).attr("data-occupancyname");

    var agefrom = $(obj).attr("data-agefrom");

    var ageto = $(obj).attr("data-ageto");

    var mealid = $(obj).attr("data-mealid");

    var mealname = $(obj).attr("data-mealname");

    var inclusion = $(obj).attr("data-inclusion");

    var exclusion = $(obj).attr("data-exclusion");

    $("[name='SightSeeingTariffOccupancy.SightSeeingTariffId']").val(sightseeingtariffid);

    $("[name='SightSeeingTariffOccupancy.AgeFrom']").val(agefrom);

    $("[name='SightSeeingTariffOccupancy.AgeTo']").val(ageto);

    $("[name='SightSeeingTariffOccupancy.OccupancyId']").attr("data-value", occupancyid);

    $("[name='SightSeeingTariffOccupancy.MealId']").attr("data-value", mealid);

    GetAutocompleteById("SightSeeingTariffOccupancy.OccupancyId");

    GetAutocompleteById("SightSeeingTariffOccupancy.MealId");

    $("[name='SightSeeingTariffOccupancy.Inclusion']").val(inclusion);

    $("[name='SightSeeingTariffOccupancy.Exclusion']").val(exclusion);

    //View     

    $("#lblOccupancy").text(occupancyname);

    $("#lblAgeFrom").text(agefrom);

    $("#lblAgeTo").text(ageto);

    $("#lblMeal").text(mealname);

    $("#lblOtherInclusion").text(inclusion);

    $("#lblOtherExclusion").text(exclusion);

    //For Price Occupancy 

    $("[name='SightSeeingTariffPrice.SightSeeingTariffOccupancyId']").val(id);

    $("[name='HotelTariffCustomerCategory.HotelTariffRoomOccupancyId']").val(id);

    //ResetCustomerCategory();

    //GetSightSeeingTariffCustomerCategory();

    //ResetPrice();

    GetSightSeeingTariffPrice();
   

}

function DeleteSightSeeingTariffOccupancy() {

    var sstViewModel =
      {

          SightSeeingTariffOccupancy: {

              SightSeeingTariffOccupancyId: $("[name='SightSeeingTariffOccupancyFilter.SightSeeingTariffOccupancyId']").val(),

              SightSeeingTariffId: $("[name='SightSeeingTariffOccupancy.SightSeeingTariffId']").val(),


          },
          Pager: {

              CurrentPage: $('#tblSightSeeingtariffOccupancy').attr("data-current-page"),
          },
          
      }
  
    PostAjaxJson("/SightSeeingTariff/DeleteSightSeeingTariffOccupancy", sstViewModel, AfterOccupancyDelete);
    
}

function AfterOccupancyDelete(data) {

    FriendlyMessage(data);

    ResetOccupancy();

    GetSightSeeingTariffOccupancy();
}

function SightSeeingTariffOccupancyPagination(CurrentPage) {

    $('#tblSightSeeingtariffOccupancy').attr("data-current-page", CurrentPage);

    GetSightSeeingTariffOccupancy();
}
