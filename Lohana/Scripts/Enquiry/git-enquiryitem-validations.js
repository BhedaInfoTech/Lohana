$(document).ready(function () {

    $("#frmgitdetails").validate({

        ignore: ":hidden",

        rules: {

            "Enquiry.category":
             {
                 DropdownRequired: true,
             },
            "Enquiry.packageType":
             {
                 DropdownRequired: true,
             },
            "Enquiry.packagename":
             {
                 required: true,
             },
            "Enquiry.noOfNights":
           {
               required: true,
               number: true,
           },
            "Enquiry.enquiryAssignedType":
             {
                 DropdownRequired: true,
             },
            "Enquiry.assigneName":
             {
                 required: true,
             },
             "Enquiry.destination":
             {
                 DropdownRequired: true,

            },
        },
        messages: {

            "Enquiry.category":
            {
                DropdownRequired: "Category is required",
            },
            "Enquiry.packageType":
             {
                 DropdownRequired: "Package type is required",

             },
            "Enquiry.packagename":
             {
                 required: "Package name is required",

             },
            "Enquiry.noOfNights":
          {
              required: "No of nights is required",
              number: "Please enter numbers",

          },
            "Enquiry.enquiryAssignedType":
             {
                 DropdownRequired: "Assigned type is required",

             },
            "Enquiry.assigneName":
             {
                 required: "Assigne name is required",

             },

            "Enquiry.destination":
            {
                DropdownRequired: "Destination is required",

            },
        }

    });
});


