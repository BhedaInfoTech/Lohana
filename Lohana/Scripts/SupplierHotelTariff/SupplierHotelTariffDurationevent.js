$(document).ready(function () {

    GetAutocompleteScript("Supplier Hotel Tariff Duration");

    GetHotelTariffDuration($("#dvcalendar1"));

    GetHotelTariffCustomerCategory();

    $("#btnAddSupplierHotelTariffDuration").click(function () {

        if ($("#frmSupplierHotelTariffduration").valid()) {

    
       SaveSupplierHotelTariffDuration();
      
        }
    });

    $("#btnResetSupplierHotelTariffDuration").click(function () {

        document.getElementById("frmSupplierHotelTariffduration").reset();       

    });

    //$('#date-range').datepicker({
    //    toggleActive: true
    //});

    $("#drpAllWeekWeekEnd").change(function () {
        if ($(this).val() == "none") {
            $("[name='SupplierHotelDuration.OperationalDays']").prop("checked", "");
        }
        else if ($(this).val() == "all") {
            $("[name='SupplierHotelDuration.OperationalDays']").prop("checked", "checked");
        }
        else if ($(this).val() == "weekend") {
            $("[name='SupplierHotelDuration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "checked");
            $("[name='SupplierHotelDuration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "");
        }
        else if ($(this).val() == "weekdays") {
            $("[name='SupplierHotelDuration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "checked");
            $("[name='SupplierHotelDuration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "");

        }


    });

});