$(document).ready(function () {

    $("#frmFacilityType").validate({

        rules: {


            "FacilityType.FacilityTypeName":
             {
                 required: true,
                 CheckFacilityTypeNameExist: true
             }

        },
        messages: {


            "FacilityType.FacilityTypeName":
                {
                    required: "Facilitytype name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckFacilityTypeNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/FacilityType/CheckFacilityTypeNameExist', { FacilityTypeName: value }, $("#txtFacilityTypeName"), $("#hdnFacilityTypeName"));

    }, "Facilitytype name already exist.")

});





