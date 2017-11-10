
function GetCustomerCategoryDetailsById(id) {

    var vtViewModel =
        {
            VehicleTariffCustomerCategory: {

                CustomerCategoryId: id
            }
        }

    $.ajax({

        url: "/VehicleTariff/GetCustomerCategoryDetailsById",

        data: JSON.stringify(vtViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (data) {

            if (data != null) {

                $('#txtCustomerMargin').val(data[0].Margin);

            }

            //CalculateTotalAmountOnMargin();
        }
    });
}

function SaveVehicleTariffCustomerCategoryDetails() {

    $("#frmVehicleTariffCustomerCategoryDetails").blur();
    var list = [];
    debugger;
    $("#tblHotelTariffCustomerCategory tr").each(function (e) {
        var VehicleTariffCustomerCategory = {

            CustomerCategoryId: $("[name='VehicleTariffCustomerCategories[" + e + "].CustomerCategoryId']").val(),
            Margin: $("[name='VehicleTariffCustomerCategories[" + e + "].Margin']").val(),
            VehicleTariffId: $("[name='VehicleTariff.VehicleTariffBasicDetailsId']").val(),
            VehicleTariffCustomerCategoryDetailsId: $("[name='VehicleTariffCustomerCategories[" + e + "].VehicleTariffCustomerCategoryDetailsId']").val(),
        }
        list.push(VehicleTariffCustomerCategory);
    })

    

    var vtViewModel = {

        VehicleTariffCustomerCategories:list,
    }

    debugger;


    var url = "";

    if ($("#hdnSearchVehicleTariffCustomerCategoryId").val() == 0) {

        url = "/VehicleTariff/InsertVehicleTariffCustomerCategoryDetails"
    }
    else {
        url = "/VehicleTariff/UpdateVehicleTariffCustomerCategoryDetails"
    }


    PostAjaxWithProcessJson(url, vtViewModel, AfterSaveCustomerCategory);
}

function AfterSaveCustomerCategory(data) {

    FriendlyMessage(data);

    ResetVehicleTariffCustomerCategoryDetails();

    GetVehicleTariffCustomerCategoryDetails();
}

function GetVehicleTariffCustomerCategoryDetails() {

    var vtViewModel =
		{
		    VehicleTariffCustomerCategory: {

		        VehicleTariffId: $("#hdnVehicleTariffBasicDetailsId").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblVehicleTariffCustomerCategoryDetails').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/VehicleTariff/GetVehicleTariffCustomerCategoryDetails", vtViewModel, BindVehicleTariffCustomerCategoryDetails, $("#frmVehicleTariffCustomerCategoryDetails"));
}

function BindVehicleTariffCustomerCategoryDetails(data) {

    var list = JSON.parse(data);

    var myTable = $("#tblHotelTariffCustomerCategory tbody");

    myTable.html("");

    var tblHtml = '';

    if (list.dt.length > 0) {
        for (var i = 0; i < list.dt.length; i++) {
            tblHtml += "<tr class='item-data-row'>";

            tblHtml += "<td>";
            tblHtml += "<label >" + list.dt[i].CustomerCategoryName + "</label>";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryname' name='VehicleTariffCustomerCategories[" + i + "].CustomerCategoryName' value='" + list.dt[i].CustomerCategoryName + "' id=hdnCustomerCategoryName_" + i + ">";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryid' name='VehicleTariffCustomerCategories[" + i + "].CustomerCategoryId' value='" + list.dt[i].CustomerCategoryId + "' id=hdnCustomerCategoryId_" + i + ">";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryid' name='VehicleTariffCustomerCategories[" + i + "].VehicleTariffCustomerCategoryDetailsId' value='" + list.dt[i].VehicleTariffCustomerCategoryDetailsId + "' id=hdnVehicleTariffCustomerCategoryDetailsId_" + i + ">";
            tblHtml += "</td>";

            tblHtml += "<td>";
            tblHtml += "<input type='text' class='form-control input-sm' name='VehicleTariffCustomerCategories[" + i + "].Margin' value='" + list.dt[i].Margin + "' id='txtGlobalMargin_" + i + "'>";
            tblHtml += "</td>";

            tblHtml += "</tr>";
        }
    }

    var newRow = $(tblHtml);

    myTable.append(newRow);


    /*var kTable = {
        dataList: ["CustomerCategoryName", "Margin"],
        primayKey: "VehicleTariffCustomerCategoryDetailsId",
        hiddenFields: ["VehicleTariffCustomerCategoryDetailsId", "CustomerCategoryId", "CustomerCategoryName", "Margin"],
        headerNames: ["CustomerCategory", "Margin"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVehicleTariffCustomerCategoryDetails'));

    BindPagination(list.Pager, $('#tblVehicleTariffCustomerCategoryDetails'), "VehicleTariffCustomerCategoryPagination");*/



}

function ResetVehicleTariffCustomerCategoryDetails() {

    /*$("#drpCustomerCategory").val(0);

    $("[name='VehicleTariff.CustomerMargin']").val("");

    //$("[name='VehicleTariff.CalculatedTotalAmount']").val("");

    $("[name='VehicleTariffCustomerCategoryFilter.VehicleTariffCustomerCategoryDetailsId']").val("");*/
    $("[name='VehicleTariffCustomerCategories[0].Margin']").val(0);
    $("[name='VehicleTariffCustomerCategories[1].Margin']").val(0);
    $("[name='VehicleTariffCustomerCategories[2].Margin']").val(0);
    $("[name='VehicleTariffCustomerCategories[3].Margin']").val(0);
    $("[name='VehicleTariffCustomerCategories[4].Margin']").val(0);
    $("[name='VehicleTariffCustomerCategories[5].Margin']").val(0);
 
}

function VehicleTariffCustomerCategoryPagination(CurrentPage) {



    $('#tblVehicleTariffCustomerCategoryDetails').attr("data-current-page", CurrentPage);

    GetVehicleTariffCustomerCategoryDetails();

}

function GetSetVehicleTarifCustomerCategoryDetails(obj) {

    var id = $(obj).attr("data-vehicletariffcustomercategorydetailsid");

    var customerCategoryId = $(obj).attr("data-customercategoryid");

    var customerCategoryName = $(obj).attr("data-customercategoryname");

    var margin = $(obj).attr("data-margin");

    //var totalAmount = $(obj).attr("data-totalamount");

    $("#hdnSearchVehicleTariffCustomerCategoryId").val(id);

    $("#drpCustomerCategory").val(customerCategoryId);

    $("[name='VehicleTariff.CustomerMargin']").val(margin);

    //$("[name='VehicleTariff.CalculatedTotalAmount']").val(totalAmount);

}

function DeleteVehicleTariffCustomerCategoryDetails() {

    var vtViewModel =
      {
          VehicleTariffCustomerCategory: {

              VehicleTariffCustomerCategoryDetailsId: $("[name='VehicleTariffCustomerCategoryFilter.VehicleTariffCustomerCategoryDetailsId']").val(),

              VehicleTariffId: $("[name='VehicleTariff.VehicleTariffBasicDetailsId']").val()
          },

          Pager:
          {
              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/VehicleTariff/DeleteVehicleTariffCustomerCategoryDetails", vtViewModel, AfterDeleteCustomerCategory);

    $("[name='VehicleTariffCustomerCategoryFilter.VehicleTariffCustomerCategoryDetailsId']").val('');

}


function AfterDeleteCustomerCategory(data) {

    FriendlyMessage(data);

    ResetVehicleTariffCustomerCategoryDetails();

    GetVehicleTariffCustomerCategoryDetails();
}


//Not Required

//function CalculateTotalAmountOnMargin()
//{

//    debugger;

//    var kmAmt = parseFloat($("#hdnKmAmount").val());

//    var rupeesPerExtraKm = parseFloat($("#hdnRupeesPerExtraKm").val());

//    var hoursAmount = parseFloat($("#hdnHoursAmount").val());

//    var rupeesPerExtraHours = parseFloat($("#hdnRupeesPerExtraHours").val());

//    var packageAmount = parseFloat($("#hdnPackageAmount").val());

//    var margin = parseFloat($("#txtCustomerMargin").val());

//    var totalAmount = ((kmAmt + rupeesPerExtraKm + hoursAmount + rupeesPerExtraHours + packageAmount) * margin) / 100;

//    $("#txtCalcualtedTotalAmount").val(totalAmount.toFixed(2));

//}
