$(document).ready(function () {


    GetSightSeeingTariffBasic();

    $(document).on('change',"#tblSightSeeingTariffBasicDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetSightSeeingTariffValues($(this));

            var id = $(this).attr("data-sightseeingtariffid");

            $("#hdnSearchSightSeeingTariffId").val(id);

            SetActive($("[name='SightSeeingTariff.IsActive']"), $(this).attr("data-isactive"));
         
        }

    });

    $("#btnAddBasicDetails").click(function () {

        if ($("#frmSightSeeingTariffBasic").valid()) {

            SaveSightSeeingTariffBasic();
        }
    });


});