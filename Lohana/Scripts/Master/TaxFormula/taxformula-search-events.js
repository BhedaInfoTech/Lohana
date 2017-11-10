$(document).ready(function () {

   // document.getElementById("btnEditTaxFormula").disabled = true;

    //document.getElementById("btnViewFormulaCharges").disabled = true;


    // Search specific Tax Formula
    $("#btnSearchTaxformula").click(function () {

        $("#tblTaxFormula").attr("data-current-page", "0");


        GetTaxFormula();
    });

    // Load "Tax Formula" list
    GetTaxFormula();

    // Load Formula charges for selected TaxFormulaId
    $("#btnViewFormulaCharges").click(function () {
        var taxFormulaId = $("#frmSearchTaxFormula input[type='radio']:checked").attr("data-taxformulaid");

        if (taxFormulaId != undefined && taxFormulaId != null) {
            $(".view_details").find(".modal-body").load("/TaxFormula/GetFormulaCharges", { TaxFormulaId: taxFormulaId }, null);
        }
    });

    $("#btnEditTaxFormula").click(function () {
        $("#frmSearchTaxFormula").attr("action", "/TaxFormula/GetTaxFormulaById");

        $("#frmSearchTaxFormula").submit();
    });
});