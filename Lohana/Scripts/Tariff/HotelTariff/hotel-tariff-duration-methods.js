

function SaveHotelTariffDuration() {

    $("#frmHotelTariffduration").blur();

    var htViewModel = HoteTariffViewModel();

    var url = "";

    PostAjaxJson("/HotelTariff/IsOverrideDate", htViewModel, function (data) {
        //alert(data);

        AfterIsOverrideDate(data, htViewModel);

    });

}

function HoteTariffViewModel() {
    
    var days = [];

    var customerCategoriesList = [];

    $(".item-data-row").each(function (i) {

       
        var customerCategories = {

            CustomerCategoryId: $("#hdnCustomerCategoryId_" + i).val(),

            GlobalMargin: $("#txtGlobalMargin_" + i).val()

        } 
     
        customerCategoriesList.push(customerCategories);
    });

    $('input[name="HotelTariffDuration.OperationalDays"]:checked').each(function (i) {
        days.push($(this).val())
    });

    var DaysValue = days.join();

    var htViewModel = {

        HotelTariffCustomerCategories: customerCategoriesList,

        HotelTariffDuration: {

            HotelTariffPriceDetailsId: $("[name='HotelTariffDuration.HotelTariffPriceDetailsId']").val(),

            HotelTariffRoomOccupancyId: $("[name='HotelTariffPrice.HotelTariffRoomOccupancyId']").val(),

            FromDate: $("[name='HotelTariffDuration.FromDate']").val(),

            ToDate: $("[name='HotelTariffDuration.ToDate']").val(),

            OperationalDays: DaysValue,

            NoOfNight: $("[name='HotelTariffRoom.NoOfNight']").val()
        }
         
    }

    return htViewModel;
}

function AfterIsOverrideDate(data, htViewModel) {
    if (data == true) {
        DisplayConformationPopup("Some date's price may get override, Do you want to procced ?", "ti-view-list-alt", "Conformation", function () {
            PostAjaxJson("/HotelTariff/SaveHotelTariffDurationWithCustomerCategories", htViewModel, AfterDurationSave);

        }, null);
    }
    else {
        PostAjaxJson("/HotelTariff/SaveHotelTariffDurationWithCustomerCategories", htViewModel, AfterDurationSave);
    }
}

function AfterDurationSave(data) {

    FriendlyMessagePopup(data);

    ResetDuration();

    GetHotelTariffDuration($("#dvcalendar1"));

    GetHotelTariffDuration($("#dvcalendar"));

    GetHotelTariffCustomerCategory();

}

function ResetDuration() {
    $("[name='HotelTariffDuration.HotelTariffPriceDetailsId']").html("");

    $("#txtFromDate").val('');

    $("#txtToDate").val('');

    $('[name="HotelTariffDuration.OperationalDays"]').removeAttr('checked');

    $("#drpAllWeekWeekEnd").val("none");

}



function GetSetHotelTariffDurationValues(obj) {

    var id = $(obj).attr("data-hoteltariffdurationdetailsid");

    var hoteltariffid = $(obj).attr("data-hoteltariffid");

    var noofnight = $(obj).attr("data-noofnight");

    var fromdate = $(obj).attr("data-fromdate");

    var todate = $(obj).attr("data-todate");

    var operationaldays = $(obj).attr("data-operationaldays");

    operationaldaysValues = operationaldays.split(',');

    for (i = 0; i < operationaldaysValues.length; i++) {

        document.getElementById("chkDays" + operationaldaysValues[i]).checked = true;
    }


    $("[name='HotelTariffDuration.HotelTariffId']").val(hoteltariffid),

    $("[name='HotelTariffDuration.NoOfNight']").val(noofnight),

    $("[name='HotelTariffDuration.FromDate']").val(fromdate),

    $("[name='HotelTariffDuration.ToDate']").val(todate),

    $("#lblNoOfNight").text(noofnight),

    $("#lblFromDate").text(fromdate + " " + "to" + " " + todate),

    $("#lblOperationalDays").text(operationaldays),

    $("[name='HotelTariffRoom.HotelTariffDurationDetailsId']").val(id),

    $("[name='HotelTariffRoom.HotelTariffId']").val(hoteltariffid),

    //for PriceDetails

     $("[name='HotelTariffPrice.NoOfNight']").val(noofnight),

      $("[name='HotelTariffPrice.HotelTariffDurationDetailsId']").val(id),

       $("[name='HotelTariffPrice.HotelTariffId']").val(hoteltariffid),

     $("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val(id)

    ResetRoom();

}

function DeleteDuration() {

    var htViewModel =
      {

          HotelTariffDuration: {

              HotelTariffDurationDetailsId: $("[name='HotelTariffDurationFilter.HotelTariffDurationDetailsId']").val(),

              HotelTariffId: $("[name='HotelTariffDuration.HotelTariffId']").val(),

          },
          Pager: {

              CurrentPage: $('#tblHotelTariffDurationDetails').attr("data-current-page"),
          },
      }

    PostAjaxJson("/HotelTariff/DeleteDuration", htViewModel, AfterDurationDelete);

}

function AfterDurationDelete(data) {

    FriendlyMessage(data);

    ResetDuration();

    GetHotelTariffDuration();
}

function HotelTariffDurationPagination(CurrentPage) {

    $('#tblHotelTariffDurationDetails').attr("data-current-page", CurrentPage);

    GetHotelTariffDuration();
}

function GetHotelTariffCustomerCategory() {

    var htViewModel =
		{
		    //HotelTariffCustomerCategory: {

		    //    HotelTariffDurationDetailsId: $("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val(),

		    //    HotelTariffRoomOccupancyId: $("[name='HotelTariffCustomerCategory.HotelTariffRoomOccupancyId']").val(),

		    //},
		    //Pager: {

		    //    CurrentPage: $('#tblHotelTariffCustomerCategory').attr("data-current-page"),
		    //},
		}

    PostAjaxJson("/HotelTariff/GetCustomerCategory", htViewModel, BindHotelTariffCustomerCategory);
}

function BindHotelTariffCustomerCategory(data) {

    var list = JSON.parse(data);

    var myTable = $("#tblHotelTariffCustomerCategory tbody");

    myTable.html("");

    var tblHtml = '';

    if (list.HotelTariffCustomerCategories.length > 0) {
        for (var i = 0; i < list.HotelTariffCustomerCategories.length; i++) {
            tblHtml += "<tr class='item-data-row'>";

            //tblHtml += "<td>";
            //tblHtml += "<input type='radio' name='c1' value='" + list.HotelTariffCustomerCategories[i].CustomerCategoryId + "'>";
            //tblHtml += "</td>";

            tblHtml += "<td>";
            tblHtml += "<label >" + list.HotelTariffCustomerCategories[i].CustomerCategoryName + "</label>";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryname' name='HotelTariffCustomerCategories[" + i + "].CustomerCategoryName' value='" + list.HotelTariffCustomerCategories[i].CustomerCategoryName + "' id=hdnCustomerCategoryName_" + i + ">";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryid' name='HotelTariffCustomerCategories[" + i + "].CustomerCategoryId' value='" + list.HotelTariffCustomerCategories[i].CustomerCategoryId + "' id=hdnCustomerCategoryId_" + i + ">";
            tblHtml += "</td>";

            tblHtml += "<td>"; 
            tblHtml += "<input type='text' class='form-control input-sm' name='HotelTariffCustomerCategories[" + i + "].GlobalMargin' value='" + list.HotelTariffCustomerCategories[i].GlobalMargin + "' id=txtGlobalMargin_" + i + ">";
            tblHtml += "</td>";
                        
            tblHtml += "</tr>";
        }
    }

    var newRow = $(tblHtml);

    myTable.append(newRow);
      
}


