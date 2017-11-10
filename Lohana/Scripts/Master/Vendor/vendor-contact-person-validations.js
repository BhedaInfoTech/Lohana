
$(document).ready(function () {

    $("#frmContactPerson").validate({

        rules: {

            "Vendor.ContactPerson.ContactPersonName":
             {
                 required: true,

             },
            "Vendor.ContactPerson.DesignationId":
             {
                 DropdownRequired: true
             },

            "Vendor.ContactPerson.PhoneNo":
             {
                 required: true,
                 number: true,
             },
            "Vendor.ContactPerson.MobileNo":
             {
                 required: true,
                 number: true,
             },
            "Vendor.ContactPerson.FaxNo":
             {
                 required: true,
             },
            "Vendor.ContactPerson.EmailId":
             {
                 required: true,
                 email: true,
             },
        },
        messages: {

            "Vendor.ContactPerson.ContactPersonName":
             {
                 required: "Contact person name is required.",

             },
            "Vendor.ContactPerson.DesignationId":
             {
                 DropdownRequired: "Designation is required.",

             },          
            "Vendor.ContactPerson.PhoneNo":
            {
                required: "Phone number is required.",
                number: "Enter only digit.",
            },
            "Vendor.ContactPerson.MobileNo":
             {
                 required: "Mobile number is required.",
             },
            "Vendor.ContactPerson.FaxNo":
             {
                 required: "Fax number is required.",
             },
            "Vendor.ContactPerson.EmailId":
             {
                 required: "Enter valid email id.",
             },

        }

    });


    jQuery.validator.addMethod("Designation", function (value, element) {
        var result = true;

        if ($("#drpDesignation").val() == "0") {
            result = false;
        }

        return result;

    }, "Designation is required.");


});