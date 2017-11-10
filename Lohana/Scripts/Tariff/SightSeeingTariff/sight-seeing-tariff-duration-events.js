$(document).ready(function () {

    GetAutocompleteScript("Sight Seeing Tariff Duration");

    GetSightSeeingTariffDuration($("#dvcalendar1"));

    GetSightSeeingTariffCustomerCategory();

    $("#btnAddSightSeeingTariffDuration").click(function () {

        if ($("#frmSightSeeingTariffduration").valid()) {
             
            SaveSightSeeingTariffDuration();
            
        }
    });


    $("#btnResetSightSeeingTariffDuration").click(function () {

        document.getElementById("frmSightSeeingTariffduration").reset();

    });

    $('#date-range').datepicker({
        toggleActive: true
    });

    $("#drpAllWeekWeekEnd").change(function () {
        if ($(this).val() == "none") {
            $("[name='SightSeeingTariffDuration.OperationalDays']").prop("checked", "");
        }
        else if ($(this).val() == "all") {
            $("[name='SightSeeingTariffDuration.OperationalDays']").prop("checked", "checked");
        }
        else if ($(this).val() == "weekend") {
            $("[name='SightSeeingTariffDuration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "checked");
            $("[name='SightSeeingTariffDuration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "");
        }
        else if ($(this).val() == "weekdays") {
            $("[name='SightSeeingTariffDuration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "checked");
            $("[name='SightSeeingTariffDuration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "");

        }


    });

});