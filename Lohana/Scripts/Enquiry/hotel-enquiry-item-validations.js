$(document).ready(function () {

    $("#frmHoteldetails").validate({

        ignore: ":hidden",

        rules: {

            "Enquiry.location":
             {
                 DropdownRequired: true,
             },
            "Enquiry.CheckInDate":
             {
                 required: true,

             },
            "Enquiry.CheckOutDate":
             {
                 required: true,
             },
            "Enquiry.budget":
             {
                 required: true,
             },
            "Enquiry.hotelType":
            {
                DropdownRequired: true,
            },
            "Enquiry.HotelName":
            {
                required: true,
            },
            "Enquiry.roomType":
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


            "Enquiry.location":
             {
                 DropdownRequired: "Location is required",
             },
            "Enquiry.CheckInDate":
             {
                 required: "Check in date is required",

             },
            "Enquiry.CheckOutDate":
             {
                 required: "Check out date is required",
             },
            "Enquiry.budget":
             {
                 required: "Budget is required",
             },
            "Enquiry.hotelType":
            {
                DropdownRequired: "Hotel type is required",
            },
            "Enquiry.HotelName":
            {
                required: "Hotel name is required",
            },
            "Enquiry.roomType":
             {
                 DropdownRequired: "Room type is required",
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


