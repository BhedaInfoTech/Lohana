function SaveSupplierHotelTariffPrice() {

    $("#frmSupplierHotelTariffPrice").blur();

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


    var sViewModel = {

    	SupplierHotelPrice: {

    		SupplierHotelPriceId: $("[name='SupplierHotelPrice.SupplierHotelPriceId']").val(),

    		OccupancyDetailId: $("[name='SupplierHotelPrice.OccupancyDetailId']").val(),

            PublishPrice: $("[name='SupplierHotelPrice.PublishPrice']").val(),

            SpecialPrice:$("[name='SupplierHotelPrice.SpecialPrice']").val(),

            CommissionPrice: $("[name='SupplierHotelPrice.CommissionPrice']").val(),

            FormulaId: $("#drpFormula").val(),

            TotalTaxPrice: $("span.totaltax").text(),

            NetRate: $("[name='SupplierHotelPrice.NetRate']").val(),

            SupplierHotelPriceDetails: ChargesList,

            Color: $("[name='SupplierHotelPrice.Color']").val(),
        },
    }
    var url

    if ($("[name='SupplierHotelPrice.SupplierHotelPriceId']").val() == 0)
    {
    	url = "/SupplierHotelTariff/InsertSupplierHotelPrice"
    }
    else
    {
    	url = "/SupplierHotelTariff/UpdateSupplierHotelPrice"
    }

    PostAjaxJson(url, sViewModel, AfterPriceSave);
}

function AfterPriceSave(data) {

    FriendlyMessage(data);

    ResetPrice();

    GetSupplierHotelTariffPrice();
}

function ResetPrice() {

	$("[name='SupplierHotelPrice.SupplierHotelPriceId']").val('');

    $("#txtPublishPrice").val('');

    $("#txtSpecialPrice").val('');

    $("#txtCommissionPrice").val('');

    $("#drpFormula").val('0');

    $("#drpFormula").trigger("change");

    $("#txtNetRate").val('');

    $("span.totaltax").text('');
}

function GetSupplierHotelTariffPrice()
{
    $("#dvPriceListing").load("/SupplierHotelTariff/GetSupplierHotelTariffPrice", { OccupancyDetailId: $("[name='SupplierHotelPrice.OccupancyDetailId']").val() }, null);
}

function GetHotelTariffPriceById()
{
	
	var sViewModel =
		{
			SupplierHotelPrice: {

				SupplierHotelPriceId: $("[name='SupplierHotelPrice.SupplierHotelPriceId']").val(),
		    }
		}

	PostAjaxJson("/SupplierHotelTariff/GetSupplierHotelPriceById", sViewModel, BindHotelTariffPrice);
}

function BindHotelTariffPrice(data)
{

	$("[name='SupplierHotelPrice.SupplierHotelPriceId']").val(data.SupplierHotelPrice.SupplierHotelPriceId);

	$("[name='SupplierHotelPrice.PublishPrice']").val(data.SupplierHotelPrice.PublishPrice);

	$("[name='SupplierHotelPrice.SpecialPrice']").val(data.SupplierHotelPrice.SpecialPrice);

	$("[name='SupplierHotelPrice.CommissionPrice']").val(data.SupplierHotelPrice.CommissionPrice);

	$("#drpFormula").val(data.SupplierHotelPrice.FormulaId);

	$("span.totaltax").text(data.SupplierHotelPrice.TotalTaxPrice);

	$("[name='SupplierHotelPrice.NetRate']").val(data.SupplierHotelPrice.NetRate);

	$("#dvColorPicker").colorpicker('setValue', data.SupplierHotelPrice.Color);

	$("[name='SupplierHotelPrice.Formula']").val(data.SupplierHotelPrice.FormulaId)

	$('#drpFormula').trigger('change');
}

function GetHotelTariffDuration(obj)
{
    GetAjax("/SupplierHotelTariff/GetSupplierHotelTariffDurationPrice", { OccupancyDetailId: $("[name='SupplierHotelPrice.OccupancyDetailId']").val() }, function (data) { BindSupplierHotelTariffDuration(data, obj) });
}

function BindSupplierHotelTariffDuration(data, obj)
{
    //alert(obj.prop("id"));
	var schedules = [];

	var colors = {};

	for (var i = 0; i < data.SupplierHotelTariffDurations.length; i++)
	{
	    var date = ToJavaScriptDateYear(data.SupplierHotelTariffDurations[i].TariffDate);

	    schedules.push({ name: data.SupplierHotelTariffDurations[i].SupplierHotelPriceId, date: date });
	}
	//alert(JSON.stringify(schedules)); 

	//alert(data.LstSupplierHotelPrice.length);
	for (var i = 0; i < data.LstSupplierHotelPrice.length; i++)
	{
	    colors[data.LstSupplierHotelPrice[i].SupplierHotelPriceId] = data.LstSupplierHotelPrice[i].Color;
	}

	//alert(JSON.stringify(colors));

	var scheduleOptions1 = { colors: colors };

	$(obj).pignoseCalendar({
		scheduleOptions: scheduleOptions1,
		schedules: schedules,
		select: function (date, context)
		{
			//for (var idx in context.storage.schedules)
			//{
			//	var schedule = context.storage.schedules[idx];

			//	alert(schedule.name);
		    //}

		    $("#hdnSupplierPriceId").val(context.storage.schedules[0].name);

		    $("[name='SupplierHotelTariffDurations.TariffDate']").val(context.storage.schedules[0].date);

			//alert(date);
			//alert(context.storage.schedules.name);
			//alert('events for this date', context.storage.schedules.name);
		}
	});
}
