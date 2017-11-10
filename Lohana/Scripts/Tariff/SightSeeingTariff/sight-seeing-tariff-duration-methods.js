function SaveSightSeeingTariffDuration() {

    $("#frmSightSeeingTariffduration").blur();

    var sstViewModel = SightSeeingTariffViewModel();

    var url = "";

    PostAjaxJson("/SightSeeingTariff/IsOverrideDate", sstViewModel, function (data) {
        

        AfterIsOverrideDate(data, sstViewModel);

    });

}

function SightSeeingTariffViewModel() {

    var days = [];
    var customerCategoriesList = [];

    $(".item-data-row").each(function (i) {


        var customerCategories = {

            CustomerCategoryId: $("#hdnCustomerCategoryId_" + i).val(),

            GlobalMargin: $("#txtGlobalMargin_" + i).val()

        }

        customerCategoriesList.push(customerCategories);
    });

    $('input[name="SightSeeingTariffDuration.OperationalDays"]:checked').each(function (i) {
        days.push($(this).val())
    });

    var DaysValue = days.join();

    var sstViewModel = {

        SightSeeingTariffCustomerCategories: customerCategoriesList,

        SightSeeingTariffDuration: {

            SightSeeingTariffPriceId: $("[name='SightSeeingTariffDuration.SightSeeingTariffPriceId']").val(),

            SightSeeingTariffOccupancyId: $("[name='SightSeeingTariffPrice.SightSeeingTariffOccupancyId']").val(),

            FromDate: $("[name='SightSeeingTariffDuration.FromDate']").val(),

            ToDate: $("[name='SightSeeingTariffDuration.ToDate']").val(),

            OperationalDays: DaysValue,
        }

    }

    return sstViewModel;
}

function AfterIsOverrideDate(data, sstViewModel) {
    if (data == true) {
        DisplayConformationPopup("Some date's price may get override, Do you want to procced ?", "ti-view-list-alt", "Conformation", function () {
            PostAjaxJson("/SightSeeingTariff/SaveSightSeeingTariffDurationWithCustomerCategories", sstViewModel, AfterDurationSave);

        }, null);
    }
    else {
        PostAjaxJson("/SightSeeingTariff/SaveSightSeeingTariffDurationWithCustomerCategories", sstViewModel, AfterDurationSave);
    }
}

function AfterDurationSave(data) {

    //FriendlyMessagePopup(data);

    ResetDuration();

    GetSightSeeingTariffDuration($("#dvcalendar1"));

    GetSightSeeingTariffDuration($("#dvcalendar"));

    GetSightSeeingTariffCustomerCategory();

}

function ResetDuration() {
    $("[name='SightSeeingTariffDuration.SightSeeingTariffPriceId']").html("");

    $("#txtFromDate").val('');

    $("#txtToDate").val('');

    $('[name="SightSeeingTariffDuration.OperationalDays"]').removeAttr('checked');

    $("#drpAllWeekWeekEnd").val("none");

}



//function GetSetSightSeeingTariffDurationValues(obj) {

//    var id = $(obj).attr("data-sightseeingtariffdurationid");

//    var sightseeingtariffid = $(obj).attr("data-sightseeingtariffid");

//    var fromdate = $(obj).attr("data-fromdate");

//    var todate = $(obj).attr("data-todate");

//    var operationaldays = $(obj).attr("data-operationaldays");

//    operationaldaysValues = operationaldays.split(',');

//    for (i = 0; i < operationaldaysValues.length; i++) {

//        document.getElementById("chkDays" + operationaldaysValues[i]).checked = true;
//    }


//    $("[name='SightSeeingTariffDuration.SightSeeingTariffId']").val(sightseeingtariffid),

//    $("[name='SightSeeingTariffDuration.FromDate']").val(fromdate),

//    $("[name='SightSeeingTariffDuration.ToDate']").val(todate),

//    $("#lblFromDate").text(fromdate + " " + "to" + " " + todate),

//    $("#lblOperationalDays").text(operationaldays),

//    $("[name='HotelTariffRoom.HotelTariffDurationDetailsId']").val(id),

//    $("[name='HotelTariffRoom.HotelTariffId']").val(hoteltariffid),

//    //for PriceDetails

//      $("[name='HotelTariffPrice.HotelTariffDurationDetailsId']").val(id),

//       $("[name='HotelTariffPrice.HotelTariffId']").val(hoteltariffid),

//     $("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val(id)

//    ResetRoom();

//}

//function DeleteDuration() {

//    var sstViewModel =
//      {

//          SightSeeingTariffDuration: {

//              SightSeeingTariffDurationId: $("[name='SightSeeingTariffDurationFilter.SightSeeingTariffDurationId']").val(),

//              SightSeeingTariffId: $("[name='SightSeeingTariffDuration.SightSeeingTariffId']").val(),

//          },
//          Pager: {

//              CurrentPage: $('#tblSightSeeingTariffDuration').attr("data-current-page"),
//          },
//      }

//    PostAjaxJson("/SightSeeingTariff/DeleteSightSeeingTariffDuration", sstViewModel, AfterDurationDelete);

//}

//function AfterDurationDelete(data) {

//    FriendlyMessage(data);

//    ResetDuration();

//    GetSightSeeingTariffDuration();
//}

function SightSeeingTariffDurationPagination(CurrentPage) {

    $('#tblSightSeeingTariffDuration').attr("data-current-page", CurrentPage);

    GetSightSeeingTariffDuration();
}

function GetSightSeeingTariffCustomerCategory() {

    var sstViewModel =
		{
		  
		}

    PostAjaxJson("/SightSeeingTariff/GetCustomerCategory", sstViewModel, BindSightSeeingTariffCustomerCategory);
}

function BindSightSeeingTariffCustomerCategory(data) {

    var list = JSON.parse(data);

    var myTable = $("#tblSightSeeingTariffCustomerCategory tbody");

    myTable.html("");

    var tblHtml = '';

    if (list.SightSeeingTariffCustomerCategories.length > 0) {
        for (var i = 0; i < list.SightSeeingTariffCustomerCategories.length; i++) {
            tblHtml += "<tr class='item-data-row'>";

            tblHtml += "<td>";
            tblHtml += "<label >" + list.SightSeeingTariffCustomerCategories[i].CustomerCategoryName + "</label>";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryname' name='SightSeeingTariffCustomerCategories[" + i + "].CustomerCategoryName' value='" + list.SightSeeingTariffCustomerCategories[i].CustomerCategoryName + "' id=hdnCustomerCategoryName_" + i + ">";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryid' name='SightSeeingTariffCustomerCategories[" + i + "].CustomerCategoryId' value='" + list.SightSeeingTariffCustomerCategories[i].CustomerCategoryId + "' id=hdnCustomerCategoryId_" + i + ">";
            tblHtml += "</td>";

            tblHtml += "<td>";
            tblHtml += "<input type='text' class='form-control input-sm' name='SightSeeingTariffCustomerCategories[" + i + "].GlobalMargin' value='" + list.SightSeeingTariffCustomerCategories[i].GlobalMargin + "' id=txtGlobalMargin_" + i + ">";
            tblHtml += "</td>";

            tblHtml += "</tr>";
        }
    }

    var newRow = $(tblHtml);

    myTable.append(newRow);

}