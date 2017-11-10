$(document).ready(function () {

    GetBusinesses();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetBusinessValues($(this));

            SetActive($("[name='Business.IsActive']"), $(this).attr("data-isactive"));
        }


    });

    $("#btnSaveBusiness").click(function () {

        if ($("#frmBusiness").valid()) {
            SaveBusiness();
        }
    });

    $("#btnSearchBusiness").click(function () {

        $("#tblBusiness").attr("data-current-page", "0");

        GetBusinesses();
    });

   

    $("#btnResetBusiness").click(function ()
    {
        document.getElementById("frmSearchBusiness").reset();

        ResetBusiness();
    });
});