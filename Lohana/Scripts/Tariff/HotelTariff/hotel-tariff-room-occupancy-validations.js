$(document).ready(function () {

    $("#frmHotelTariffRoomOccupancy").validate({

		rules: {
		 
		    "HotelTariffRoomOccupancy.OccupancyId":
              {
              	DropdownRequired: true,
              },
		    "HotelTariffRoomOccupancy.AgeFrom":
            {

            	number: true,
            	Age: true,
            },
		    "HotelTariffRoomOccupancy.AgeTo":
           {

           	number: true,
           	Age: true,
           }, 
		},
		messages: {

		 
		    "HotelTariffRoomOccupancy.OccupancyId":
              {
              	DropdownRequired: "Occupancy is required.",
              },

		    "HotelTariffRoomOccupancy.AgeFrom":
             {
             	required: "Age is required",
             	number: "Please enter number only"
             },

		    "HotelTariffRoomOccupancy.AgeTo":
            {
            	required: "Age is required",
            	number: "Please enter number only"
            },
			 
		}
	});

    

    jQuery.validator.addMethod("Age", function (value, element) {
        
        var result = true;

        var fromage = $("[name='HotelTariffRoomOccupancy.AgeFrom']").val();

        var toage = $("[name='HotelTariffRoomOccupancy.AgeTo']").val();

        fromage = parseInt(fromage, 10);

        toage = parseInt(toage, 10);

        if (fromage > toage) {

            result = false;
        }

      
        return result;

    }, "Please enter valid age.");
     

});
















