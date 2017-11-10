$(document).ready(function () {

    $("#txtamtpaid").focusout(function () {
        var balamt = '';

        if ($("#txtamtpaid").val() != null) {
            var totalamtpaid = parseInt($("#txtTotalAmtPaid").val());
            var actualamtpaid = parseInt($("#txtamtpaid").val());
            var finalamt = (totalamtpaid + actualamtpaid);
            balamt = ($("#txttotalamt").val() - finalamt);
            $("#txtbalamt").val(balamt);
        }
    });

    $("#btnSavePayble").click(function () {
        if ($("#frmpayble").valid()) {
            SavePayble();
        }
    });

    $("#btnResetPayble").click(function () {
        document.getElementById("frmpayble").reset();
        $("#hdnPaybleId").val("");
    });

    $(document).on("change", "input[type='checkbox']", function () {
        if ($(this).prop("checked")) {
            $(this).val(true);
        }
        else {
            $(this).val(false);
        }
    });

    $('[name = "PayableInfo.PayableHistoryInfo.ModeOfPayment"]').change(function () {
        if ($(this).val() == 0) {
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            $("#divChequedate").hide();
            $("#divPaidAmount").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
        }

        else if ($(this).val() == 1) {
            $("#divDebitcardno").show();
            $("#divPaidAmount").show();
            $("#divCreditcardno").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();        
          //  $('#frmpayble').rules("add", { required: false });
        }

        else if ($(this).val() == 2) {

            $("#divCreditcardno").show();
            $("#divPaidAmount").show();
            $("#divDebitcardno").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
           // $('#frmpayble').rules("add", { required: false });
        }

        else if ($(this).val() == 3) {

            $("#divPaidAmount").show();
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
           // $('#frmpayble').rules("add", { required: true });

        }

        else if ($(this).val() == 4) {

            $("#divPaidAmount").show();
            $("#divNIFT").show();
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").show();
            // $('#frmpayble').rules("add", { required: true });

        }


        else if ($(this).val() == 6) {
            $("#divChequedate").show();
            $("#divChequeno").show();
            $("#divBankName").show();
            $("#divPaidAmount").show();
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
         //   $('#frmpayble').rules("add", { required: false });
        }

        else {
            $("#divCreditcardno").hide();
            $("#divDebitcardno").hide();
            $("#divPaidAmount").hide();
            $("#divChequedate").hide();
            $("#divChequeno").hide();
            $("#divBankName").hide();
          //  $('#frmpayble').rules("add", { required: false });
        }
    });

});