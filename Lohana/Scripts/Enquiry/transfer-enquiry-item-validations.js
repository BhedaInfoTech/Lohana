$(document).ready(function () {

    $("#frmtransferdetails").validate({

        ignore: ":hidden",

        rules: {

            "Enquiry.nameOfCity":
             {
                 DropdownRequired: true,
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
            "EnquiryItemTransferDetails[0].transferDate":
             {
                 required: true,
             },
            "EnquiryItemTransferDetails[0].pickUpType":
            {
                DropdownRequired: true,
            },
            "EnquiryItemTransferDetails[0].pickUpFrom":
           {
               DropdownRequired: true,
           },
            "EnquiryItemTransferDetails[0].dropOfType":
             {
                 DropdownRequired: true,
             },
            "EnquiryItemTransferDetails[0].dropOfTo":
             {
                 DropdownRequired: true,
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

            "Enquiry.nameOfCity":
              {
                  DropdownRequired: "Name of city is required",
              },
            "Enquiry.vehicleType":
             {
                 DropdownRequired: "Vehicle type is required",
             },
            "Enquiry.budget":
             {
                 required: "Budget is required",
                 number: "Please enter digits only",
             },
            "EnquiryItemTransferDetails[0].transferDate":
             {
                 required: "Transfer date is required",
             },
            "EnquiryItemTransferDetails[0].pickUpType":
            {
                DropdownRequired: "Pick up type is required",
            },
            "EnquiryItemTransferDetails[0].pickUpFrom":
           {
               DropdownRequired: "Pick up from is required",
           },
            "EnquiryItemTransferDetails[0].dropOfType":
             {
                 DropdownRequired: "Drop of type is required",
             },
            "EnquiryItemTransferDetails[0].dropOfTo":
             {
                 DropdownRequired: "Drop of to is required",
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


