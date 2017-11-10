$(document).ready(function () {

	$("#frmHotelTariffRoom").validate({

		rules: {
			"HotelTariffRoom.RoomRateTypeId":
            {
            	DropdownRequired: true,
            },
			"HotelTariffRoom.CheckInTime":
           {
           	required: true,
           	//Time: true,
           },
			"HotelTariffRoom.CheckOutTime":
             {
             	required: true,
             	// Time: true,
             },
			"HotelTariffRoom.RoomTypeId":
            {
            	DropdownRequired: true,
            },
			"HotelTariffRoom.OccupancyId":
              {
              	DropdownRequired: true,
              },
			"HotelTariffRoom.AgeFrom":
            {

            	number: true,
            	Age: true,
            },
			"HotelTariffRoom.AgeTo":
           {

           	number: true,
           	Age: true,
           },
			"HotelTariffRoom.NoOfNight":
				{
					required: true
				}
		},
		messages: {

			"HotelTariffRoom.RoomRateTypeId":
            {
            	DropdownRequired: "Room rate type is required.",
            },

			"HotelTariffRoom.CheckInTime":
            {
            	required: "Check in time is required"

            },
			"HotelTariffRoom.CheckOutTime":
            {
            	required: "Check out time is required"
            },

			"HotelTariffRoom.RoomTypeId":
            {
            	DropdownRequired: "Room type is required.",
            },
			"HotelTariffRoom.OccupancyId":
              {
              	DropdownRequired: "Occupancy is required.",
              },

			"HotelTariffRoom.AgeFrom":
             {
             	required: "Age is required",
             	number: "Please enter number only"
             },

			"HotelTariffRoom.AgeTo":
            {
            	required: "Age is required",
            	number: "Please enter number only"
            },
			"HotelTariffRoom.NoOfNight":
				{
					required: "No of night is required."
				}
		}
	});

    

    jQuery.validator.addMethod("Age", function (value, element) {


        var result = true;

        var fromage=$("[name='HotelTariffRoom.AgeFrom']").val();

        var toage = $("[name='HotelTariffRoom.AgeTo']").val();

        fromage = parseInt(fromage, 10);

        toage = parseInt(toage, 10);

        if (fromage > toage) {

            result = false;
        }

      
        return result;

    }, "Please enter valid age.");

    jQuery.validator.addMethod("Time", function (value, element) {


        var result = true;

        var checkintime = $("[name='HotelTariffRoom.CheckInTime']").val();

        var checkouttime = $("[name='HotelTariffRoom.CheckOutTime']").val();

        checkintime = parseInt(checkintime, 10);

        checkouttime = parseInt(checkouttime, 10);

        if (checkintime > checkouttime) {

            result = false;
        }


        return result;

    }, "Please enter valid time.");

});
















