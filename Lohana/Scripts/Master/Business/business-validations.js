$(document).ready(function () {

    $("#frmBusiness").validate({

        rules: {

            "Business.BusinessName":
             {
                 required: true,
                 CheckBusinessNameExist: true
             }

        },
        messages: {
          
            "Business.BusinessName":
                {
                    required: "Service name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckBusinessNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Business/CheckBusinessNameExist', { BusinessName: value }, $("#txtBusinessName"), $("#hdnBusinessName"));

    }, "Business name already exist.")

});





