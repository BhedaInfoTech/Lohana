
$(function () {

    $("#btnAddHotelBank").click(function () {
        if ($("#frmHotelbank").valid()) {
            SaveHotelBank();
        }
    });

    //$("#btnEditHotelBank").click(function () {
    //    GetHotelBankById();
    //});

    $(document).on('change', "#tblHotelBankDetails [name='c1']", function (event) {
        if ($(this).prop('checked')) {
            var id = $(this).attr("data-bankid");

            $("#hdnSearchBankId").val(id);

            GetHotelBankById();

            $("#btnDeleteHotelBank").removeAttr("disabled");

        }
    });

    $("#btnDeleteHotelBank").click(function () {
        DeleteHotelBank();
    });


});