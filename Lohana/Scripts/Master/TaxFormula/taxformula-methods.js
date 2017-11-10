var returnArray;

function BindChargeBehaviour(chargeIds, obj) {

    var div = $("<div/>").attr({ class: "row" });

    $(div).load("/TaxFormula/GetChargesRateBehaviour", { chargeIds: chargeIds }, function () {

        $(obj).closest(".charge-cal-on").append(div);

    });
}

function GetChargesIds() {

    return { 0: 1, 1: 2, 2: 3 };
}


function BindChargesCalOn(level) {

    var div = $("<div/>").attr({ class: "charge-cal-on" });

    $(div).load("/TaxFormula/GetChargesCalOn", { level: level }, function () {

        $("#dvChargeCalOn").append(div);

    });
}


function GetLevels() {
    return $(".charges-type").length;
}


//Save Tax Formula with charges

function SaveTaxFormula() {

    if ($("[name='TaxFormula.Status']").val() == 1 || $("[name='TaxFormula.Status']").val() == "true") {
        Flag = true;
    }
    else {
        Flag = false;
    }

    $("#frmTaxFormula").blur();

    // Set Formula Charges Detail : Start   

    /* Remove operators located at last index */
    removeLastIndexedOperators($('#drpTaxFormula').val());    

    var taxFormulaCharges = [];

    var _taxFormulaCharges = {

        OldChargesId: $('#hdnChargesId').val(),

        ChargesId: $('#drpCharges').val(),

        ChargeFormula: $('#drpTaxFormula').val() == null ? '' : returnArray.toString(),
    }

    taxFormulaCharges.push(_taxFormulaCharges);

    // Set Formula Charges Detail : End ; Bind tViewModel

    var tViewModel =
        {
            TaxFormula: {

                TaxFormulaId: $("[name='TaxFormula.TaxFormulaId']").val(),

                TaxFormulaName: $("#txtTaxFormula").val(),

                IsActive: Flag,

                TaxFormulaCharges: taxFormulaCharges,
            },
        }

    var url = "";

    if ($("[name='TaxFormula.TaxFormulaId']").val() == 0) {
        url = "/TaxFormula/Insert"
    }
    else {
        url = "/TaxFormula/Update"
    }

    PostAjaxJson(url, tViewModel, AfterSaveTaxFormula, $("body"));
}

function removeLastIndexedOperators(array)
{
    var lastIndex = array.length - 1;

    $.each(array, function (index, value)
    {
        if (index == lastIndex && (value == "+" || value == "-"))
        {
            array.splice(lastIndex, 1);
        }

    });

    if (array[array.length - 1].toString() == "+" || array[array.length - 1].toString() == "-")
    {
        removeLastIndexedOperators(array);
    }
    else
    {
        returnArray = array;
    }
}

function AfterSaveTaxFormula(data) {
    FriendlyMessage(data);

    // Set TaxFormulaId on page
    $("[name='TaxFormula.TaxFormulaId']").val(data.TaxFormula.TaxFormulaId);

    $("[name='ChargeType.TaxFormulaId']").val(data.TaxFormula.TaxFormulaId);

    ResetFormulaCharges();

    GetTaxFormula();
}

function GetTaxFormula() {
    var tViewModel =
		{
		    TaxFormula:
                {
                    TaxFormulaId: $("[name='TaxFormula.TaxFormulaId']").val()
                },
		    Pager:
                {
                    CurrentPage: $('#tblTaxFormulaChargeBehaviour').attr("data-current-page")
                },
		}

    PostAjaxWithProcessJson("/TaxFormula/GetTaxFormulaChargeBehaviour", tViewModel, BindTaxFormulaChargeBehaviour, null);
}

function BindTaxFormulaChargeBehaviour(data) {
    var list = JSON.parse(data);

    var kTable =
        {
            dataList: ["ChargesName", "ChargeFormulaText"],
            primayKey: "ChargesId",
            hiddenFields: ["ChargesId", "ChargesName", "ChargeFormula"],
            headerNames: ["Charges Name", "Charge Formula"],
            data: list.TaxFormulaCharges,
        }

    buildHtmlTable(kTable, $('#tblTaxFormulaChargeBehaviour'));

    $(document).on('change', "[name='c1']", function (event) {
        if ($(this).prop('checked')) {
            GetSetTaxFormulaValues($(this));
        }
    });
}

function ResetFormulaCharges() {
    $("#hdnChargesId").val("");

    $("#drpCharges").val("");

    $("#drpFormulaCharges").val("");

    $("#drpTaxFormula").val(null).trigger("change");

    $('#drpTaxFormula').find('option').remove();
}

//Save Charge Type
function SaveTaxChargeType() {

    alert("SaveChargeTypeMethod");

    $("#frmTaxFormula").blur();

    debugger;

    var tViewModel =
        {
            TaxFormulaCharges: GetTaxFormulaChargeList(),
        }

    alert($("[name='ChargeType.TaxFormulaId']").val());

    var url = "";

    url = "/TaxFormula/InsertCharge"

    PostAjaxJson(url, tViewModel, AfterSaveTaxChargeType);
}

function GetTaxFormulaChargeList() {
    debugger;

    var TaxFormulaChargeList = [];

    $(".charges-type").each(function () {

        var demo = {

            TaxFormulaChargeId: $("[name='TaxFormula.TaxFormulaChargesId']").val(),

            TaxFormulaId: $("[name='ChargeType.TaxFormulaId']").val(),

            ChargesId: $(this).val(),

            TaxFormulaCaluclatedOns: GetTaxFormulaList($(this)),
        }

        TaxFormulaChargeList.push(demo);

    });

    return TaxFormulaChargeList;
}


function AfterSaveTaxChargeType(data) {


    $("[name='CalculatedOn.TaxFormulaChargesId']").val(data.TaxFormulaCharge.TaxFormulaChargesId);

    SaveTaxCalculatedOn();

}


//Save Calculated On

function SaveTaxCalculatedOn() {

    $("#frmTaxFormula").blur();

    debugger;

    var tViewModel = {

        TaxFormulaCalculatedOns: GetTaxFormulaList(),
    }

    var url = "";

    url = "/TaxFormula/InsertCalculatedOn"

    PostAjaxJson(url, tViewModel, AfterSaveTaxCalculatedOn);
}

function GetTaxFormulaList(obj) {

    var TaxFormulaCalulatedOnList = [];

    var FixPrice = false;

    var Behaviour = "";

    debugger;

    $(obj).closest(".charge-cal-on").find(".calcon").each(function () {

        if ($(this).find("option:selected").attr("data-is-fixed") == '1') {

            FixPrice = true;
        }
        else {
            FixPrice = false;
        }

        if ($(this).attr("data-behaviour") == '0') {

            Behaviours = 0;
        }
        else {

            Behaviours = $(this).parents(".calonbehaviour").find("#drpChargeBehaviour").val();

            //Behaviours = $(this).val();

            // alert($(".calcon").parent(".calonbehaviour").find("#drpChargeBehaviour").val());
        }

        var demo =
      {
          TaxFormulaChargeId: $("[name='CalculatedOn.TaxFormulaChargesId']").val(),

          IsFixPrice: FixPrice,

          CalculatedOnId: $(this).val(),

          Behaviour: Behaviours,
      }

        $("[name='CalculatedOnCharge.TaxFormulaChargesId']").val($("[name='CalculatedOn.TaxFormulaChargesId']").val());

        TaxFormulaCalulatedOnList.push(demo);

    });

    return TaxFormulaCalulatedOnList;
}

function AfterSaveTaxCalculatedOn(data) {

    GetTaxFormulaChageBehaviour();

    $("#drpChargesType").on('change', function () {

        debugger;

        var taxChargesId = $("#tblTaxFormulaChargeBehaviour").closest('tr').find('.taxformulacharge-id').val();

        $(this).closest('table').parent().siblings('.spec_table').length

        // var taxChargesId = $(this).siblings(".taxformulacharge-id").val();

        alert($("#tblTaxFormulaChargeBehaviour").closest('tr').find('.taxformulacharge-id').val());

        //   var taxChargesName = $(this).siblings(".taxformulacharge-name").val();

        $("#drpCalculatedOn").append("<option value='" + taxChargesId + "'>" + taxChargesId + "</option>");
    });

    ResetTaxFormula();

}

function ResetTaxFormula() {
    ResetFormulaCharges();
}

function GetTaxFormulaChageBehaviour() {

    debugger;

    alert($("[name='CalculatedOnCharge.TaxFormulaChargesId']").val());

    var tViewModel =
		{
		    TaxFormulaCalculatedOn: {

		        TaxFormulaChargeId: $("[name='CalculatedOnCharge.TaxFormulaChargesId']").val()

		    },
		    Pager: {

		        CurrentPage: $('#hdnCurrentPage').val()
		    },
		}

    PostAjaxWithProcessJson("/TaxFormula/GetTaxFormulaChargeBehaviour", tViewModel, BindTaxFormulaChageBehaviour, $("#frmTaxFormula"));
}

function GetSetTaxFormulaValues(obj) {
    var id = $(obj).attr("data-chargesid");

    var chargeId = $(obj).attr("data-chargesid");

    var chargeFormula = $(obj).attr("data-chargeformula");

    // Display all selected values in multiselect dropdown
    var dataarray = chargeFormula.split(",");

    // Display all selected values in multiselect dropdown
    $('#drpTaxFormula').find('option').remove();

    var dataarray = chargeFormula.split(",");

    $.each(dataarray, function (index, value) {
        var operatorText, option;

        if (value == "+") {
            operatorText = "Add";

            option = new Option(operatorText, value);
        }
        else if (value == "-") {
            operatorText = "Subtract";

            option = new Option(operatorText, value);
        }
        else {
            $("#drpFormulaCharges").val(value);

            operatorText = $('#drpFormulaCharges').find('option:selected').text();

            option = new Option(operatorText, value);
        }


        $("#drpTaxFormula").append(option);

        $("#drpTaxFormula").trigger("change");
    });

    $("#drpTaxFormula").val(dataarray).trigger("change");

    // Assign Charge Id 
    $("#hdnChargesId").val(id);

    // Select charge name
    $("#drpCharges").val(chargeId);
}

function additionalOperators(operatorVal, operatorText, multiselectDDL) {
    var option = new Option(operatorVal, operatorText);

    option.selected = true;

    $("." + multiselectDDL).append(option);

    $("." + multiselectDDL).trigger("change");
}





































































//If Binding the dropdown values in Html in js.   27 Jan 2017.


//function BindDropdowns(data) {

//    var htmlText = "";

//    //htmlText += "<tr>";

//    //htmlText += "<td>";

//    htmlText += "<div class='row'>";

//    htmlText += "<div class='col-md-3'>";

//    htmlText += "</div>";

//    htmlText += "<div class='col-md-3'>";

//    htmlText += "<label for='drpChargesBehaviour' style='color: #333'>Behaviour</label>"

//    htmlText += "<div class='input-group'>"

//    htmlText += "<select class='form-control' name='TaxFormula.Behaviour' id='drpBehaviour'>"

//    htmlText += "<option value='0'>Select Behaviour</option>"

//    for (var i = 0; i < data.length; i++) {

//        htmlText += "<option value='" + data[i].Key + "'>" + data[i].Value + "</option>"
//    }

//    htmlText += "</select>"

//    htmlText += "<span class='input-group-addon'>"
//    htmlText += "<i class='fa fa-plus'></i>"
//    htmlText += "</span>"

//    htmlText += "<span class='input-group-addon'>"
//    htmlText += "<i class='fa fa-minus'></i>"
//    htmlText += "</span>"
//    htmlText += "</div>"
//    htmlText += "</div>"

//    htmlText += "<div class='col-md-3'>";

//    htmlText += "<label for='drpChargesRate' style='color: #333'>Calculated On</label>"

//    htmlText += "<div class='input-group'>"

//    htmlText += "<select class='form-control' name='TaxFormula.Behaviour' id='drpChargeRate'>"

//    htmlText += "<option value='0'>Select Calculated on</option>"

//    for (var i = 0; i < data.length; i++) {

//        htmlText += "<option value='" + data[i].Key + "'>" + data[i].Value + "</option>"
//    }

//    htmlText += "</select>"

//    htmlText += "<span class='input-group-addon'>"
//    htmlText += "<i class='fa fa-plus'></i>"
//    htmlText += "</span>"

//    htmlText += "<span class='input-group-addon'>"
//    htmlText += "<i class='fa fa-minus'></i>"
//    htmlText += "</span>"
//    htmlText += "</div>"
//    htmlText += "</div>"




//    //htmlText += "</tr>";

//    //htmlText += "</td>";

//    $(".drpBehaviour").append(htmlText);

//    $(".drpChargeRates").append(htmlText);

//}

