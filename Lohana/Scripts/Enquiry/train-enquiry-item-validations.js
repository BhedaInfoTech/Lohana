$(document).ready(function () {

    $("#frmtraindetails").validate({

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
            "EnquiryItemTypeDetails[0].Region":
           {
               DropdownRequired: true,
           },
            "EnquiryItemTypeDetails[0].PassType":
             {
                 DropdownRequired: true,
             },
            "EnquiryItemTypeDetails[0].RailPass":
             {
                 DropdownRequired: true,
             },
            "EnquiryItemTypeDetails[0].RailClass":
           {
               DropdownRequired: true,
           },
            "Enquiry.budget":
           {
               required: true,
           },
            "EnquiryItemPassDetails[0].NoOfDays":
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
            "EnquiryItemTypeDetails[0].Region":
         {
             DropdownRequired: "Region is required",
         },
            "EnquiryItemTypeDetails[0].PassType":
             {
                 DropdownRequired: "Pass type is required",
             },
            "EnquiryItemTypeDetails[0].RailPass":
             {
                 DropdownRequired: "Rail pass is required",
             },
            "EnquiryItemTypeDetails[0].RailClass":
             {
               DropdownRequired: "Rail class is required",
             },
            "EnquiryItemPassDetails[0].NoOfDays":
             {
                 required: "No of days is required",
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


