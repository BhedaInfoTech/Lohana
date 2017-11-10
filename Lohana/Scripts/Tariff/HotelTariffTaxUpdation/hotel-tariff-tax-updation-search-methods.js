function GetHotelTariffTax() {

    var htuViewModel =
		{
		    HotelTariffTax: {

		        VendorId: $("#drpVendor").val(),

		        HotelId: $("#drpHotel").val(),

		        RoomTypeId: $("#drpRoomType").val(),

		        MealId: $("#drpMeal").val(),

		        FormulaId: $("#drpTaxFormula").val(),

		        FromDate: $("[name='HotelTariffTax.FromDate']").val(),

		        ToDate: $("[name='HotelTariffTax.ToDate']").val(),

		    },

		    Pager: {

		        CurrentPage: $('#tblHotelTariffTaxDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/HotelTariffTaxUpdation/GetHotelTariffTaxUpdation", htuViewModel, BindHotelTariffTaxUpdations);
}

function BindHotelTariffTaxUpdations(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VendorName", "HotelName", "RoomTypeName", "MealName", "TaxFormulaName", "FromDate", "ToDate"],
        primayKey: "",
        hiddenFields: ["HotelTariffId", "FormulaId", "HotelTariffPriceDetailsId", "HotelTariffRoomDetailsId", "HotelTariffDurationDetailsId","PublishPrice", "CommissionPrice", "SpecialPrice", "NoOfNight"],
        headerNames: ["Vendor", "Hotel", "RoomType", "Meal", "TaxFormula", "FromDate", "ToDate","Action"],
        data: list.dt,
        
    }

    buildHtmlchkboxTable(kTable, $('#tblHotelTariffTaxDetails'));

    BindPagination(list.Pager, $('#tblHotelTariffTaxDetails'));


}

function Pagination(CurrentPage) {

    $('#tblHotelTariffTaxDetails').attr("data-current-page", CurrentPage);

    GetHotelTariffTax();

}

//function KeepChecks()
//{
//    var checkedList = [];

//    $("#tblHotelTariffTaxDetails").each(function() {

//        $('input[type="checkbox"]:checked').each(function () {

//            var hoteltariffid = $(this).attr("data-hoteltariffid");

//            var demo = SS
//                {
//                    HotelTariffId: hoteltariffid,
//                }
//            checkedList.push(demo)
//        });
//    });
//}


//Price Details

function GetHotelTariffPrice() {

    var htuViewModel =
		{
		    HotelTariffPrice: {

		        HotelTariffId: $("[name='HotelTariffPrice.HotelTariffId']").val(),

		        HotelTariffDurationDetailsId: $("[name='HotelTariffPrice.HotelTariffDurationDetailsId']").val(),

		        HotelTariffRoomDetailsId: $("[name='HotelTariffPrice.HotelTariffRoomDetailsId']").val(),

		    }
		}

    PostAjaxJson("/HotelTariffTaxUpdation/GetHotelTariffPrice", htuViewModel, BindHotelTariffPrice);
}

function BindHotelTariffPrice(data) {

    $("[name='HotelTariffPrice.HotelTariffPriceDetailsId']").val(data.HotelTariffPrice.HotelTariffPriceDetailsId)

    $("[name='HotelTariffPrice.PublishPrice']").val(data.HotelTariffPrice.PublishPrice),

    $("[name='HotelTariffPrice.SpecialPrice']").val(data.HotelTariffPrice.SpecialPrice),

    $("[name='HotelTariffPrice.CommissionPrice']").val(data.HotelTariffPrice.CommissionPrice),

    $("#drpFormula").val(data.HotelTariffPrice.FormulaId),

    $("span.totaltax").text(data.HotelTariffPrice.TotalTaxPrice),

    $("[name='HotelTariffPrice.NetRate']").val(data.HotelTariffPrice.NetRate),

    $("[name='HotelTariffPrice.NetRateAsPerNight']").val(data.HotelTariffPrice.NetRatePerNight)

    $('#drpFormula').trigger('change');

    $('#drpFormula').attr("disabled", true);

}

// Tax Formula Charges Details

function LoadTaxFormulaCharges(taxFormulaId, hoteltriffpricedetailsid) {

   

    $(".taxFormulaChargesGrid").load("/HotelTariffTaxUpdation/GetTaxFormulaCharges", { TaxFormulaId: taxFormulaId, HotelTriffPriceDetailsId: hoteltriffpricedetailsid }, function () {
        // Convert textbox to spinner
        $("input[name='demo2']").TouchSpin({
            min: 0,
            max: 100,
            step: 0.1,
            decimals: 2,
            boostat: 5,
            maxboostedstep: 10,
            postfix: '%',
            buttondown_class: "btn btn-secondary",
            buttonup_class: "btn btn-secondary"
        });

        // On selecting formula dropdown
        $("#tblFormulaDetails").find(".percentage").on('change', function () {
            var obj = $(this);

            if ($("#frmHotelTariffPrice").valid()) {
                CalculatePrice();
            }
        });
    });
}

function CalculatePrice() {
    var chargeTotal = 0.0;

    var totalTax = 0.0;

    // $(".calculatedprice").text("");

    $("[data-chargeformula]").each(function (i) {
        var dataarray = $(this).attr("data-chargeformula").split(",");

        var percentage = $(this).parents("tr").find(".percentage").val();
        //alert(dataarray);

        chargeTotal = 0.0;

        var amount = 0.0;

        for (var i = 0 ; i < dataarray.length; i++) {
            if (dataarray[i] == "+" || dataarray[i] == "-") {
                //i++;

                //if (value == "+")
                //{
                //	chargeTotal = parseFloat(chargeTotal + amount);
                //}
                //else if (value == "-")
                //{
                //	chargeTotal = parseFloat(chargeTotal - amount);
                //}
            }
            else {
                var chargeId = $("[data-chargeid='" + dataarray[i] + "']");



                var isStandard = chargeId.attr("data-isstandard");

                amount = 0.0;

                if (isStandard == "true") {

                    amount = parseFloat(chargeId.val())
                }
                else {
                    amount = parseFloat(chargeId.parents("tr").find(".calculatedprice").text());
                }



                if (dataarray.length == (i + 1)) {
                    if (i == 0) {
                        chargeTotal = amount;
                    }
                    else {
                        if (dataarray[i - 1] == "+") {
                            chargeTotal = chargeTotal + amount;
                        }
                        else if (dataarray[i - 1] == "-") {
                            chargeTotal = chargeTotal - amount;
                        }
                    }
                }
                else {
                    if (i == 0) {
                        chargeTotal = amount;
                    }
                    else {
                        if (dataarray[i - 1] == "+") {
                            chargeTotal = chargeTotal + amount;
                        }
                        else if (dataarray[i - 1] == "-") {
                            chargeTotal = chargeTotal - amount;
                        }
                    }
                }
            }
        }

        var calculatedAmt = parseFloat(chargeTotal * (percentage / 100));

        $(this).parents("tr").find(".calculatedprice").text(calculatedAmt.toFixed(2));

        totalTax = totalTax + calculatedAmt;

    });

    $("span.totaltax").text(totalTax.toFixed(2));

    var netRate = parseFloat($(".specialprice").val()) + parseFloat(totalTax);

    $(".netrate").val(netRate.toFixed(2));

    var noofnight = $("[name='HotelTariffPrice.NoOfNight']").val();

    var netRatePerNight = (parseFloat(netRate)) / noofnight;

    $(".netratepernight").val(netRatePerNight.toFixed(2));
}


// Update Tax Formula Charges

function LoadTaxFormulaChargesUpdate(taxFormulaId) {

    $(".taxFormulaChargesGrid").load("/HotelTariffTaxUpdation/GetTaxFormulaChargesUpdate", { TaxFormulaId: taxFormulaId }, function () {

        

        // Convert textbox to spinner
        $("input[name='demo2']").TouchSpin({
            min: 0,
            max: 100,
            step: 0.1,
            decimals: 2,
            boostat: 5,
            maxboostedstep: 10,
            postfix: '%',
            buttondown_class: "btn btn-secondary",
            buttonup_class: "btn btn-secondary"
        });

    });
}

// SaveTRaxFormulaChargesCheckBoxList

function SaveTaxFormulaChargesCheckboxList() {

    $('input[type="checkbox"]:checked').each(function () {

        debugger;

        var hoteltariffid = $(this).attr("data-hoteltariffid");

        var hoteltariffpricedetailsid = $(this).attr("data-hoteltariffpricedetailsid");

        var hoteltariffroomdetailsid = $(this).attr("data-hoteltariffroomdetailsid");

        var publishprice = $(this).attr("data-publishprice");

        var commissionprice = $(this).attr("data-commissionprice");

        var specialprice = $(this).attr("data-specialprice");

        var noofnight = $(this).attr("data-noofnight");

        var hoteltariffdurationdetailsid = $(this).attr("data-hoteltariffdurationdetailsid");

        var demo = {

            HotelTariffId: hoteltariffid,
            HotelTariffPriceDetailsId: hoteltariffpricedetailsid,
            HotelTariffRoomDetailsId: hoteltariffroomdetailsid,
            HotelTariffDurationDetailsId: hoteltariffdurationdetailsid,
            PublishPrice: publishprice,
            CommissionPrice: commissionprice,
            SpecialPrice: specialprice,
            NoOfNight : noofnight,
        }

        HotelTariffUpdateChargesList.push(demo);

    });

    var ChargesList = [];

    $("[data-chargeid]").each(function (i) {

        debugger;

        var charges =

                {
                    Percentage: $(this).parents("tr").find(".percentage").val(),

                    ChargesId: $(this).parents("tr").find("[data-chargeid]").attr("data-chargeid"),

                    HotelTariffCalOn: $(this).parents("tr").find("[data-chargeformula]").attr("data-chargeformula"),

                }

        ChargesList.push(charges);
    });

    var htuViewModel = {

        HotelTariffPrices: HotelTariffUpdateChargesList,

        HotelTariffPrice: {

            HotelTariffCharges: ChargesList,

        },

        HotelTariffTax: {

            TaxFormulaId: $("#drpFormulaUpdate").val(),
        }
    }

    debugger;

    var url = "";

    url = "/HotelTariffTaxUpdation/UpdateHotelTariffTaxFormula"

    PostAjaxWithProcessJson(url, htuViewModel, AfterTaxFormulaUpdation, $("#frmHotelTariffTaxUpdation"));

}

function AfterTaxFormulaUpdation(data) {

    FriendlyMessage(data);

    GetHotelTariffTax();

    $(".updatetax").modal('hide');

}






































//function GetHotelTariffTaxChargesView() {

//    var htuViewModel =
//		{
//		    HotelTariffTax: {

//		        HotelTariffId: $("[name='HotelTariffTax.HotelTariffId']").val(),

//		        HotelTariffDurationDetailsId: $("[name='HotelTariffTax.HotelTariffDurationDetailsId']").val(),

//		        HotelTariffRoomDetailsId: $("[name='HotelTariffTax.HotelTariffRoomDetailsId']").val(),

//		        HotelTariffPriceDetailsId: $("[name='HotelTariffTax.HotelTariffPriceDetailsId']").val(),

//		        FormulaId: $("[name='HotelTariffTax.FormulaId']").val(),

//		    }
//		}

//    PostAjaxJson("/HotelTariffTaxUpdation/GetHotelTariffTaxCharges", hutViewModel, BindHotelTariffTaxCharges);
//}