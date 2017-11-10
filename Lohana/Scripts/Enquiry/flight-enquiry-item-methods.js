// Flight Start


function SaveFlightEnquiryItem() {

    debugger;

    $("#frmflightdetails").blur();

    var FlightTypeList = [];

    var flighttype =

               {
                   TicketClass: $("[name='EnquiryItemTypeDetails[0].TicketClass']").val(),

                   PickUpFrom: $("[name='EnquiryItemTypeDetails[0].PickUpFrom']").val(),

                   DropTo: $("[name='EnquiryItemTypeDetails[0].DropTo']").val(),

                   DepartureDate: $("[name='EnquiryItemTypeDetails[0].DepartureDate']").val(),

                   ReturnDate: $("[name='EnquiryItemTypeDetails[0].ReturnDate']").val()

               }

    FlightTypeList.push(flighttype);

    $("#divflightType").find(".row").each(function () {

        var flighttype =

                {
                    TicketClass: $(this).find(".flight-ticket-class").val(),

                    PickUpFrom: $(this).find(".flight-from").val(),

                    DropTo: $(this).find(".flight-to").val(),

                    DepartureDate: $(this).find(".flight-depart-on").val(),
                }

        FlightTypeList.push(flighttype);
    });

    //alert(JSON.stringify(FlightTypeList));


    var enqViewModel = {

        Enquiry: {

            EnquiryItemId: $("[name='Enquiry.EnquiryItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnEnquiryType").val(),

            EnquiryFlightType: $('input[name="Enquiry.FlightType"]:checked').val(),

            AdultCount: $("[name='Enquiry.adultCount']").val(),

            ChildCount: $("[name='Enquiry.childCount']").val(),

            InfantCount: $("[name='Enquiry.infantCount']").val(),

            Budget: $("[name='Enquiry.budget']").val(),

            EnquiryAssignedType: $("#drpenquiryAssignedType").val(),

            EnquiryAssigneeName: $("[name='Enquiry.assigneName']").val(),

            EnquiryItemTypeDetails: FlightTypeList

        }
    }

    //alert($("[name='Enquiry.assigneName']").val());

    //alert($("[name='Enquiry.childCount']").val());

    //alert($("#hdnEnquiryId").val());

    //alert($("[name='Enquiry.EnquiryItemId']").val());

    var url = "";

    if ($("[name='Enquiry.EnquiryItemId']").val() == 0) {

        url = "/Enquiry/InsertFlightEnquiryItem"
    }
    else {

        url = "/Enquiry/UpdateEnquiryFlightDetails"
    }

    //alert(JSON.stringify(enqViewModel));

    PostAjaxWithProcessJson(url, enqViewModel, AfterFlightSave, $("body"));
}

function AfterFlightSave(data) {

    //alert(data);

    FriendlyMessage(data);

    //alert("AfterFlightSave")

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    //alert($("#hdnFlightId").val(data.Enquiry.EnquiryItemId));

    $("#hdnFlightId").val(data.Enquiry.EnquiryItemId);

    $("#hdnEnquiryType").val(data.Enquiry.EnquiryType);

    //alert(data.Enquiry.EnquiryType);

    GetEnquiryItemDetailsView();
    $("#modalParent").modal('hide');//To Close/Hide Common Modal
}

function GetFlightDetailsView() {

    //alert("flight");

    debugger;

    $("#divEnquiryItemFlight").load("/Enquiry/GetFlightDetailsView", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val() }, null);

}

function DeleteFlightDetailsData(rowId) {

    $("#tblFlightDetails").find("[id='tr" + rowId + "']").remove();

    ReArrangeFlightDetailsData();
}

function ReArrangeFlightDetailsData() {

    var i = 1;

    $("#divflightType").find(".row").each(function () {

        $(this).find(".flight-ticket-class").attr("name", "EnquiryItemTypeDetails[" + i + "].TicketClass");

        $(this).find(".flight-from").attr("name", "EnquiryItemTypeDetails[" + i + "].PickUpFrom");

        $(this).find(".flight-to").attr("name", "EnquiryItemTypeDetails[" + i + "].DropTo");

        $(this).find(".flight-depart-on").attr("name", "EnquiryItemTypeDetails[" + i + "].DepartureDate");

        i++;
    });
}


// Flight End