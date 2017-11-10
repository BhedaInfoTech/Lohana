$(document).ready(function () {

    $('#drpBusinessType').multiSelect();

    $('#drpPaymentOption').multiSelect();

    GetAutocompleteScript("Vendor");
    
    $("#txtCompanyName").hide();

    $("#lblCompanyName").hide();




    // Changes For radio button on 15/05/2017 Start


    $("[name='Vendor.VendorType']").change(function ()
    {
          $('.custom-radio').attr('checked', false);

            $(this).attr('checked', true);

            if ($(this).attr('checked')) {
                if ($(this).val() == "2") {
                    $("#lblCompanyName").show();
                    $("#txtCompanyName").show();
                }
                else {
                    $("#lblCompanyName").hide();
                    $("#txtCompanyName").hide();
                }
            }           
       

    });


    // Changes For radio button on 15/05/2017 Start


    //Radio button change code Start

    var vendortype = $("#hdnradioVendorType").val();

    $("input:radio[name='Vendor.VendorType'][value='" + vendortype + "']").attr('checked', 'checked');

    if ($("#hdnradioVendorType").val() == "2") {
        $("#lblCompanyName").show();
        $("#txtCompanyName").show();
    }

    $("input[type='radio'][name='Vendor.VendorType']").change(function () {

        $("#hdnradioVendorType").val(this.value);

    });

    //Radio button change code End

    GetContactPerson();

    if ($("[name='Vendor.VendorId']").val() == 0) {

        $("#link1").hide();
        $("#link2").hide();
    }
    else {
        //$("[name='Vendor.VendorType']").trigger("change");
        $("#link1").show();
        $("#link2").show();
    }

    $("#btnSaveVendor").click(function () {
        if ($("#frmVendor").valid()) {
            SaveVendor();
        }

    });

    $("#btnResetVendor").click(function () {

        document.getElementById("frmVendor").reset();

    });

    //document.getElementById("btnEditContactPerson").disabled = true;

    //document.getElementById("btnDeleteContactPerson").disabled = true;



    //$(document).on('change', "[name='c1']", function (event) {

    //    if ($(this).prop('checked')) {

    //        var id = $(this).attr("data-contactpersonid");

    //        $("#hdnSearchContactPersonId").val(id);

    //        document.getElementById("btnEditContactPerson").disabled = false;

    //        document.getElementById("btnDeleteContactPerson").disabled = false;
    //    }

    //});




    //$("#btnAdd").click(function ()
    //{
    //    if ($("#frmContactPerson").valid())
    //    {
    //        SaveContactPerson();
    //    }
    //});

    //$("#btnEditContactPerson").click(function ()
    //{
    //    GetContactPersonById();
    //});

    //$("#btnDeleteContactPerson").click(function () {

    //    DeleteContactPerson();
    //});


});

