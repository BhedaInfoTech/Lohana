$(document).ready(function () {


    $('#txtCheckInDate').datepicker('setDate', new Date());

    GetAutocompleteScript("Supplier Search");

    GetAutocompleteScript("SupplierSearch");


    $("#btnSearchSupplierHotel").click(function () {

        GetSupplierSearchDetails();
    });

    $("#btnResetSupplierHotel").click(function () {
     $('#txtAdultCount').val(1),
    $('#txtChildCount').val(0)

    });

    $("#divAgeFromTo").hide();

    $(document).on('change', "#txtChildCount", function (event) {

        if ($("#txtChildCount").val() > 0)
        {
            $("#divAgeFromTo").show();
        }
        else
        {
            $("#divAgeFromTo").hide();
        }



    });
});