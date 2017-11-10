$(document).ready(function () {

    GetVendorBank();

    //document.getElementById("btnEditVendorBank").disabled = true;

    $(document).on('change', "#tblVendorBankDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-bankid");

            $("#hdnSearchBankId").val(id);

            GetVendorBankById();

            $("#btnDeleteVendorBank").removeAttr("disabled");


            //document.getElementById("btnEditVendorBank").disabled = false;
        }

    });
   
    $("#btnAddVendorBank").click(function () {

        if ($("#frmVendorbank").valid()) {

            SaveVendorBank();
        }
    });

    //$("#btnEditVendorBank").click(function () {

    //    GetVendorBankById();
    //});

    $("#btnDeleteVendorBank").click(function () {
     
       DeleteVendorBank();
       
    });

   

   

});