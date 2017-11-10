$(document).ready(function () {

    GetDesignations();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetDesignationValues($(this));

            SetActive($("[name='Designation.IsActive']"), $(this).attr("data-isactive"));
        }

    });


    $("#btnSaveDesignation").click(function () {

        if ($("#frmDesignation").valid()) {

            SaveDesignation();
        }

    });

    $("#btnSearchDesignation").click(function ()
    {
        $("#tblDesignation").attr("data-current-page", "0");

        GetDesignations();
    });

    

    $("#btnResetDesignation").click(function ()
    {
        document.getElementById("frmSearchDesignation").reset();

        ResetDesignation();
    });

});