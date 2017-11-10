$(document).ready(function () {

GetDuration();

$(document).on('change',"#tblSightSeeingTariffDurationDetails [name='c1']", function (event) {


    if ($(this).prop('checked')) {

        GetSetDurationValues($(this));

        var id = $(this).attr("data-durationid");

        $("#hdnSearchDurationId").val(id);

    }

});

$("#btnAddDuration").click(function () {

    if ($("#frmSightSeeingTariffDuration").valid()) {

        SaveSightSeeingTariffDuration();
    }
});

});