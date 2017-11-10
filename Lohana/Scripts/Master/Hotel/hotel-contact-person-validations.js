$(document).ready(function () {


    $("#frmContactPerson").validate({
        rules: {
            "Hotel.ContactPerson.ContactPersonName":
             {
                 required: true,
             },
            "Hotel.ContactPerson.Designation":
             {
                 DropdownRequired: true
             },

            "Hotel.ContactPerson.PhoneNo":
             {
                 number: true,
                 required: true,

             },
            "Hotel.ContactPerson.MobileNo":
            {
                required: true,
                number: true,

            },
            "Hotel.ContactPerson.EmailId":
             {
                 required: true,
                 email: true,
             },
            "Hotel.ContactPerson.FaxNo":
           {
               required: true,
           },
        },
        messages: {
            "Hotel.ContactPerson.ContactPersonName":
             {
                 required: "Contact person name is required.",
             },
            "Hotel.ContactPerson.Designation":
             {
                 DropdownRequired: "Designation is required.",
             },
            "Hotel.ContactPerson.PhoneNo":
             {
                 required: "Phone number is required.",
                 number: "Enter digits only."
             },
            "Hotel.ContactPerson.MobileNo":
             {
                 required: "Mobile number is required.",
                 number: "Enter digits only."
             },
            "Hotel.ContactPerson.EmailId":
             {
                 required: "Email id is required.",
                 email: "Invalid email id."
             },
            "Hotel.ContactPerson.FaxNo":
          {
              required: "Fax number is required.",
          },
        }
    });

});