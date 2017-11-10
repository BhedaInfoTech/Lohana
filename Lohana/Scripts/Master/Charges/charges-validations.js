$(document).ready(function () {

    $("#frmCharges").validate({

        rules: {
          
            "Charges.ChargesName":
             {
                 required: true,
                 CheckChargesNameExist: true
             },
            "Charges.Abbreviations":
             {
                 required: true,
                 CheckChargesAbbrevationExist: true
             },

        },
        messages: {
         
            "Charges.ChargesName":
                 {
                     required: "Charges name is required."
                 },
            "Charges.Abbreviations":
                {
                    required: "Charges abbreviation is required."
                }
        }

    }); 

    jQuery.validator.addMethod("CheckChargesNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Charges/CheckChargesNameExist', { ChargesName: value }, $("#txtChargesName"), $("#hdnChargesName"));

    }, "Charges name already exist.")

    jQuery.validator.addMethod("CheckChargesAbbrevationExist", function (value, element) {

        debugger;

        return GetAjaxAlreadyExists('/Charges/CheckChargesAbbrevationExist', { chargesabbr: value }, $("#txtChargesAbbr"), $("#hdnAbbreviations"));

    }, "Charges abbreviations already exist.")

  


});





