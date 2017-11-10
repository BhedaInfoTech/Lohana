
function SaveEnquiry() {

    $("#frmEnquiryBaic").blur();

    var enqViewModel = {

        Enquiry: {

            EnquiryId: $("#hdnEnquiryId").val(),

            CustomerType: $("#drpCustomerType").val(),

            CustomerId: $("[name='Enquiry.CustomerName']").val(),

            VendorId: $("[name='Enquiry.AgentName']").val(),

            GuestName: $("[name='Enquiry.GuestName']").val(),

            GuestEmail: $("[name='Enquiry.GuestEmail']").val(),

            GuestMobileNo: $("[name='Enquiry.GuestMobNo']").val(),

            EnquirySource: $("#drpSourceEnquiry").val(),

            EnquiryPriority: $("#drpPriority").val(),

            EnquiryStatus: $("#drpStatus").val(),

            EnquiryTicketDeliveryType: $("#drpticketDeliveryType").val(),

            BestTimeToReachYou: $("[name='Enquiry.bestTimeToReachYou']").val(),

            AdditionalInformation: $("[name='Enquiry.additionalInfo']").val(),

            FollowupDate: $("[name='Enquiry.enquiryFollowupDate']").val(),

            EnquiryAssignedType: $("#drpenquiryAssignedType").val(),

            EnquiryAssigneeName: $("#drpassigneName").val(),

            EnquiryTypeID: $("#drpEnquiryType").val(),

            SpecializationId: $("#drpSpecialization").val(),

        }
    }

   // alert($("#txtEnquiryVersion").val());

    debugger;

    var url = "";

    if ($("[name='Enquiry.EnquiryId']").val() == 0) {

        url = "/Enquiry/Insert"
    }
    else {

        url = "/Enquiry/Update"
    }

    PostAjaxWithProcessJson(url, enqViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    debugger;

    //alert(data.Enquiry.EnquiryId);

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    GetEnquiryItemDetailsView();

     //$("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

   // ResetEnquiry();

}

function ResetEnquiry() {

    $("#drpCustomerType").val("");

    $("[name='Enquiry.CustomerName']").val("");

    $("[name='Enquiry.AgentName']").val("");

    $("[name='Enquiry.GuestName']").val("");

    $("[name='Enquiry.GuestEmail']").val("");

    $("[name='Enquiry.GuestMobNo']").val("");

    $("#drpversion").val("");

    $("#drpSourceEnquiry").val("");

    $("#drpPriority").val("");

    $("#drpStatus").val("");

    $("#drpticketDeliveryType").val("");

    $("[name='Enquiry.bestTimeToReachYou']").val("");

    $("[name='Enquiry.additionalInfo']").val("");

    $("[name='Enquiry.enquiryFollowupDate']").val("");

}

function GetEnquiryItemDetailsView() {

    //alert("bfbas");

    //alert($("#hdnEnquiryId").val());

    debugger;

    $("#dvEnquiryItem").load("/Enquiry/GetEnquiryItemDetailsView", { EnquiryId: $("#hdnEnquiryId").val() }, null);


}

//function SaveTask() {

//    var enqViewModel = {

//        Enquiry: {

//            EnquiryId: $("#hdnEnquiryId").val(),
//        }
//    }

//    var url = "";

//    url = "/Enquiry/SaveTask"

//   // PostAjaxWithProcessJson(url, enqViewModel, AfterSaveTask, $("body"));
//}

//function AfterSaveTask(data)
//{
//    FriendlyMessage(data);
 

//}

