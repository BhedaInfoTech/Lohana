function GetTaxFormula() {
    var tViewModel =
		{
		    TaxFormula:
                {
                    TaxFormulaName: $("[name='TaxFormula.TaxFormulaName']").val()
                },
		    Pager: {

		        CurrentPage: $('#tblTaxFormula').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/TaxFormula/GetTaxFormula", tViewModel, BindTaxFormula, $("#frmSearchTaxFormula"));
}

function BindTaxFormula(data) {
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["TaxFormulaName", "IsActive"],
        primayKey: "TaxFormulaId",
        hiddenFields: ["TaxFormulaId"],
        headerNames: ["TaxFormula Name", "Is Active"],
        data: list.dt,
    }

    // Display view button on radio selection
    $(document).on('change', "[name='c1']", function (event) {
        if ($(this).prop('checked')) {
            var taxFormulaId = $("#frmSearchTaxFormula input[type='radio']:checked").attr("data-taxformulaid");

            $("#hdnSearchTaxFormulaId").val(taxFormulaId);

            document.getElementById("btnEditTaxFormula").disabled = false;

            document.getElementById("btnViewFormulaCharges").disabled = false;
        }
    });

    buildHtmlTable(kTable, $('#tblTaxFormula'));

    BindPagination(list.Pager, $('#tblTaxFormula'));
}


function Pagination(CurrentPage) {

    $('#tblTaxFormula').attr("data-current-page", CurrentPage);

    GetTaxFormula();

    document.getElementById("btnEditTaxFormula").disabled = true;

    document.getElementById("btnViewFormulaCharges").disabled = true;
}




//function GetTaxFormula() {

//    var tViewModel =
//		{
//		    TaxFormula: {

//		        TaxFormulaName: $("[name='TaxFormula.TaxFormulaName']").val(),

//		    },
//		    Pager: {

//		        CurrentPage: $('#hdnCurrentPage').val()
//		    },
//		}

//    PostAjaxJson("/TaxFormula/GetTaxFormula", tViewModel, BindTaxFormula);
//}

//function BindTaxFormula(data) {

//    var htmlText = "";

//    debugger;

//    alert(data)

//    // alert(data.TaxFormulaCalculatedOns.length);

//    debugger;

//    if (data.TaxFormulaCalculatedOns.length > 0) {

//        for (i = 0; i < data.TaxFormulaCalculatedOns.length; i++) {

//            //alert(data.TaxFormulaCalculatedOns);

//            htmlText += "<tr>";

//            //htmlText += "<td>";

//            // htmlText += "<input type='radio' name='tfcocb' data-id ='" + data.TaxFormulaCalculatedOns[i].TaxFormulaChargeId + "'/>";

//            htmlText += "<input type='hidden' name='TaxFormulaChargesId' id='hdnTaxFormulaChargesId" + data.TaxFormulaCalculatedOns[i].TaxFormulaChargeId + "' value= '" + data.TaxFormulaCalculatedOns[i].TaxFormulaChargeId + "'/>";

//            htmlText += "<input type='hidden' class='taxformulacharge-id' value= '" + data.TaxFormulaCalculatedOns[i].TaxChargesId + "' />";

//            htmlText += "<input type='hidden' class='taxformulacharge-name' value= '" + data.TaxFormulaCalculatedOns[i].TaxChargesName + "' />";

//            htmlText += "<input type='hidden' class='taxformulabehaviour-name' value= '" + data.TaxFormulaCalculatedOns[i].Behaviour + "' />";

//            htmlText += "<input type='hidden' class='taxformulacalculatedon-id' value= '" + data.TaxFormulaCalculatedOns[i].CalculatedOnId + "' />";

//            //htmlText += "</td>";

//            htmlText += "<td>";

//            htmlText += data.TaxFormulaCalculatedOns[i].TaxChargesName;

//            htmlText += "</td>";

//            htmlText += "<td>";

//            htmlText += data.TaxFormulaCalculatedOns[i].CalOnBehaviour;

//            htmlText += "</td>";

//            htmlText += "</tr>";

//        }
//    }
//    else {
//        htmlText += "<tr>";

//        htmlText += "<td colspan='3'>";

//        htmlText += "No Matching Records Found.";

//        htmlText += "</td>";

//        htmlText += "</tr>";
//    }

//    $("#tblTaxFormulaChargeBehaviour").find("tr:gt(0)").remove();

//    $('#tblTaxFormulaChargeBehaviour tr:first').after(htmlText);

//    $('#tblTaxFormulaChargeBehaviour').after(BindPagination(data.Pager, $('#tblTaxFormulaChargeBehaviour')));


//}
