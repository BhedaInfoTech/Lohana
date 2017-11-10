
// Sightseeing Start

function SaveSightseeingEnquiryItem() {
 


    $("#frmSightseeingdetails").blur();

    var enqViewModel = {

        Enquiry: {

            EnquiryItemId: $("[name='Enquiry.EnquiryItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnEnquiryType").val(),

            Location: $("[name='Enquiry.location']").val(),

            SightseeingName: $("[name='Enquiry.sightseeingName']").val(),

            TravelDate: $("[name='Enquiry.travelDate']").val(),

            VehicleType: $("#drpvehicleType").val(),

            Budget: $("[name='Enquiry.budget']").val(),

            CountryId: $("[name='Enquiry.CountryId']").val(),

            StateId: $("[name='Enquiry.StateId']").val(),

            Cityid: $("[name='Enquiry.Cityid']").val(),

            AdultCount: $("[name='Enquiry.AdultCount']").val(),

            ChildCount: $("[name='Enquiry.ChildCount']").val(),

        },

    }

    debugger;

    //alert($("#hdnEnquiryId").val());

    //alert($("[name='Enquiry.EnquiryItemId']").val());

    var url = "";

    if ($("[name='Enquiry.EnquiryItemId']").val() == 0) {

        url = "/Enquiry/InsertEnquiryItem"
    }
    else {

        url = "/Enquiry/UpdateEnquirySightseeingDetails"
    }

    PostAjaxWithProcessJson(url, enqViewModel, AfterSightseeingSave, $("body"));
}

function AfterSightseeingSave(data) {

    FriendlyMessage(data);

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    //alert($("#hdnSightseeingId").val(data.Enquiry.EnquiryItemId));

    $("#hdnSightseeingId").val(data.Enquiry.EnquiryItemId);

    $("#hdnEnquiryType").val(data.Enquiry.EnquiryType);

    //alert($("#hdnEnquiryType").val(data.Enquiry.EnquiryType));

    GetEnquiryItemDetailsView();
    $("#modalParent").modal('hide');//To Close/Hide Common Modal
}

function GetSightseeingDetailsView() {

    $("#divEnquiryItemSightseeing").load("/Enquiry/GetSightseeingDetailsView", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val() }, null);
}





// Sightseeing End