$(document).ready(function () {

    $("#frmEnquiryBaic").validate({

        ignore: ":hidden",

        rules: {

            "Enquiry.CustomerType":
             {
                 required: true,
             },
            "Enquiry.CustomerName":
             {
                 DropdownRequired: true,

             },
            "Enquiry.AgentName":
             {
                 DropdownRequired: true,

             },
            "Enquiry.GuestName":
             {
                 required: true,

             },
            "Enquiry.GuestEmail":
             {
                 required: true,

             },
            "Enquiry.GuestMobNo":
             {
                 required: true,

             }

        },
        messages: {

            "Enquiry.CustomerType":
             {
                 required: "Customer type is required.",
             },

            "Enquiry.CustomerName":
                 {
                     DropdownRequired: "Customer is required"
                 },
            "Enquiry.AgentName":
                {
                    DropdownRequired: "Agent is required."
                },
            "Enquiry.GuestName":
             {
                 required: "Guest is required."
             },
            "Enquiry.GuestEmail":
             {
                 required: "Guest email is required."
             },
            "Enquiry.GuestMobNo":
             {
                 required: "Guest mobile number is required."
             },
        }

    });
});


