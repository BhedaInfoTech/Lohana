// Train Start


function SaveTrainQuotationItem() {

    debugger;

    $("#frmquotationtraindetails").blur();

    var TrainTypeList = [];

    var traintype =

               {
                   QuotationItemTypeDetailsId: $("#hdnQuotationItemTypeDetailsId").val(),

                   TicketClass: $("[name='QuotationItemTypeDetails[0].TicketClass']").val(),

                   PickUpFrom: $("[name='QuotationItemTypeDetails[0].PickUpFrom']").val(),

                   DropTo: $("[name='QuotationItemTypeDetails[0].DropTo']").val(),

                   DepartureDate: $("[name='QuotationItemTypeDetails[0].DepartureDate']").val(),

                   ReturnDate: $("[name='QuotationItemTypeDetails[0].ReturnDate']").val(),

                   QuoteRate: $("[name='QuotationItemTypeDetails[0].QuoteRate']").val()

               }

    TrainTypeList.push(traintype);

    $("#divtrainType").find(".row").each(function () {

        var traintype =

                {
                    TicketClass: $(this).find(".train-ticket-class").val(),

                    PickUpFrom: $(this).find(".train-from").val(),

                    DropTo: $(this).find(".train-to").val(),

                    DepartureDate: $(this).find(".train-depart-on").val(),

                    ReturnDate: $(this).find(".train-depart-on").val()
                }

        TrainTypeList.push(traintype);
    });

    //alert(JSON.stringify(TrainTypeList));


    var TrainPassList = [];

    var trainpass =

               {
                   QuotationItemPassDetailsId: $("#hdnQuotationItemPassDetailsId").val(),

                   Region: $("[name='QuotationItemPassDetails[0].Region']").val(),

                   PassType: $("[name='QuotationItemPassDetails[0].PassType']").val(),

                   RailPass: $("[name='QuotationItemPassDetails[0].RailPass']").val(),

                   RailClass: $("[name='QuotationItemPassDetails[0].RailClass']").val(),

                   NoOfDays: $("[name='QuotationItemPassDetails[0].NoOfDays']").val(),

                   QuoteRate: $("[name='QuotationItemPassDetails[0].QuoteRate']").val()

               }

    TrainPassList.push(trainpass);

    $("#divtrainPass").find(".row").each(function () {

        var trainpass =

                {
                    Region: $(this).find(".train-region").val(),

                    PassType: $(this).find(".train-pass-type").val(),

                    RailPass: $(this).find(".train-rail-pass").val(),

                    RailClass: $(this).find(".train-rail-class").val(),

                    NoOfDays: $(this).find(".train-no-of-days").val(),
                }

        TrainPassList.push(trainpass);
    });

   // alert(JSON.stringify(TrainPassList));

    var qViewModel = {

        Quotation: {

            QuotationItemId: $("[name='Quotation.QuotationItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnQuotationType").val(),

            EnquiryItemId: $("#hdnEnquiryItemId").val(),

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

            QuotationItemPassDetail:

                 {

                     QuotationItemPassDetailsId: $("#hdnQuotationItemPassDetailsId").val(),

                     Region: $("[name='QuotationItemPassDetails[0].Region']").val(),

                     PassType: $("[name='QuotationItemPassDetails[0].PassType']").val(),

                     RailPass: $("[name='QuotationItemPassDetails[0].RailPass']").val(),

                     RailClass: $("[name='QuotationItemPassDetails[0].RailClass']").val(),

                     NoOfDays: $("[name='QuotationItemPassDetails[0].NoOfDays']").val(),

                     QuoteRate: $("[name='QuotationItemPassDetails[0].QuoteRate']").val()

                 },

            QuotationItemTypeDetails: TrainTypeList,

            QuotationItemPassDetails: TrainPassList

        }


    }

    var url = "";

    if ($("[name='Quotation.QuotationItemId']").val() == 0) {

        url = "/Quotation/InsertTrainQuotationItem"
    }
    else {

        url = "/Quotation/UpdateQuotationTrainDetails"
    }

   // alert(JSON.stringify(qViewModel));

    PostAjaxWithProcessJson(url, qViewModel, AfterQuotationTrainSave, $("body"));
}

function AfterQuotationTrainSave(data) {

    //alert(data);

    FriendlyMessage(data);

    //alert("AfterFlightSave")

   // alert($("#hdnQuotationId").val(data.Quotation.QuotationId));

    $("#hdnQuotationId").val(data.Quotation.QuotationId);

    //alert($("#hdnFlightId").val(data.Enquiry.EnquiryItemId));

    $("#hdnTrainId").val(data.Quotation.QuotationItemId);

    $("#hdnQuotationType").val(data.Quotation.EnquiryType);

    //alert(data.Enquiry.EnquiryType);

    GetEnquiryItemDetailsView();

}


// Train End