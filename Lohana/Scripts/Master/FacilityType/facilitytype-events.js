$(document).ready(function () {

    GetFacilityTypes();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetFacilityTypeValues($(this));

            SetActive($("[name='FacilityType.IsActive']"), $(this).attr("data-isactive"));
        }


    });


    $("#btnSaveFacilityType").click(function ()
    {
        debugger;

        if ($("#frmFacilityType").valid())
        {
            SaveFacilityType();
        }

    });

    $("#btnSearchFacilityType").click(function ()
    {

        $("#tblFacilityType").attr("data-current-page", "0");

        if ($("#frmSearchFacilityType").valid())
        {
            GetFacilityTypes();
        }

    });

    $("#btnResetFacilityType").click(function ()
    {
        document.getElementById("frmSearchFacilityType").reset();

        ResetFacilitytype();
    });    

});