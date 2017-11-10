function SaveTax() {
    
    if ($("[name='Tax.IsActive']").val() == 1 || $("[name='Tax.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }
    
    $("#frmTax").blur();

    var tViewModel = {

        Tax: {

            TaxId: $("[name='Tax.TaxId']").val(),

            TaxName: $("[name='Tax.TaxName']").val(),

            TaxCode: $("[name='Tax.TaxCode']").val(),

            TaxRate: $("[name='Tax.TaxRate']").val(),

            IsActive: $("[name='Tax.IsActive']").val(),
           
        },
      
    }
    
    if ($("[name='Tax.TaxId']").val() == 0) {
      
       url = "/Tax/Insert"
    }
    else {

        url = "/Tax/Update"
    }

    PostAjaxWithProcessJson(url, tViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetTax();

    GetTaxes();
}

function ResetTax() {

    $("[name='Tax.TaxId']").val("");

    $("[name='Tax.TaxName']").val("");

    $("[name='Tax.TaxCode']").val("");

    $("[name='Tax.TaxRate']").val("");

    if ($("[name='Tax.IsActive']").val() == 0 || $("[name='Tax.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }
}
