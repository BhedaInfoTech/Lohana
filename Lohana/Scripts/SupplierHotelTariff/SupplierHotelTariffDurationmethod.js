function SaveSupplierHotelTariffDuration() {
    
$("#frmSupplierHotelTariffduration").blur();

    var sViewModel = SupplierHoteTariffViewModel();

    var url = "";

    PostAjaxJson("/SupplierHotelTariff/IsOverrideDate", sViewModel, function (data) {

         AfterIsOverrideDate(data, sViewModel);

    });

}

function SupplierHoteTariffViewModel() {

    var days = [];
    var customerCategoriesList = [];

    $(".item-data-row").each(function (i) {


        var customerCategories = {

            CustomerCategoryId: $("#hdnCustomerCategoryId_" + i).val(),

            Margin: $("#txtGlobalMargin_" + i).val()

        }

        customerCategoriesList.push(customerCategories);
    });

    //alert(JSON.stringify(customerCategoriesList));

    $('input[name="SupplierHotelDuration.OperationalDays"]:checked').each(function (i) {
        days.push($(this).val())
    });

    var DaysValue = days.join();

    var sViewModel = {

        SupplierHotelCustomerCategories: customerCategoriesList,

        SupplierHotelDuration: {

            SupplierHotelPriceId: $("[name='SupplierHotelDuration.SupplierHotelPriceId']").val(),

            OccupancyDetailId: $("[name='SupplierHotelPrice.OccupancyDetailId']").val(),

            FromDate: $("[name='SupplierHotelDuration.FromDate']").val(),

            ToDate: $("[name='SupplierHotelDuration.ToDate']").val(),

            OperationalDays: DaysValue,

            //NoOfNight: $("[name='HotelTariffRoom.NoOfNight']").val()
        }

    }

    return sViewModel;

}

function AfterIsOverrideDate(data, sViewModel) {

   
    if (data == true) {
        DisplayConformationPopup("Some date's price may get override, Do you want to procced ?", "ti-view-list-alt", "Conformation", function () {
            PostAjaxJson("/SupplierHotelTariff/SaveSupplierHotelTariffDurationWithCustomerCategories", sViewModel, AfterDurationSave);

        }, null);
    }
    else {
        PostAjaxJson("/SupplierHotelTariff/SaveSupplierHotelTariffDurationWithCustomerCategories", sViewModel, AfterDurationSave);
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
    $("[name='SupplierHotelDuration.SupplierHotelPriceId']").html("");

    $("#txtFromDate").val('');

    $("#txtToDate").val('');

    $('[name="SupplierHotelDuration.OperationalDays"]').removeAttr('checked');

    $("#drpAllWeekWeekEnd").val("none");

}

function GetSetSupplierHotelTariffDurationValues(obj) {

    var id = $(obj).attr("data-supplierhoteldurationid");

    var hoteltariffid = $(obj).attr("data-supplierhoteltariffid");

    //var noofnight = $(obj).attr("data-noofnight");

    var fromdate = $(obj).attr("data-fromdate");

    var todate = $(obj).attr("data-todate");

    var operationaldays = $(obj).attr("data-operationaldays");

    operationaldaysValues = operationaldays.split(',');

    for (i = 0; i < operationaldaysValues.length; i++) {

        document.getElementById("chkDays" + operationaldaysValues[i]).checked = true;
    }


    $("[name='SupplierHotelDuration.SupplierHotelTariffId']").val(supplierhoteltariffid),

    //$("[name='HotelTariffDuration.NoOfNight']").val(noofnight),

    $("[name='SupplierHotelDuration.FromDate']").val(fromdate),

    $("[name='SupplierHotelDuration.ToDate']").val(todate),

    //$("#lblNoOfNight").text(noofnight),

    $("#lblFromDate").text(fromdate + " " + "to" + " " + todate),

    $("#lblOperationalDays").text(operationaldays),

    $("[name='HotelTariffRoom.HotelTariffDurationDetailsId']").val(id),

    $("[name='HotelTariffRoom.HotelTariffId']").val(hoteltariffid),

    //for PriceDetails

     //$("[name='HotelTariffPrice.NoOfNight']").val(noofnight),

      $("[name='HotelTariffPrice.HotelTariffDurationDetailsId']").val(id),

       $("[name='HotelTariffPrice.HotelTariffId']").val(hoteltariffid),

     $("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val(id)

    ResetRoom();

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
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryname' name='SupplierCustomerCategories[" + i + "].CustomerCategoryName' value='" + list.HotelTariffCustomerCategories[i].CustomerCategoryName + "' id=hdnCustomerCategoryName_" + i + ">";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryid' name='SupplierCustomerCategories[" + i + "].CustomerCategoryId' value='" + list.HotelTariffCustomerCategories[i].CustomerCategoryId + "' id=hdnCustomerCategoryId_" + i + ">";
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





