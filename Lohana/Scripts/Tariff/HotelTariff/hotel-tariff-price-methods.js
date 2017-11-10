function SaveHotelTariffPrice() {

    $("#frmHotelTariffPrice").blur();

    var ChargesList = [];

    $("[data-chargeformula]").each(function (i) {

        var charges =

                {
                    Percentage:$(this).parents("tr").find(".percentage").val(),

                    ChargesId:$(this).parents("tr").find("[data-chargeid]").attr("data-chargeid"),

                    CalculatedPrice: $(this).parents("tr").find(".calculatedprice").val(),

                    TotalTaxPrice: $(this).parents("tr").find(".totaltax").text()//,

                
                }

        ChargesList.push(charges);
    });


    var htViewModel = {

        HotelTariffPrice: {

            HotelTariffPriceDetailsId:$("[name='HotelTariffPrice.HotelTariffPriceDetailsId']").val(),

            HotelTariffRoomOccupancyId: $("[name='HotelTariffPrice.HotelTariffRoomOccupancyId']").val(),

            HotelTariffDurationDetailsId: $("[name='HotelTariffPrice.HotelTariffDurationDetailsId']").val(),

            HotelTariffId: $("[name='HotelTariffPrice.HotelTariffId']").val(),

            PublishPrice: $("[name='HotelTariffPrice.PublishPrice']").val(),

            SpecialPrice:$("[name='HotelTariffPrice.SpecialPrice']").val(),

            CommissionPrice: $("[name='HotelTariffPrice.CommissionPrice']").val(),

            FormulaId: $("#drpFormula").val(),

            TotalTaxPrice: $("span.totaltax").text(),

            NetRate: $("[name='HotelTariffPrice.NetRate']").val(),

            NetRatePerNight: $("[name='HotelTariffPrice.NetRateAsPerNight']").val(),

            HotelTariffCharges: ChargesList,

            NoOfNight: $("[name='HotelTariffPrice.NoOfNight']").val(),

            Color: $("[name='HotelTariffPrice.Color']").val(),
      
        },


    }
    var url

    if ($("[name='HotelTariffPrice.HotelTariffPriceDetailsId']").val() == 0)
    {
        url = "/HotelTariff/InsertPrice"
    }
    else
    {
        url = "/HotelTariff/UpdatePrice"
    }

    PostAjaxJson(url, htViewModel, AfterPriceSave);
}

function AfterPriceSave(data) {

    FriendlyMessage(data);

    ResetPrice();

    GetHotelTariffPrice();
}

function ResetPrice() {

    $("[name='HotelTariffPriceFilter.HotelTariffPriceDetailsId']").val('');

    $("#txtPublishPrice").val('');

    $("#txtSpecialPrice").val('');

    $("#txtCommissionPrice").val('');

    $("#drpFormula").val('0');

    $("#drpFormula").trigger("change");

    $("#txtNetRate").val('');

    $("#txtNetRateAsPerNight").val('');

    $("span.totaltax").text('');
}

function GetHotelTariffPrice() {

	//var htViewModel =
	//	{
	//	    HotelTariffPrice: {

	//	        HotelTariffId: $("[name='HotelTariffPrice.HotelTariffId']").val(),

	//	        HotelTariffRoomDetailsId: $("[name='HotelTariffPrice.HotelTariffRoomDetailsId']").val(),

	//	    }
	//	}

	//PostAjaxJson("/HotelTariff/GetHotelTariffPrice", htViewModel, BindHotelTariffPrice);

    $("#dvPriceListing").load("/HotelTariff/GetHotelTariffPrice", { hotelTariffRoomOccupancyId: $("[name='HotelTariffPrice.HotelTariffRoomOccupancyId']").val() }, null);
}

function GetHotelTariffPriceById()
{
	var htViewModel =
		{
		    HotelTariffPrice: {

		    	HotelTariffPriceDetailsId: $("[name='HotelTariffPrice.HotelTariffPriceDetailsId']").val(),

		        //HotelTariffRoomDetailsId: $("[name='HotelTariffPrice.HotelTariffRoomDetailsId']").val(),

		    }
		} 

	PostAjaxJson("/HotelTariff/GetHotelTariffPriceById", htViewModel, BindHotelTariffPrice);
}

function BindHotelTariffPrice(data) { 
    
    debugger;

    $("[name='HotelTariffPrice.HotelTariffPriceDetailsId']").val(data.HotelTariffPrice.HotelTariffPriceDetailsId)

    $("[name='HotelTariffPrice.PublishPrice']").val(data.HotelTariffPrice.PublishPrice);

	$("[name='HotelTariffPrice.SpecialPrice']").val(data.HotelTariffPrice.SpecialPrice);

	$("[name='HotelTariffPrice.CommissionPrice']").val(data.HotelTariffPrice.CommissionPrice);

	$("#drpFormula").val(data.HotelTariffPrice.FormulaId);

	$("span.totaltax").text(data.HotelTariffPrice.TotalTaxPrice);

	$("[name='HotelTariffPrice.NetRate']").val(data.HotelTariffPrice.NetRate);

	$("[name='HotelTariffPrice.NetRateAsPerNight']").val(data.HotelTariffPrice.NetRatePerNight);

	//$("[name='HotelTariffPrice.Color']").val(data.HotelTariffPrice.Color);

	$("#dvColorPicker").colorpicker('setValue', data.HotelTariffPrice.Color);

 $("[name='HotelTariffPrice.Formula']").val(data.HotelTariffPrice.FormulaId)

  $('#drpFormula').trigger('change');
}

function GetHotelTariffDuration(obj)
{
    GetAjax("/HotelTariff/GetHotelTariffDurationPrice", { hotelTariffRoomOccupancyId: $("[name='HotelTariffPrice.HotelTariffRoomOccupancyId']").val() }, function (data) { BindHotelTariffDuration(data, obj) });
}

function BindHotelTariffDuration(data, obj)
{

    debugger

	var schedules = [];

	var colors = {};
     
	alert(JSON.stringify(data.HotelTariffDates));

	alert(JSON.stringify(data.HotelTariffPrices));

	for (var i = 0; i < data.HotelTariffDates.length; i++) {

	    var date = ToJavaScriptDateYear(data.HotelTariffDates[i].TariffDate);

	    schedules.push({ name: data.HotelTariffDates[i].HotelTariffPriceDetailsId, date: date });
	}

	alert(JSON.stringify(schedules));

	for (var i = 0; i < data.HotelTariffPrices.length; i++) {
	    colors[data.HotelTariffPrices[i].HotelTariffPriceDetailsId] = data.HotelTariffPrices[i].Color;
	}

	alert(JSON.stringify(colors));

	var scheduleOptions1 = { colors: colors };

	$(obj).pignoseCalendar({
		scheduleOptions: scheduleOptions1,
		schedules: schedules,
		select: function (date, context)
		{
		    alert(date + " : " + JSON.stringify(context.storage.schedules[0]));

		    $("[name='HotelTariffDates.HotelTariffRoomOccupancyId']").val(context.storage.schedules[0].name);

		    $("[name='HotelTariffDates.TariffDate']").val(context.storage.schedules[0].date);
			//for (var idx in context.storage.schedules)
			//{
			//	var schedule = context.storage.schedules[idx];

			//	alert(schedule.name);
			//}

			//alert(date);
			//alert(context.storage.schedules.name);
			//alert('events for this date', context.storage.schedules.name);
		}
	});
}


