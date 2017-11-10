/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

    $(document).on('change', "[name='c1']", function (event) {
        
        if ($(this).prop('checked')) {

            var id = $(this).attr("data-id");

            var customerCategoryName = $(this).siblings(".customerCategory-name").val();

            var margin = $(this).siblings(".customerCategory-margin").val();

            var isactive = $(this).siblings(".customerCategory-isactive").val();
            
            if (isactive == "true" || isactive == 1) {

                if ($("[name='CustomerCategory.IsActive']").val() == 0 || $("[name='CustomerCategory.IsActive']").val() == "false") {
                    $('.switchery').trigger('click');
                }
            }
            else {

                if ($("[name='CustomerCategory.IsActive']").val() == 1 || $("[name='CustomerCategory.IsActive']").val() == "true") {
                    $('.switchery').trigger('click');
                }
            }

            $("#hdnCustomerCategoryId").val(id);

            $("[name='CustomerCategory.Margin']").val(margin);

            $("[name='CustomerCategory.CustomerCategoryName']").val(customerCategoryName);
            
            $("[name='CustomerCategory.IsActive']").val(isactive);
        }
    });

    $("#btnSaveCustomerCategory").click(function () {
       
        if ($("#frmCustomerCategory").valid()) {
            
            SaveCustomerCategory();
           
        }
     
    });

    $("#btnSearchCustomerCategory").click(function () {

        $("#tblCustomerCategory").attr("data-current-page", "0");

        $('#hdnCurrentPage').val(" ");

        GetCustomerCategory();

    });

    GetCustomerCategory();

    $("#btnResetCustomerCategory").click(function () {

        document.getElementById("frmSearchCustomerCategory").reset();

        $("#hdnSearchCustomerCategoryId").val("");
    });

});
