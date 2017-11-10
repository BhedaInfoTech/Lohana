$(document).ready(function () {

    $(".clockpicker").clockpicker();

    
    //debugger;

    GetAutocompleteScript("EnquiryTransfer");



    $("#dvTransferAssigneeName").hide();


    if ($("#hdnTransferId").val() == 0) {

        $("#dvTransferAssigneeName").hide();
    }
    else {

        $("#dvTransferAssigneeName").show();
    }


    $(".assignedtype").change(function () {

        //alert("uuuuu");

        if ($(this).val() == 1)
        {
            $("#dvTransferAssigneeName").hide();
        }
        else
        {
            $("#dvTransferAssigneeName").show();
        }
    });



    //////// Transfer Enquiry Item


    $("#btnAddTransfer").click(function () {

        $("#divtransferType").append($("#dvTempTransfer").html());

        ReArrangeTransferDetailsData();
    });

    $("#btnSaveTransferDetails").click(function () {

        //alert("abc");

        if ($("#frmtransferdetails").valid()) {

            SaveTransferEnquiryItem();

        }
    });

    $("#btnResetTransferDetails").click(function () {

        document.getElementById("frmtransferdetails").reset();

    });

    $(document).on("click", ".btn-transfer-remove", function () {

        $(this).parents(".rowtransfer").remove();

        ReArrangeTransferDetailsData();
    });



    $('datepicker-autoclose').datepicker({
        autoclose: true,
        todayHighlight: true
    });


    $(".count").TouchSpin({
        min: 0,
        max: 100,
        step: 1,
        decimals: 0,
        boostat: 5,
        maxboostedstep: 10,
        //postfix: '%',
        buttondown_class: "btn btn-secondary",
        buttonup_class: "btn btn-secondary"
    });




});