$(document).ready(function () {

    $("#frmflightdetails").validate({

        ignore: ":hidden",

        rules: {

            "EnquiryItemTypeDetails[0].TicketClass":
             {
                 DropdownRequired: true,
             },
            "EnquiryItemTypeDetails[0].PickUpFrom":
             {
                 DropdownRequired: true,
             },
            "EnquiryItemTypeDetails[0].DropTo":
             {
                 DropdownRequired: true,
             },
            "EnquiryItemTypeDetails[0].DepartureDate":
             {
                 required: true,
             },
            "EnquiryItemTypeDetails[0].ReturnDate":
            {
                required: true,
            },
            "Enquiry.budget":
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

            "EnquiryItemTypeDetails[0].TicketClass":
           {
               DropdownRequired: "Ticket class is required",
           },
            "EnquiryItemTypeDetails[0].PickUpFrom":
             {
                 DropdownRequired: "Pick up is required",
             },
            "EnquiryItemTypeDetails[0].DropTo":
             {
                 DropdownRequired: "Drop to is required",
             },
            "EnquiryItemTypeDetails[0].DepartureDate":
             {
                 required: "Departure date is required",
             },
            "EnquiryItemTypeDetails[0].ReturnDate":
            {
                required: "Return date is required",
            },
            "Enquiry.budget":
           {
               required: "Budget is required",
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


