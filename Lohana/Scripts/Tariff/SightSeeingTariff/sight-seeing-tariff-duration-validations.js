$(document).ready(function () {

    $("#frmHotelTariffduration").validate({



        rules: {

            "HotelTariffDuration.HotelTariffPriceDetailsId":
             {
                 required: true,
             },

            "HotelTariffDuration.FromDate":
             {
                 required: true,

             },
            "HotelTariffDuration.ToDate":
             {
                 required: true,

             }

        },
        messages: {

            "HotelTariffDuration.HotelTariffPriceDetailsId":
             {
                 required: "Price is required.",
             },

            "HotelTariffDuration.FromDate":
                 {
                     required: ""
                 },
            "HotelTariffDuration.ToDate":
                {
                    required: "Date is required."
                },

        }



    });


});