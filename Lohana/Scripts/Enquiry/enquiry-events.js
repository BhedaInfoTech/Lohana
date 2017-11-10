$(document).ready(function ()
{

    GetAutocompleteScript("Enquiry");

    $("#dvEnquiryItem").hide();
    if ($("#drpenquiryAssignedType").val() == 1) {
        $("#dvHotelAssigneeName").hide();
    }
    if ($("#drpenquiryAssignedType").val() == 2) {
        $("#dvHotelAssigneeName").show();
    }
    else {
        $("#dvHotelAssigneeName").hide();
    }

    $("#divServices").hide();

    //$("#dvHotelAssigneeName").hide();

    $("#drpCustomerType").trigger("change");

    $("#drpenquiryAssignedType").trigger("change");

    $("#divOtherEnquiryBasic").hide();

    if ($("#hdnEnquiryId").val() == 0) {

        $("#dvEnquiryItem").hide();

        $("#divServices").hide();
    }
    else {

        $("#dvEnquiryItem").show();

        $("#divServices").show();

        $("#divOtherEnquiryBasic").show();
    }

    GetEnquiryItemDetailsView();

    $("#btnSaveEnquiry").click(function () {

        if ($("#frmEnquiryBaic").valid()) {

            SaveEnquiry();

            $("#divOtherEnquiryBasic").show();

            $("#dvEnquiryItem").show();

            $("#divServices").show();
        }

    });

    $("#divServices button,#divPlanServices1 button,#divPlanServices2 button").click(function () {

        $(this).addClass('active').siblings().removeClass('active');

        if ($(this).val() == 1) {
           

            LoadModal("/Enquiry/GetHotelDetails", null, null, "Hotel Details", null);
        }
        else if ($(this).val() == 2) {
         
            LoadModal("/Enquiry/GetAirplaneDetails", null, null, "Flight Details", null);

        }
        else if ($(this).val() == 3) {
         

            LoadModal("/Enquiry/GetTrainDetails", null, null, "Train Details", null);

        }
        else if ($(this).val() == 4) {
        

            LoadModal("/Enquiry/GetBusDetails", null, null, "Transfer Details", null);

        }
        else if ($(this).val() == 5) {
          

            LoadModal("/Enquiry/GetCarDetails", null, null, "Sightseeing Details", null);
        }
        else if ($(this).val() == 6) {
        

            LoadModal("/Enquiry/GetGitDetails", null, null, "Git Details", null);
        }
        else if ($(this).val() == 7) {
          

            LoadModal("/Enquiry/GetFitDetails", null, null, "Fit Details", null);
        }

        //else if ($(this).val() == 8) {

        //    LoadModal("/Enquiry/GetSupplierDetails", null, null, "Supplier Details", null);
        //}

    });

    $("#drpCustomerType").change(function () {
        if ($(this).val() == 1) {
           $("#dvCustomer").show();

            $("#dvAgent").hide();

            $("#dvGuest").hide();
        }
        else if ($(this).val() == 2) {
            $("#dvAgent").show();

            $("#dvCustomer").hide();

            $("#dvGuest").hide();
        }
        else {
            $("#dvGuest").show();

            $("#dvCustomer").hide();

            $("#dvAgent").hide();
        }
    });

    $("#btnViewEnquiryHistory").click(function () {

    });

    $("#drpenquiryAssignedType").change(function () {
        if ($(this).val() == 1) {
            $("#dvHotelAssigneeName").hide();
        }
        else {
            $("#dvHotelAssigneeName").show();
        }
    });

    $('#datepicker-autoclose').datepicker({
        autoclose: true,
        todayHighlight: true
    });

    //$("#btnSendToQuotation").click(function () {

    //    if ($("#hdnEnquiryId").val() != 0) {
    //        SaveTask();
    //    }  

    //});


  

});












//$(document).on("click", ".edit-button", function () {

//        alert("gettrainbyid");

//        var hdnenquiyitemid = ele.id;

//        var cnt = hdnenquiyitemid.substring(hdnenquiyitemid.indexOf('_') + 1);

//        alert($("#hdnEnquiryId").val());

//        alert($("#hdnEnquiryType").val());

//        alert($("#hdnTrainEnquiryItemId_" + cnt).val());

//        LoadModal("/Enquiry/GetTrainDetailsById", { EnquiryItemId: $("#hdnTrainEnquiryItemId_" + cnt).val() }, null, "Train Details", null);

//});

