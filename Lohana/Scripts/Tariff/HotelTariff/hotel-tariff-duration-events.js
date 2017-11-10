$(document).ready(function () {

	GetAutocompleteScript("Hotel Tariff Duration");

	GetHotelTariffDuration($("#dvcalendar1"));

	GetHotelTariffCustomerCategory();

    $("#btnAddHotelTariffDuration").click(function () {

        if ($("#frmHotelTariffduration").valid()) {
             
            SaveHotelTariffDuration();
            
        }
    });


    $("#btnResetHotelTariffDuration").click(function () {

        document.getElementById("frmHotelTariffduration").reset();       

    });
    
    //$("#dvcalendar1").pignoseCalendar({
    //	scheduleOptions: {
    //		colors: {
    //			offer: '#2fabb7',
    //			ad: '#5c6270'
    //		}
    //	},
    //	schedules: [{
    //		name: 'offer',
    //		date: '2017-04-27'
    //	}, {
    //		name: 'ad',
    //		date: '2017-02-08'
    //	}, {
    //		name: 'offer',
    //		date: '2017-02-05',
    //	}],
    //	select: function (date, context)
    //	{
    //		for (var idx in context.storage.schedules)
    //		{
    //			var schedule = context.storage.schedules[idx];

    //			alert(schedule.name);
    //		}

    //		//alert(date);
    //		//alert(context.storage.schedules.name);
    //		//alert('events for this date', context.storage.schedules.name);
    //	}
    //});


    $('#date-range').datepicker({
    	toggleActive: true
    });

    $("#drpAllWeekWeekEnd").change(function ()
    {
    	if ($(this).val() == "none")
    	{
    		$("[name='HotelTariffDuration.OperationalDays']").prop("checked", "");
    	}
    	else if ($(this).val() == "all")
    	{
    		$("[name='HotelTariffDuration.OperationalDays']").prop("checked", "checked");
    	}
    	else if ($(this).val() == "weekend")
    	{
    		$("[name='HotelTariffDuration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "checked");
    		$("[name='HotelTariffDuration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "");
    	}
    	else if ($(this).val() == "weekdays")
    	{
    		$("[name='HotelTariffDuration.OperationalDays'][value!='Sunday'][value!='Saturday']").prop("checked", "checked");
    		$("[name='HotelTariffDuration.OperationalDays'][value='Sunday'],[value='Saturday']").prop("checked", "");
    		
    	}
			

    });

});