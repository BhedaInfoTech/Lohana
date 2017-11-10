$(document).ready(function () {

    $("#frmSightseeingdetails").validate({

        ignore: ":hidden",

        rules: {

            "Enquiry.location":
             {
                 DropdownRequired: true,
             },
            "Enquiry.sightseeingName":
             {
                 required: true,

             },
            "Enquiry.travelDate":
             {
                 required: true,

             },
            "Enquiry.vehicleType":
             {
                 DropdownRequired: true,

             },
            "Enquiry.budget":
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
                 DropdownRequired: true,

             }

        },
        messages: {

            "Enquiry.location":
             {
                 DropdownRequired: "Location is required",
             },
            "Enquiry.sightseeingName":
             {
                 required: "Sightseeing name is required",

             },
            "Enquiry.travelDate":
             {
                 required: "Travel date is required",

             },
            "Enquiry.vehicleType":
             {
                 DropdownRequired: "Vehicle type is required",

             },
            "Enquiry.budget":
             {
                 required: "Budget is required",
                 number: "Enter digits only",

             },
            "Enquiry.enquiryAssignedType":
             {
                 DropdownRequired: "Assigned type is required",

             },
            "Enquiry.assigneName":
             {
                 DropdownRequired: "Assigned name is required",

             },
        }

    });
});


