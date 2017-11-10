function GetTaxes() {
    
    var tViewModel =
		{
		    Filter: {             
                               
		        TaxName: $("[name='Filter.TaxName']").val(),

                IsActive: $("[name='Filter.IsActive']").val(),
                       
		    },

		    Pager:
                {
                    CurrentPage: $('#tblTax').attr("data-current-page"),
                },
		}
    
    PostAjaxJson("/Tax/GetTaxes", tViewModel, BindTaxes, $("#frmSearchTax"));
}

function BindTaxes(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["TaxCode", "TaxName", "TaxRate", "IsActive"],
        primayKey: "TaxId",
        hiddenFields: ["TaxId"],
        headerNames: ["Tax Code", "Tax Name", "Tax Rate", "Is Active"], 
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblTax'));

    BindPagination(list.Pager, $('#tblTax'));
}

function ResetTax() {

    $("[name='Filter.TaxId']").val("");
    
    $("[name='Filter.TaxName']").val("");
 
    if ($("[name='Filter.IsActive']").val() == 0 || $("[name='Filter.IsActive']").val() == "false") {
            
        $('.switchery').trigger('click');
        
    }
}

function Pagination(CurrentPage) {

    $('#tblTax').attr("data-current-page", CurrentPage);

    GetTaxes();
}

function GetSetTaxValues(obj) {

    var id = $(obj).attr("data-taxid");
        
    var taxName = $(obj).attr("data-taxname");
     
    $("#hdnSearchTaxId").val(id);

    $("[name='Filter.TaxName']").val(taxName);

}
