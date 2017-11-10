
$(document).ready(function () {

    GetVendor();

    document.getElementById("btnEditVendor").disabled = true;

    document.getElementById("btnViewContactDetails").disabled = true;  

    $(document).on('change', "#tblVendor [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-vendorid");
           
            $("#hdnSearchVendorId").val(id);         

            document.getElementById("btnEditVendor").disabled = false;

            document.getElementById("btnViewContactDetails").disabled = false;

        }

    });

    $("#btnSearchVendor").click(function () {

        $("#tblVendor").attr("data-current-page", "0");

        GetVendor();
    });

    $("#btnEditVendor").click(function () {

        $("#frmSearchVendor").attr("action", "/Vendor/GetVendorById");

        $("#frmSearchVendor").submit();       
        
    });

    $("#btnViewContactDetails").click(function (event) {

        $(".parent-modal").find(".modal-body").load("/Hotel/GetContactPersonListing", null, call_back);
    });

    function call_back(data) {

        $(".parent-modal").find(".modal-title").html("Contact details");

        GetContactPerson();

        $(".parent-modal").modal("show");
    }

    $("#btnResetVendor").click(function () {

        document.getElementById("frmSearchVendor").reset();
    });
});

