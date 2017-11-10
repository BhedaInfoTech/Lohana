$(document).ready(function () {

    $("#frmBasicDetails").validate({

        rules: {

            "BookingCartDetailsInfo.CustomerId":
            {
                required: true,

            },
            "BookingCartDetailsInfo.TravellerName":
             {
                 required: true,

             },
            "BookingCartDetailsInfo.Age":
            {
                required: true,

            }
            ,
            "BookingCartDetailsInfo.MobileNo":
            {
                required: true,

            }

        },
        messages: {

            "BookingCartDetailsInfo.CustomerId":
            {
                required: "Customer name is required."
            },
            "BookingCartDetailsInfo.TravellerName":
                {
                    required: "Traveller name is required."
                },
            "BookingCartDetailsInfo.Age":
               {
                   required: "Age name is required."
               }
            ,
            "BookingCartDetailsInfo.MobileNo":
               {
                   required: "Mobile No is required."
               }
        }

    });

 


});