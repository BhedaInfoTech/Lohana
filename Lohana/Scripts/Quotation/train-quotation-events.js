$(document).ready(function () {


    debugger;

    GetAutocompleteScript("QuotationTrain");


    /////// Flight Enquiry Item

    $("#divbuttonGroup").hide();

    $("#divenquiryFlightDetails").hide();

    $("#btnAdd").click(function () {

        $("#divflightType").append($("#dvTempFlight").html());

        ReArrangeFlightDetailsData();
    });

    $("#btnSaveTrainDetails").click(function () {

        if ($("#frmquotationtraindetails").valid()) {

            SaveTrainQuotationItem();

        }
    });

    $("#btnResetTrainDetails").click(function () {

        document.getElementById("frmtraindetails").reset();

    });

    $(document).on("click", ".btn-flight-remove", function () {

        $(this).parents(".row").remove();

        ReArrangeTrainDetailsData();
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