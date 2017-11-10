
/// Transfer Start


function SaveTransferEnquiryItem() {

    debugger;

    $("#frmtransferdetails").blur();

    var TransferTypeList = [];

    var transfertype =

               {
                   TransferDate: $("[name='EnquiryItemTransferDetails[0].transferDate']").val(),

                   PickUpId: $("[name='EnquiryItemTransferDetails[0].pickUpType']").val(),

                   PickUpName: $("[name='EnquiryItemTransferDetails[0].pickUpFrom']").val(),

                   PickUpTime: $("[name='EnquiryItemTransferDetails[0].pickUpTime']").val(),

                   DropOffId: $("[name='EnquiryItemTransferDetails[0].dropOfType']").val(),

                   DropOffName: $("[name='EnquiryItemTransferDetails[0].dropOfTo']").val(),

                   DropOffTime: $("[name='EnquiryItemTransferDetails[0].dropOfTime']").val()

               }

    TransferTypeList.push(transfertype);

    $("#divtransferType").find(".rowtransfer").each(function () {

        var transfertype =

                {
                    TransferDate: $(this).find(".transfer-date").val(),

                    PickUpId: $(this).find(".transfer-pickup-type").val(),

                    PickUpName: $(this).find(".transfer-pickup-from").val(),

                    PickUpTime: $(this).find(".transfer-pickup-time").val(),

                    DropOffId: $(this).find(".transfer-dropof-type").val(),

                    DropOffName: $(this).find(".transfer-dropof-to").val(),

                    DropOffTime: $(this).find(".transfer-dropof-time").val(),

                }

        TransferTypeList.push(transfertype);
    });

    //alert(JSON.stringify(TransferTypeList));


    var enqViewModel = {

        Enquiry: {

            EnquiryItemId: $("[name='Enquiry.EnquiryItemId']").val(),

            EnquiryId: $("#hdnEnquiryId").val(),

            EnquiryType: $("#hdnEnquiryType").val(),

            Location: $("[name='Enquiry.nameOfCity']").val(),

            Currency: $("#drpcurrency").val(),

            VehicleType: $("#drpvehicleType").val(),

            Budget: $("[name='Enquiry.budget']").val(),

            AdultCount: $("[name='Enquiry.adultCount']").val(),

            ChildCount: $("[name='Enquiry.childCount']").val(),

          

            EnquiryItemTransferDetails: TransferTypeList

        }
    }

    //alert($("#hdnEnquiryId").val());

    //alert($("[name='Enquiry.EnquiryItemId']").val());

    var url = "";

    if ($("[name='Enquiry.EnquiryItemId']").val() == 0) {

        url = "/Enquiry/InsertTransferEnquiryItem"
    }
    else {

        url = "/Enquiry/UpdateEnquiryTransferDetails"
    }

    //alert(JSON.stringify(enqViewModel));

    PostAjaxWithProcessJson(url, enqViewModel, AfterTransferSave, $("body"));
}

function AfterTransferSave(data) {

    //alert(data);

    FriendlyMessage(data);

    //alert("AfterTransferSave")

    $("#hdnEnquiryId").val(data.Enquiry.EnquiryId);

    //alert($("#hdnTransferId").val(data.Enquiry.EnquiryItemId));

    $("#hdnTransferId").val(data.Enquiry.EnquiryItemId);

    $("#hdnEnquiryType").val(data.Enquiry.EnquiryType);

    //alert(data.Enquiry.EnquiryType);

    GetEnquiryItemDetailsView();
    $("#modalParent").modal('hide');//To Close/Hide Common Modal
}

function GetTransferDetailsView() {

    //alert("flight");

    debugger;

    $("#divEnquiryItemTransfer").load("/Enquiry/GetTransferDetailsView", { EnquiryId: $("#hdnEnquiryId").val(), EnquiryType: $("#hdnEnquiryType").val() }, null);

}

function DeleteTransferDetailsData(rowId) {

    $("#tblTransferDetails").find("[id='tr" + rowId + "']").remove();

    ReArrangeTransferDetailsData();
}

function ReArrangeTransferDetailsData() {

    var i = 1;

    $("#divtransferType").find(".rowtransfer").each(function () {

        $(this).find(".transfer-date").attr("name", "EnquiryItemTransferDetails[" + i + "].transferDate");

        $(this).find(".transfer-pickup-type").attr("name", "EnquiryItemTransferDetails[" + i + "].pickUpType");

        $(this).find(".transfer-pickup-from").attr("name", "EnquiryItemTransferDetails[" + i + "].pickUpFrom");

        $(this).find(".transfer-pickup-time").attr("name", "EnquiryItemTransferDetails[" + i + "].pickUpTime");

        $(this).find(".transfer-dropof-type").attr("name", "EnquiryItemTransferDetails[" + i + "].dropOfType");

        $(this).find(".transfer-dropof-to").attr("name", "EnquiryItemTransferDetails[" + i + "].dropOfTo");

        $(this).find(".transfer-dropof-time").attr("name", "EnquiryItemTransferDetails[" + i + "].dropOfTime");

        i++;

    });
}


//// Transfer End