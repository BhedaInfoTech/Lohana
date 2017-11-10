$(document).ready(function ()
{
    // On selecting "Publish Price"
    $("input.publishprice").on('change', function ()
    {
        if ($("#frmTaxFormulaCalDemo").valid())
        {
            displayCommision();
        }

        if ($("#drpFormula").val() != "")
        {
        	CalculatePrice()
        }

    });

    // On selecting "Special Price"
    $("input.specialprice").on('change', function ()
    {
        if ($("#frmTaxFormulaCalDemo").valid())
        {
            displayCommision();
        }

        if ($("#drpFormula").val() != "")
        {
			CalculatePrice()
        }
        
    });

    // On selecting formula dropdown
    $("#drpFormula").on('change', function ()
    { 
        LoadTaxFormulaCharges($("#drpFormula").val());
    });
});