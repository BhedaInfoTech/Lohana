function SaveCharges() {

    if ($("[name='Charges.IsActive']").val() == 1 || $("[name='Charges.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmCharges").blur();

    var cViewModel = {

        Charges: {
        
            ChargesName: $("[name='Charges.ChargesName']").val(),

            Abbreviation: $("[name='Charges.Abbreviations']").val(),

            ChargesBehaviour: $("#drpChargesBehaviour").val(),

            ChargesId: $("[name='Filter.ChargesId']").val(),

            IsActive: activeFlg,

        }
    }

    var url = "";

    if ($("[name='Filter.ChargesId']").val() == 0) {

        url = "/Charges/Insert"
    }
    else {
        url = "/Charges/Update"
    }

    PostAjaxWithProcessJson(url, cViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetCharges();

    GetCharges();
}

function GetCharges() {

    debugger;

    var cViewModel =
		{
		    Charges: {
		       
		      
		        ChargesName: $("[name='Charges.ChargesName']").val(),

		        Abbreviation: $("[name='Charges.Abbreviations']").val()

		       

		    },
		    Pager: {

		        CurrentPage: $('#tblCharges').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Charges/GetCharges", cViewModel, BindCharges, $("#frmSearchCharges"));
}

function BindCharges(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["ChargesName", "Abbreviation", "IsActiveStr"],
        primayKey: "ChargesId",
        hiddenFields: ["ChargesId", "ChargesName", "Abbreviation", "IsActive"],
        headerNames: ["Charges Name", "Abbreviation","Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblCharges'));

    BindPagination(list.Pager, $('#tblCharges'));
    
}

function ResetCharges() {

    $("[name='Charges.ChargesName']").val("");

    $("[name='Charges.Abbreviations']").val("");

    $("[name='Charges.ChargesId']").val("");

    $("[name='Filter.ChargesId']").val("");

    $("#drpChargesBehaviour").val("0");


    if ($("[name='Charges.IsActive']").val() == 0 || $("[name='Charges.IsActive']").val() == "false")
    {
        $("[name='Charges.IsActive']").trigger('click');
    }
}

function Pagination(CurrentPage) {

    $('#tblCharges').attr("data-current-page", CurrentPage);

    GetCharges();

}

function GetSetChargesValues(obj) {

    var id = $(obj).attr("data-chargesid");

    var chargesName = $(obj).attr("data-chargesname");

    var abbreviation = $(obj).attr("data-abbreviation");

    var chargesBehaviour = $(obj).attr("data-chargesbehaviour");

    $("#hdnSearchChargesId").val(id);

    $("[name='Charges.ChargesName']").val(chargesName);

    $("[name='Charges.Abbreviations']").val(abbreviation);

    $("[name='Charges.ChargesBehaviour']").val(chargesBehaviour);

}



