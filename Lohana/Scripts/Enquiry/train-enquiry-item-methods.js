

///// Train Start


function SaveTrainEnquiryItem() {

    debugger;

    $("#frmtraindetails").blur();

    var TrainTypeList = [];

    var traintype =

               {
                   TicketClass: $("[name='EnquiryItemTypeDetails[0].TicketClass']").val(),

                   PickUpFrom: $("[name='EnquiryItemTypeDetails[0].PickUpFrom']").val(),

                   DropTo: $("[name='EnquiryItemTypeDetails[0].DropTo']").val(),

                   DepartureDate: $("[name='EnquiryItemTypeDetails[0].DepartureDate']").val(),

                   ReturnDate: $("[name='EnquiryItemTypeDetails[0].ReturnDate']").val()

               }

    TrainTypeList.push(traintype);

    $("#divtrainType").find(".row").each(function () {

        var traintype =

                {
                    TicketClass: $(this).find(".train-ticket-class").val(),

                    PickUpFrom: $(this).find(".train-from").val(),

                    DropTo: $(this).find(".train-to").val(),

                    DepartureDate: $(this).find(".train-depart-on").val(),
                }

        TrainTypeList.push(traintype);
    });

    //alert(JSON.stringify(TrainTypeList));


    var TrainPassList = [];

    var trainpass =

               {
                   Region: $("[name='EnquiryItemPassDetails[0].Region']").val(),

                   PassType: $("[name='EnquiryItemPassDetails[0].PassType']").val(),

                   RailPass: $("[name='EnquiryItemPassDetails[0].RailPass']").val(),

                   RailClass: $("[name='EnquiryItemPassDetails[0].RailClass']").val(),

                   NoOfDays: $("[name='EnquiryItemPassDetails[0].NoOfDays']").val()

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

    //alert(JSON.stringify(TrainPassList));

    var enqViewModel = {

        Enquiry: {

            EnquiryItemId: $("[name='Enquiry.EnquiryItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnEnquiryType").val(),

            EnquiryTrainType: $('input[name="Enquiry.TrainType"]:checked').val(),

            AdultCount: $("[name='Enquiry.adultCount']").val(),

            ChildCount: $("[name='Enquiry.childCount']").val(),

            InfantCount: $("[name='Enquiry.infantCount']").val(),

            Budget: $("[name='Enquiry.budget']").val(),

            EnquiryItemTypeDetails: TrainTypeList,

            EnquiryItemPassDetails: TrainPassList,

        }
    }

    //alert($("#hdnEnquiryId").val());

    //alert($("[name='Enquiry.EnquiryItemId']").val());

    var url = "";

    if ($("[name='Enquiry.EnquiryItemId']").val() == 0) {

        url = "/Enquiry/InsertTrainEnquiryItem"
    }
    else {

        url = "/Enquiry/UpdateEnquiryTrainDetails"
    }

    //alert(JSON.stringify(enqViewModel));

    PostAjaxWithProcessJson(url, enqViewModel, AfterTrainSave, $("body"));
}

function AfterTrainSave(data) {

    //alert(data);

    FriendlyMessage(data);

    //alert("AfterTrainSave")

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    //alert($("#hdnFlightId").val(data.Enquiry.EnquiryItemId));

    $("#hdnTrainId").val(data.Enquiry.EnquiryItemId);

    $("#hdnEnquiryType").val(data.Enquiry.EnquiryType);

    //alert(data.Enquiry.EnquiryType);

    GetEnquiryItemDetailsView();
    $("#modalParent").modal('hide');//To Close/Hide Common Modal
}


function GetTrainDetailsView() {

    //alert("train");

    debugger;

    $("#divEnquiryItemTrain").load("/Enquiry/GetTrainDetailsView", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val() }, null);

}





function DeleteTrainTypeDetailsData(rowId) {

    $("#tblTrainTypeDetails").find("[id='tr" + rowId + "']").remove();

    ReArrangeTrainTypeDetailsData();
}

function ReArrangeTrainTypeDetailsData() {

    var i = 1;

    $("#divtrainType").find(".row").each(function () {

        $(this).find(".train-ticket-class").attr("name", "EnquiryItemTypeDetails[" + i + "].TicketClass");

        $(this).find(".train-from").attr("name", "EnquiryItemTypeDetails[" + i + "].PickUpFrom");

        $(this).find(".train-to").attr("name", "EnquiryItemTypeDetails[" + i + "].DropTo");

        $(this).find(".train-depart-on").attr("name", "EnquiryItemTypeDetails[" + i + "].DepartureDate");

        i++;
    });
}

function DeleteTrainPassDetailsData(rowId) {

    $("#tblTrainPassDetails").find("[id='tr" + rowId + "']").remove();

    ReArrangeTrainPassDetailsData();
}

function ReArrangeTrainPassDetailsData() {

    var i = 1;

    $("#divtrainPass").find(".row").each(function () {

        $(this).find(".train-region").attr("name", "EnquiryItemPassDetails[" + i + "].Region");

        $(this).find(".train-pass-type").attr("name", "EnquiryItemPassDetails[" + i + "].PassType");

        $(this).find(".train-rail-pass").attr("name", "EnquiryItemPassDetails[" + i + "].RailPass");

        $(this).find(".train-rail-class").attr("name", "EnquiryItemPassDetails[" + i + "].RailClass");

        $(this).find(".train-no-of-days").attr("name", "EnquiryItemPassDetails[" + i + "].NoOfDays");

        i++;

    });
}



///// Train End