function SaveSightSeeingTariffPrice() {

    $("#frmSightSeeingTariffPrice").blur();

    var ChargesList = [];

    $("[data-chargeformula]").each(function (i) {

        var charges =

                {
                    Percentage: $(this).parents("tr").find(".percentage").val(),

                    ChargesId: $(this).parents("tr").find("[data-chargeid]").attr("data-chargeid"),

                    CalculatedPrice: $(this).parents("tr").find(".calculatedprice").val(),

                    TotalTaxPrice: $(this).parents("tr").find(".totaltax").text()//,


                }

        ChargesList.push(charges);
    });


    var sstViewModel = {

        SightSeeingTariffPrice: {

            SightSeeingTariffPriceId: $("[name='SightSeeingTariffPrice.SightSeeingTariffPriceId']").val(),

            SightSeeingTariffOccupancyId: $("[name='SightSeeingTariffPrice.SightSeeingTariffOccupancyId']").val(),

            SightSeeingTariffDurationId: $("[name='SightSeeingTariffPrice.SightSeeingTariffDurationId']").val(),

            SightSeeingTariffId: $("[name='SightSeeingTariffPrice.SightSeeingTariffId']").val(),

            PublishPrice: $("[name='SightSeeingTariffPrice.PublishPrice']").val(),

            SpecialPrice: $("[name='SightSeeingTariffPrice.SpecialPrice']").val(),

            CommissionPrice: $("[name='SightSeeingTariffPrice.CommissionPrice']").val(),

            FormulaId: $("#drpFormula").val(),

            TotalTaxPrice: $("span.totaltax").text(),

            NetRate: $("[name='SightSeeingTariffPrice.NetRate']").val(),

            SightSeeingTariffCharges: ChargesList,

            Color: $("[name='SightSeeingTariffPrice.Color']").val(),

        },


    }
    var url

    if ($("[name='SightSeeingTariffPrice.SightSeeingTariffPriceId']").val() == 0) {
        url = "/SightSeeingTariff/InsertSightSeeingTariffPrice"
    }
    else {
        url = "/SightSeeingTariff/UpdateSightSeeingTariffPrice"
    }

    PostAjaxJson(url, sstViewModel, AfterPriceSave);
}

function AfterPriceSave(data) {

    FriendlyMessage(data);

    ResetPrice();

    GetSightSeeingTariffPrice();
}

function ResetPrice() {

    $("[name='SightSeeingTariffPriceFilter.SightSeeingTariffPriceId']").val('');

    $("#txtPublishPrice").val('');

    $("#txtSpecialPrice").val('');

    $("#txtCommissionPrice").val('');

    $("#drpFormula").val('0');

    $("#drpFormula").trigger("change");

    $("#txtNetRate").val('');

    $("#txtNetRateAsPerNight").val('');

    $("span.totaltax").text('');
}

function GetSightSeeingTariffPrice() {

    $("#dvPriceListing").load("/SightSeeingTariff/GetSightSeeingTariffPrice", { sightseeingTariffOccupancyId: $("[name='SightSeeingTariffPrice.SightSeeingTariffOccupancyId']").val() }, null);
}

function GetSightSeeingTariffPriceById() {
    var sstViewModel =
		{
		    SightSeeingTariffPrice: {

		        SightSeeingTariffPriceId: $("[name='SightSeeingTariffPrice.SightSeeingTariffPriceId']").val(),
		    }
		}

    PostAjaxJson("/SightSeeingTariff/GetSightSeeingTariffPriceById", sstViewModel, BindSightSeeingTariffPrice);
}

function BindSightSeeingTariffPrice(data) {

    debugger;

    $("[name='SightSeeingTariffPrice.SightSeeingTariffPriceId']").val(data.SightSeeingTariffPrice.SightSeeingTariffPriceId)
    
    $("[name='SightSeeingTariffPrice.PublishPrice']").val(data.SightSeeingTariffPrice.PublishPrice);
 
    $("[name='SightSeeingTariffPrice.SpecialPrice']").val(data.SightSeeingTariffPrice.SpecialPrice);
   

    $("[name='SightSeeingTariffPrice.CommissionPrice']").val(data.SightSeeingTariffPrice.CommissionPrice);
    

    $("#drpFormula").val(data.SightSeeingTariffPrice.FormulaId);

    $("span.totaltax").text(data.SightSeeingTariffPrice.TotalTaxPrice);

    $("[name='SightSeeingTariffPrice.NetRate']").val(data.SightSeeingTariffPrice.NetRate);

    $("#dvColorPicker").colorpicker('setValue', data.SightSeeingTariffPrice.Color);

    $("[name='SightSeeingTariffPrice.Formula']").val(data.SightSeeingTariffPrice.FormulaId)

    $('#drpFormula').trigger('change');

    //View     

    $("#lblPublishPrice").text(data.SightSeeingTariffPrice.PublishPrice);

    $("#lblSpecialPrice").text(data.SightSeeingTariffPrice.SpecialPrice);

    $("#lblCommissionPrice").text(data.SightSeeingTariffPrice.CommissionPrice);

    $("#lblFormula").text(data.SightSeeingTariffPrice.FormulaId);

    $("#lblTotalTaxPrice").text(data.SightSeeingTariffPrice.TotalTaxPrice);

    $("#lblNetRate").text(data.SightSeeingTariffPrice.NetRate);
}

function GetSightSeeingTariffDuration(obj) {
    GetAjax("/SightSeeingTariff/GetSightSeeingTariffDurationPrice", { sightseeingTariffOccupancyId: $("[name='SightSeeingTariffPrice.SightSeeingTariffOccupancyId']").val() }, function (data) { BindSightSeeingTariffDuration(data, obj) });
}

function BindSightSeeingTariffDuration(data, obj) {
    var schedules = [];

    var colors = {};
    
    for (var i = 0; i < data.SightSeeingTariffDates.length; i++) {
        var date = ToJavaScriptDateYear(data.SightSeeingTariffDates[i].TariffDate);

        schedules.push({ name: data.SightSeeingTariffDates[i].SightSeeingTariffPriceId, date: date });
    }

    for (var i = 0; i < data.SightSeeingTariffPrices.length; i++) {
        colors[data.SightSeeingTariffPrices[i].SightSeeingTariffPriceId] = data.SightSeeingTariffPrices[i].Color;
    }

    var scheduleOptions1 = { colors: colors };

    $(obj).pignoseCalendar({
        scheduleOptions: scheduleOptions1,
        schedules: schedules,
        select: function (date, context) {

            $("[name='SightSeeingTariffDates.SightSeeingTariffOccupancyId']").val(data.SightSeeingTariffDates[0].SightSeeingTariffOccupancyId);

            $("[name='SightSeeingTariffDates.TariffDate']").val(context.storage.schedules[0].date);
           
        }
    });
}
