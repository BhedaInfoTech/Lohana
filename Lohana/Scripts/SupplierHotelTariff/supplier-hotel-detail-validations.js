$(document).ready(function () {

    $("#frmHotelDetail").validate({

        rules: {

            "SupplierHotelDetail.CityId":
            {
            	required: true,
            },
            "SupplierHotelDetail.HotelId":
             {
             	required: true,
             },
            "SupplierHotelDetail.TotalNights":
             {
             	required: true,
				number:true
             },
            "SupplierHotelDetail.RoomTypeId":
             {
             	required: true,
             },
        },
        messages: {

            "SupplierHotelDetail.CityId":
                {
                    required: "City is required."
                },
            "SupplierHotelDetail.HotelId":
                {
                    required: "Hotel is required"
                },
            "SupplierHotelDetail.TotalNights":
                {
                	required: "No of nights is required.",
					number:"Enter valid number."
                },
            "SupplierHotelDetail.RoomTypeId":
                {
                    required: "Room type is required"
                },
        }

    });
});





