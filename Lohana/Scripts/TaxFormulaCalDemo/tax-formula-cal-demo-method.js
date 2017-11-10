function LoadTaxFormulaCharges(taxFormulaId)
{
    $(".taxFormulaChargesGrid").load("/TaxFormulaCalDemo/GetTaxFormulaCharges", { TaxFormulaId: taxFormulaId }, function ()
    {
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
        $("#tblFormulaDetails").find(".percentage").on('change', function ()
        {
            var obj = $(this);

            if ($("#frmTaxFormulaCalDemo").valid())
            {
                CalculatePrice();
            }            
        });
    });
}

function CalculatePrice()
{
	var chargeTotal = 0.0;

	var totalTax = 0.0;

	$("[data-chargeformula]").each( function (i)
	{
		var dataarray = $(this).attr("data-chargeformula").split(",");

		var percentage = $(this).parents("tr").find(".percentage").val();
		//alert(dataarray);

		 chargeTotal = 0.0;

		var amount = 0.0;
		
		for (var i = 0 ; i < dataarray.length; i++)
		{
			if (dataarray[i] == "+" || dataarray[i] == "-")
			{
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
			else
			{
				var chargeId = $("[data-chargeid='" + dataarray[i] + "']");

				var isStandard = chargeId.attr("data-isstandard");

				amount = 0.0;

				if (isStandard =="true")
				{
					amount = parseFloat(chargeId.val())
				}
				else
				{
					amount = parseFloat(chargeId.parents("tr").find(".calculatedprice").text());
				}

				

				if (dataarray.length == (i+1))
				{
					if (i == 0)
					{
						chargeTotal = amount;
					}
					else
					{
						if (dataarray[i - 1] == "+")
						{
							chargeTotal = chargeTotal + amount;
						}
						else if (dataarray[i - 1] == "-")
						{
							chargeTotal = chargeTotal - amount;
						}
					}
				}
				else
				{
					if (i == 0)
					{
						chargeTotal = amount;
					}
					else
					{
						if (dataarray[i - 1] == "+")
						{
							chargeTotal = chargeTotal + amount;
						}
						else if (dataarray[i - 1] == "-")
						{
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
}

//function CalculatePrice(control)
//{
//    var percentage = parseFloat(control.val());

//    var formulacharges = $(control).parents("tr").find("td[data-chargeformula]").attr("data-chargeformula");

//    var dataarray = formulacharges.split(",");

//    // Default Values
//    var operator = "+", calculatedPrice = 0, amount = 0;

//    $.each(dataarray, function (index, value)
//    {
//        if (value == "+" || value == "-")
//        {
//            operator = value;
//        }
//        else
//        {
//            // Fetch values which will be part of calculation
//            var obj = $(".calsection").find("[data-chargeid=" + value + "]");

//            var isStandard = eval(obj.attr("data-isstandard"));

//            if (isStandard)
//            {
//                amount = parseFloat(obj.val());
//            }
//            else
//            {
//                amount = parseFloat(obj.parents("tr").find(".calculatedprice").text());
//            }

//            // Perform actual calculation
//            if (operator == "+")
//            {
//                calculatedPrice = parseFloat(calculatedPrice) + amount;
//            }
//            else if (operator == "-")
//            {
//                calculatedPrice = parseFloat(calculatedPrice) - amount;
//            }
//        }
//    });

//    // Calculate and display "Calculated Charge Amount"
//    var calculatedAmt = parseFloat(calculatedPrice * (percentage / 100));

//    control.parents("tr").find(".calculatedprice").text(calculatedAmt.toFixed(2));

//    // Calculate and display "Total Tax"
//    var totalTax = 0;

//    $('#tblFormulaDetails tbody tr').each(function ()
//    {
//        if ($(this).find(".calculatedprice").text() != "")
//        {
//            totalTax = totalTax + parseFloat($(this).find(".calculatedprice").text());
//        }
//    });

//    $("span.totaltax").text(totalTax.toFixed(2));

//    // Calculate and display "Net Rate"
//    var netRate = parseFloat($(".specialprice").val()) + parseFloat(totalTax);

//    $(".netrate").val(netRate.toFixed(2));

//    // Trigger change event
//    $("#tblFormulaDetails").find(".percentage").trigger("change");
//}

function displayCommision()
{
    var publishPrice = $("input.publishprice").val();

    var specialPrice = $("input.specialprice").val();

    $("input.commissionprice").val(parseFloat(publishPrice) - parseFloat(specialPrice)).toFixed(2);
}