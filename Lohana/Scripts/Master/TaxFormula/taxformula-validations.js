$(document).ready(function () {

    $("#frmTaxFormula").validate({

        rules: {

            "TaxFormula.TaxFormulaName":
            {
                required: true,
                checkTaxFormulaExist: true
            },
            "TaxFormulaCharges.ChargesId":
             {
                 chargeNameRequired: true,
                 checkChargeNameExist: true,
                 checkInUseCharge:true
             },
            "Taxformulacharges.ChargeFormula":
             {
                 chargeFormulaRequired: true,
                 checkSequence: true
             }
        },
        messages: {

            "TaxFormula.TaxFormulaName":
                {
                    required: "Tax formula name is required."
                },
            "TaxFormulaCharges.ChargesId":
                {
                    required: "Charge name is required."
                },
            "Taxformulacharges.ChargeFormula":
                {
                    required: "Tax formula is required."
                }
        }

    });

    jQuery.validator.addMethod("checkTaxFormulaExist", function (value, element) {
        var _taxFormulaId = $("#hdnTaxFormulaId").val();

        return GetAjaxAlreadyExists('/TaxFormula/CheckTaxFormulaNameExist', { taxFormulaName: value, taxFormulaId: _taxFormulaId }, $("#txtTaxFormula"));

    }, "Tax formula already exist.");

    jQuery.validator.addMethod("chargeNameRequired", function (value, element) {
        var result = true;

        if ($("#hdnTaxFormulaId").val() == 0) {
            if ($("#tblTaxFormulaChargeBehaviour tbody tr").length == 0);
            {
                if ($("#drpCharges").val() == "0") {
                    result = false;
                }
            }
        }

        return result;

    }, "Charge name is required.");

    jQuery.validator.addMethod("checkInUseCharge", function (value, element)
    {
        var result = true;

        var obj = $("#tblTaxFormulaChargeBehaviour tbody tr");

        var oldChargeId = $('#hdnChargesId').val();        

        if (obj.length > 0);
        {
            $(obj).each(function (index)
            {
                var arrayInUseCharges = $(this).find("input[type=radio]").attr("data-chargeformula").split(",");

                $(arrayInUseCharges).each(function (index,value)
                {
                    if (oldChargeId == value)
                    {
                        result = false;
                    }
                });
            });
        }

        return result;

    }, "Cannot edit charge name, as it is in use.");

    jQuery.validator.addMethod("checkChargeNameExist", function (value, element) {

        var result = true;

        var obj = $("#tblTaxFormulaChargeBehaviour tbody tr");

        var oldChargeId = $('#hdnChargesId').val();

        var selectedChargeId = $('#drpCharges').val();

        if (obj.length > 0);
        {
            $(obj).each(function (index) {
                var existingChargeId = $(this).find("input[type=radio]").attr("data-chargesid");

                if (oldChargeId != selectedChargeId && existingChargeId == selectedChargeId) {
                    result = false;
                }
            });
        }

        return result;

    }, "Charge name already exist.");

    jQuery.validator.addMethod("chargeFormulaRequired", function (value, element) {
        var result = true;

        if ($.trim($('#drpCharges').val()) == "0") {
            // Do nothing... 
            //added this block as "!=" operator doesn't work..
        }
        else {
            if ($("#drpTaxFormula").val() == null) {
                result = false;
            }
        }

        return result;

    }, "Charge formula is required.");


    jQuery.validator.addMethod("checkSequence", function (value, element)
    {
        var result = true;
        
        var chargeFormula = $('#drpTaxFormula').val();

        var standardValues = $('#hdnStandardValue').val().split(",");

        standardValues.push("+");

        standardValues.push("-");

        var obj = $("#tblTaxFormulaChargeBehaviour tbody tr");

        if (obj.length == 0)
        {
            $(chargeFormula).each(function (index, value)
            {
                if ($.inArray(value, standardValues) == -1)
                {
                    result = false;
                }
            });
        }
        else
        {
            $(obj).each(function (index)
            {
                var existingChargeId = $(this).find("input[type=radio]").attr("data-chargesid");

                standardValues.push(existingChargeId);
            });

            $(chargeFormula).each(function (index, value)
            {
                if ($.inArray(value, standardValues) == -1)
                {
                    result = false;
                }
            });
        }

        return result;

    }, "Please ensure that you are using combination of 'standard' and 'in use' charges.");

});





