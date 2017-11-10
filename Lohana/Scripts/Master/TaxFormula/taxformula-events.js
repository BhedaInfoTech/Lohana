
$(document).ready(function () {
    // multiselect ddl
    $(".js-example-basic-multiple").select2();

    // Re-order multiselection 
    $("select").on("select2:select", function (evt) {
        var element = evt.params.data.element;

        var $element = $(element);

        $element.detach();

        $(this).append($element);

        $(this).trigger("change");
    });

    // Perform below operations only during updation
    if (parseInt($("#hdnTaxFormulaId").val()) > 0) {
        SetActive($("[name='TaxFormula.Status']"), $("[name='TaxFormula.Status']").attr("data-isactive"));

        GetTaxFormula();
    }

    //Save Tax Formula Data.
    $("#btnSaveTaxFormula").click(function () {
        if ($("#frmTaxFormula").valid()) {
            SaveTaxFormula();
        }
    });

    //Reset Tax Formula Data.
    $("#btnResetTaxFormula").click(function () {
        ResetTaxFormula();
    });

    //Add additional operators.
    $("#btnAddOperator").click(function () {
        var operatorVal = 'Add',
            operatorText = '+',
            multiselectDDL = 'js-example-basic-multiple';

        additionalOperators(operatorVal, operatorText, multiselectDDL);
    });

    $("#btnSubstractOperator").click(function () {
        var operatorVal = 'Subtract',
            operatorText = '-',
            multiselectDDL = 'js-example-basic-multiple';

        additionalOperators(operatorVal, operatorText, multiselectDDL);
    });

    // On selecting charges dropdown
    $("#drpFormulaCharges").on('change', function () {
        var operatorVal = $(this).find('option:selected').text(),
            operatorText = $(this).find('option:selected').val(),
            multiselectDDL = 'js-example-basic-multiple';

        additionalOperators(operatorVal, operatorText, multiselectDDL);
    });




    //BindChargesCalOn(1);

    //$("#btnAddChargesCaculatedOn").click(function () {

    //    var level = GetLevels();

    //    BindChargesCalOn(level);

    //});


    //$("#btnEditTaxCalculatedOn").click(function ()
    //{
    //    GetTaxCaluclatedOnById();
    //});


    //$(document).on('change', "[name='tfcocb']", function (event) {

    //    alert("tfcob");

    //    if ($(this).prop('checked')) {

    //        var id = $(this).attr("data-id");

    //        var taxChargesId = $(this).siblings(".taxformulacharge-id").val();

    //        var taxChargesName = $(this).siblings(".taxformulacharge-name").val();

    //        var behaviour = $(this).siblings(".taxformulabehaviour-name").val();

    //        var CalculatedOnId = $(this).siblings(".taxformulacalculatedon-id").val();

    //        $("#hdnSearchChargeBehaviourId").val(id);

    //        $('#drpChargesType').val(taxChargesId);

    //        $('#drpCalculatedOn').val(CalculatedOnId);

    //        $("#drpCalculatedOn").append("<option value='" + taxChargesName + "'>" + taxChargesName + "</option>");

    //        $('#drpChargesBehaviour').val(behaviour);

    //    }

    //});

    //$(document).on("click", ".remove-cal-on", function () {

    //    $(this).closest(".row").remove();
    //});

});

















































//$("#btnAddMore").click(function () {


//    // Just to populate the dropdown valuesw though ajax call.. Commented on 27 Jan 2017 . Done by sushant

//    //var url = "/TaxFormula/GetChargeRateTypes";

//    //$.ajax({

//    //    url: url,

//    //    data: null,

//    //    datatype: 'json',

//    //    type: 'POST',

//    //    contentType: 'application/json',

//    //    Async: false,

//    //    success: function (data) {

//    //        BindDropdowns(data);

//    //    }


//    //Changes Done Bu Kaustubh for trying the Partial viewl load code is done below. 27 Jan 2017 Aftrnon

//    //var length = $(".charge-behaviour").length;

//    var div = $("<div/>").attr({ class: "row" });

//    //$("#dvChargeBehaviour").append(div);

//    $(div).load("/TaxFormula/GetChargesRateBehaviour", { chargeIds: { 0: 1, 1: 2, 2: 3 } }, function () {

//        $("#dvChargeBehaviour").append(div);
//    });

//    //$("#dvChargeBehaviour").append(div);

//});