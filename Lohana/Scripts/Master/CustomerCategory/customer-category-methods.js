function SaveCustomerCategory() {

    if ($("[name='CustomerCategory.IsActive']").val() == 1 || $("[name='CustomerCategory.IsActive']").val() == "true") {
        
        activeFlg = true;
    }
    else {

        activeFlg = false;
    }
    $("#frmCustomerCategory").blur();
 //  alert($("[name='CustomerCategory=CustomerCategoryName']").val());
    var cViewModel = {
       
   CustomerCategory: {
       
       CustomerCategoryId: $("[name='CustomerCategory.CustomerCategoryId']").val(),

       CustomerCategoryName: $("[name='CustomerCategory.CustomerCategoryName']").val(),

       Margin: $("[name='CustomerCategory.Margin']").val(),
            
       IsActive: activeFlg
                    }
    }
   // alert(cViewModel.ma)
    var url = "";


    if ($("[name='CustomerCategory.CustomerCategoryId']").val() == 0) {

        url = "/CustomerCategory/Insert"
    }
    else {
        url = "/CustomerCategory/Update"
    }

    PostAjaxWithProcessJson(url, cViewModel, AfterSave, $("body"));

}

function AfterSave(data) {
   
    FriendlyMessage(data);

    ResetCustomerCategory();

    GetCustomerCategory();
}

function GetCustomerCategory() {
    
    var cViewModel =
		{
		    CustomerCategory: {

		        CustomerCategoryId: $("[name='CustomerCategory.CustomerCategoryId']").val(),

		        CustomerCategoryName: $("[name='CustomerCategory.CustomerCategoryName']").val(),

		        Margin: $("[name='CustomerCategory.Margin']").val(),

		        IsActive: $("[name='CustomerCategory.IsActive']").val()
	    },
		    Pager: {

		        CurrentPage: $('#hdnCurrentPage').val()
		    },
		}

    PostAjaxWithProcessJson("/CustomerCategory/GetCustomerCategory", cViewModel, BindCustomerCategory, $("#frmSearchCustomerCategory"));
}

function BindCustomerCategory(data) {

    var htmlText = "";
    
    if (data.CustomerCategories.length > 0) {
        
        for (i = 0; i < data.CustomerCategories.length; i++) {

                    
            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='c1' data-id ='" + data.CustomerCategories[i].CustomerCategoryId + "'/>";

            htmlText += "<input type='hidden' name='CustomerCategoryId' id='hdncustomerCategoryId_" + data.CustomerCategories[i].CustomerCategoryId + "' value= '" + data.CustomerCategories[i].CustomerCategoryId + "'/>";

            htmlText += "<input type='hidden' class='customerCategory-name' value= '" + data.CustomerCategories[i].CustomerCategoryName + "' />";

            htmlText += "<input type='hidden' class='customerCategory-margin'  value= '" + data.CustomerCategories[i].Margin + "'/>";

            htmlText += "<input type='hidden' class='customerCategory-isactive' id='idIsActive' value= '" + data.CustomerCategories[i].IsActive + "' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.CustomerCategories[i].CustomerCategoryName;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.CustomerCategories[i].Margin;

            htmlText += "</td>";

            if (data.CustomerCategories[i].IsActive == true) {

                htmlText += "<td>";

                htmlText += "Yes";

                htmlText += "</td>";
            }
            else {
                htmlText += "<td>";

                htmlText += "No";

                htmlText += "</td>";
            }

            htmlText += "</tr>";

        }
    }
    else {
        htmlText += "<tr>";

        htmlText += "<td colspan='3'>";

        htmlText += "No Matching Records Found.";

        htmlText += "</td>";

        htmlText += "</tr>";
    }

    $("#tblCustomerCategory").find("tr:gt(0)").remove();

    $('#tblCustomerCategory tr:first').after(htmlText);

    BindPagination(data.Pager, $('#tblCustomerCategory'));

    ResetCustomerCategory();
}


function ResetCustomerCategory() {

    $("[name='CustomerCategory.CustomerCategoryName']").val("");

    $("[name='CustomerCategory.Margin']").val("");

    $("[name='CustomerCategory.CustomerCategoryId']").val("");

    $("[name='Filter.CustomerCategoryId']").val("");

    if ($("[name='CustomerCategory.IsActive']").val() == 0 || $("[name='CustomerCategory.IsActive']").val() == "false") {
        $('.switchery').trigger('click');
    }

}

function Pagination(CurrentPage) {

    $('#hdnCurrentPage').val((parseInt(CurrentPage)));

    GetCustomerCategory();


}

$(document).on("change", "input[type='checkbox']", function () {
    if ($(this).prop("checked")) {

        $(this).val(true);
    }
    else {

        $(this).val(false);
    }
});












