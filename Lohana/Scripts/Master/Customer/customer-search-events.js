$(document).ready(function () {

    document.getElementById("btnEditCustomer").disabled = true;

    GetCustomer();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {      
            
            var id = $(this).attr("data-customerid");

            $("#hdnSearchCustomerId").val(id);

            document.getElementById("btnEditCustomer").disabled = false;
           
        }

    });

    $("#btnSearchCustomer").click(function ()
    {
        $("#tblCustomer").attr("data-current-page", "0");

        GetCustomer();
    });


    $("#btnEditCustomer").click(function () {

        $("#frmSearchCustomer").attr("action", "/Customer/GetCustomerById");

        $("#frmSearchCustomer").submit();

    });

   
    $("#btnResetCustomer").click(function () {

        document.getElementById("frmSearchCustomer").reset();
    });
});


