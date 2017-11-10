$(document).ready(function () {

    $("#frmSupplierHotelTariffduration").validate({



        rules: {

            "SupplierHotelDuration.SupplierHotelPriceId":
             {
                 required: true,
             },

            "SupplierHotelDuration.FromDate":
             {
                 required: true,

             },
            "SupplierHotelDuration.ToDate":
             {
                 required: true,

             }

        },
        messages: {

            "SupplierHotelDuration.SupplierHotelPriceId":
             {
                 required: "Price is required.",
             },

            "SupplierHotelDuration.FromDate":
                 {
                     required: ""
                 },
            "SupplierHotelDuration.ToDate":
                {
                    required: "Date is required."
                },

        }



    });


});


