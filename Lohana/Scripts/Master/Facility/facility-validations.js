$(document).ready(function () {

    $("#frmFacility").validate({

        rules: {

            "Facility.FacilityType":
          {
              FacilityType: true,
          },
            "Facility.FacilityName":
             {
                 required: true,
                 CheckFacilityNameExist: true
             }

        },
        messages: {


            "Facility.FacilityName":
                {
                    required: "Facility name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckFacilityNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Facility/CheckFacilityNameExist', { FacilityName: value }, $("#txtFacilityName"), $("#hdnFacilityName"));

    }, "Facility name already exist.")


    jQuery.validator.addMethod("FacilityType", function (value, element) {

        var result = true;

        if ($("#drpFacilityType").val() == "0")
        {
            result = false;
        }

        return result;

    }, "Facility type is required.");


});





