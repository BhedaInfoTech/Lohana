﻿
function LoadTaxFormulaCharges(taxFormulaId, supplierHotelTriffPriceId)
{
	if (supplierHotelTriffPriceId == null || supplierHotelTriffPriceId == "" || supplierHotelTriffPriceId == undefined)
	{
		supplierHotelTriffPriceId = 0;
	}
	$(".taxFormulaChargesGrid").load("/SupplierHotelTariff/GetTaxFormulaCharges", { taxFormulaId: taxFormulaId, supplierHotelTriffPriceId: supplierHotelTriffPriceId }, function ()
	{
        // Convert textbox to spinner
    	$("input.percentage").TouchSpin({
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
            if ($("#frmSupplierHotelTariffPrice").valid()) {
                CalculatePrice(true);
            }
        });

        $("#tblFormulaDetails").find(".calculatedprice").on('change', function ()
        {
        	if ($("#frmSupplierHotelTariffPrice").valid())
        	{
        		CalculatePrice(false);
        	}
        });
    });
}

function CalculatePrice(isPercentage) {

    var chargeTotal = 0.0;

    var totalTax = 0.0;

   // $(".calculatedprice").text("");

    $("[data-chargeformula]").each(function (i) {

        debugger;

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

                    amount = parseFloat(chargeId.parents("tr").find(".calculatedprice").val());
                  
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

        var calculatedAmt = 0.0;

        if (isPercentage)
        {
        	calculatedAmt = parseFloat(chargeTotal * (percentage / 100));

        	$(this).parents("tr").find(".calculatedprice").val(calculatedAmt.toFixed(2));
        }
        else
        {
        	calculatedAmt = parseFloat($(this).parents("tr").find(".calculatedprice").val());

        	var per = parseFloat((calculatedAmt * 100) / (chargeTotal));

        	$(this).parents("tr").find(".percentage").val(per.toFixed(2));
        }

        totalTax = parseFloat(totalTax + calculatedAmt);
       
    });

    $("span.totaltax").text(totalTax.toFixed(2));

    var netRate = parseFloat($(".specialprice").val()) + parseFloat(totalTax);

    $(".netrate").val(netRate.toFixed(2));

    //var noofnight = $("[name='SupplierHotelPrice.NoOfNight']").val();

    //var netRatePerNight = (parseFloat(netRate)) / noofnight;

    //$(".netratepernight").val(netRatePerNight.toFixed(2));
}

function displayCommision()
{
    var publishPrice = $("input.publishprice").val();

    var specialPrice = $("input.specialprice").val();

    $("input.commissionprice").val((parseFloat(publishPrice) - parseFloat(specialPrice)).toFixed(2));
}