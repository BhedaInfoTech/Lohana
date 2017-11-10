// Flight Start


function SaveFlightQuotationItem() {

    debugger;

    $("#frmquotationflightdetails").blur();

    var FlightTypeList = [];

    var flighttype =

               {
                   QuotationItemTypeDetailsId: $("#hdnQuotationItemTypeDetailsId").val(),

                   TicketClass: $("[name='QuotationItemTypeDetails[0].TicketClass']").val(),

                   PickUpFrom: $("[name='QuotationItemTypeDetails[0].PickUpFrom']").val(),

                   DropTo: $("[name='QuotationItemTypeDetails[0].DropTo']").val(),

                   DepartureDate: $("[name='QuotationItemTypeDetails[0].DepartureDate']").val(),

                   ReturnDate: $("[name='QuotationItemTypeDetails[0].ReturnDate']").val(),

                   QuoteRate: $("[name='QuotationItemTypeDetails[0].QuoteRate']").val()

               }

    FlightTypeList.push(flighttype);

    $("#divflightType").find(".row").each(function () {

        var flighttype =

                {
                    TicketClass: $(this).find(".flight-ticket-class").val(),

                    PickUpFrom: $(this).find(".flight-from").val(),

                    DropTo: $(this).find(".flight-to").val(),

                    DepartureDate: $(this).find(".flight-depart-on").val(),

                    QuoteRate: $(this).find(".flight-quote-rate").val(),
                }

        FlightTypeList.push(flighttype);
    });

  //  alert(JSON.stringify(FlightTypeList));


    var qViewModel = {

        Quotation: {

            QuotationItemId: $("[name='Quotation.QuotationItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnQuotationType").val(),

            EnquiryItemId: $("#hdnEnquiryItemId").val(),

            QuotationFlightType: $('input[name="Quotation.FlightType"]:checked').val(),

            AdultCount: $("[name='Quotation.adultCount']").val(),

            ChildCount: $("[name='Quotation.childCount']").val(),

            InfantCount: $("[name='Quotation.infantCount']").val(),

            Budget: $("[name='Quotation.netRate']").val(),

            QuotationItemTypeDetail:

        {

            QuotationItemTypeDetailsId: $("#hdnQuotationItemTypeDetailsId").val(),

            TicketClass: $("[name='QuotationItemTypeDetails[0].TicketClass']").val(),

            PickUpFrom: $("[name='QuotationItemTypeDetails[0].PickUpFrom']").val(),

            DropTo: $("[name='QuotationItemTypeDetails[0].DropTo']").val(),

            DepartureDate: $("[name='QuotationItemTypeDetails[0].DepartureDate']").val(),

            ReturnDate: $("[name='QuotationItemTypeDetails[0].ReturnDate']").val(),

            QuoteRate: $("[name='QuotationItemTypeDetails[0].QuoteRate']").val()

        },


            QuotationItemTypeDetails: FlightTypeList

        }
    }

    var url = "";

    if ($("[name='Quotation.QuotationItemId']").val() == 0) {

        url = "/Quotation/InsertFlightQuotationItem"
    }
    else {

        url = "/Quotation/UpdateQuotationFlightDetails"
    }

  //  alert(JSON.stringify(qViewModel));

    PostAjaxWithProcessJson(url, qViewModel, AfterQuotationFlightSave, $("body"));
}

function AfterQuotationFlightSave(data) {

    //alert(data);

    FriendlyMessage(data);

    //alert("AfterFlightSave")

   // alert($("#hdnQuotationId").val(data.Quotation.QuotationId));

    $("#hdnQuotationId").val(data.Quotation.QuotationId);



    //alert($("#hdnFlightId").val(data.Enquiry.EnquiryItemId));

    $("#hdnFlightId").val(data.Quotation.QuotationItemId);

    $("#hdnQuotationType").val(data.Quotation.EnquiryType);

    //alert(data.Enquiry.EnquiryType);

    GetEnquiryItemDetailsView();

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