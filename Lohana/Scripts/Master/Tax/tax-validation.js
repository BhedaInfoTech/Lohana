$(document).ready(function () {

    $("#frmTax").validate({

        rules: {

            "Tax.TaxName":
             {
                 required: true,
                 CheckTaxNameExist: true
             },

            "Tax.TaxCode":
                {
                    required: true,
                    CheckTaxCodeExist: true
                },

            "Tax.TaxRate":
                {
                    required: true
                }

        },
        messages: {

            "Tax.TaxName":
                {
                    required: "Tax Name is Required"
                },

            "Tax.TaxCode" :
                {
                    required: "Tax Code is Reuired"
                },

            "Tax.TaxRate":
                {
                    required: "Tax Rate is Reuired"
                }
        }

    });

    jQuery.validator.addMethod("CheckTaxNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Tax/CheckTaxNameExist', { TaxName: value }, $("#txtTaxName"), $("#hdnTaxName"));

    }, "Tax Name Already Exist");

    jQuery.validator.addMethod("CheckTaxCodeExist", function (value, element) {

        return GetAjaxAlreadyExists('/Tax/CheckTaxCodeExist', { TaxCode: value }, $("#txtTaxCode"), $("#hdnTaxCode"));

    }, "Tax Code Already Exist")

});