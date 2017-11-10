$(document).ready(function () {

    $("#frmfitdetails").validate({

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
            "Enquiry.destination":
             {
                 DropdownRequired: true,

             },
            "Enquiry.hotelType":
             {
                 DropdownRequired: true,

             },
            "Enquiry.roomType":
             {
                 DropdownRequired: true,

             },
            "Enquiry.enquiryFromDate":
           {
               required: true,

           },
            "Enquiry.enquiryToDate":
           {
               required: true,

           },
            "Enquiry.enquiryAssignedType":
          {
              DropdownRequired: true,

          },
            "Enquiry.assigneName":
             {
                 required: true,

             }
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
            "Enquiry.destination":
             {
                 DropdownRequired: "Destination is required",

             },
            "Enquiry.hotelType":
             {
                 DropdownRequired: "Hotel type is required",

             },
            "Enquiry.roomType":
             {
                 DropdownRequired: "Room type is required",

             },
            "Enquiry.enquiryFromDate":
           {
               required: "From date is required",

           },
            "Enquiry.enquiryToDate":
           {
               required: "To date is required",

           },
            "Enquiry.enquiryAssignedType":
          {
              DropdownRequired: "Assigned type is required",

          },
            "Enquiry.assigneName":
             {
                 required: "Assigned name is required",

             },
        }

    });
});


