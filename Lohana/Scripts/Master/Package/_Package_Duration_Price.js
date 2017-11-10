$(document).ready(function () {

    GetPackageTariffCustomerCategory();

    GetPackageTariffDuration($("#dvcalendar1"));


    $("#btnAddPackageTariffDuration").click(function () {
        alert();
        //if ($("#frmPackageTriffduration").valid()) 
        {


            SavePackageTariffDuration();

        }
    });

$("#drpAllWeekWeekEnd").change(function () {
    if ($(this).val() == "none") {
        $("[name='Packageduration.OperationalDays']").prop("checked", "");
    }
    else if ($(this).val() == "all") {
        $("[name='Packageduration.OperationalDays']").prop("checked", "checked");
    }
    else if ($(this).val() == "weekend") {
        $("[name='Packageduration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "checked");
        $("[name='Packageduration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "");
    }
    else if ($(this).val() == "weekdays") {
        $("[name='Packageduration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "checked");
        $("[name='Packageduration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "");

    }


})
});