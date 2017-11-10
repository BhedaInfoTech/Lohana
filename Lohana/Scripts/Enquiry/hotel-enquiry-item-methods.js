
// Hotel Details Start

function SaveHotelEnquiryItem() {

    $("#frmHoteldetails").blur();

    var enqViewModel = {

        Enquiry: {

            EnquiryItemId: $("[name='Enquiry.EnquiryItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnEnquiryType").val(),

            CountryId: $("#drpCountry").val(),

            StateId: $("#drpState").val(),

            CityId: $("#drpCity").val(),

            CheckInDate: $("[name='Enquiry.CheckInDate']").val(),

            CheckOutDate: $("[name='Enquiry.CheckOutDate']").val(),

            Budget: $("[name='Enquiry.budget']").val(),

            StarCategory: $("#drpstarCategory").val(),

            HotelTypeId: $("#drphotelType").val(),

            HotelName: $("[name='Enquiry.HotelName']").val(),

            RoomType: $("#drproomType").val(),

            AdultCount: $("#txtAdultCount").val(),

            RoomCount: $("#txtroomCount").val(),

            CXBCount: $("[name='Enquiry.cxbCount']").val(),

            CXBAge: $("[name='Enquiry.cxbAge']").val(),

            CNBCount: $("[name='Enquiry.cnbCount']").val(),

            CNBAge: $("[name='Enquiry.CNBAge']").val(),

           

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

        url = "/Enquiry/UpdateEnquiryHotelDetails"
    }

    PostAjaxWithProcessJson(url, enqViewModel, AfterHotelSave, $("body"));
}

function AfterHotelSave(data) {

    FriendlyMessage(data);

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    //alert($("#hdnHotelId").val(data.Enquiry.EnquiryItemId));

    $("#hdnHotelId").val(data.Enquiry.EnquiryItemId);

    $("#hdnEnquiryType").val(data.Enquiry.EnquiryType);

    //alert($("#hdnEnquiryType").val(data.Enquiry.EnquiryType));

    GetEnquiryItemDetailsView();
    $("#modalParent").modal('hide');//To Close/Hide Common Modal
}

function GetHotelDetailsView() {

    $("#divEnquiryItemHotel").load("/Enquiry/GetHotelDetailsView", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val() }, null);
}




// Hotel Details End