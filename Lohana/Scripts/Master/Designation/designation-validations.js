$(document).ready(function () {

    $("#frmDesignation").validate({

        rules: {
           
            "Designation.DesignationName":
             {
                 required: true,
                 CheckDesignationNameExist: true
             }

        },
        messages: {
          
            "Designation.DesignationName":
                {
                    required: "Designation name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckDesignationNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Designation/CheckDesignationNameExist', { DesignationName: value }, $("#txtDesignationName"), $("#hdnDesignationName"));

    }, "Designation name already exist.")

});





