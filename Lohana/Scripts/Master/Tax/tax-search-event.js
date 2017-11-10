$(document).ready(function () {
    
    GetTaxes();

    $('.switchery').trigger('click');

    document.getElementById("btnEditTax").disabled = true;

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetTaxValues($(this));

            SetActive($("[name='Tax.IsActive']"), $(this).attr("data-isactive"));

            document.getElementById("btnEditTax").disabled = false;
        }
    
    });
  

    $("#btnSearchTax").click(function () {
       
        GetTaxes();
        
    });


    $("#btnEditTax").click(function () {

        $("#frmSearchTax").attr("action", "/Tax/GetTaxById");

        $("#frmSearchTax").submit();

    });


    $("#btnResetTax").click(function () {

        document.getElementById("frmSearchTax").reset();

        $("#hdnSearchTaxId").val("");
    });

});