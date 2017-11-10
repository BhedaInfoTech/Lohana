$(document).ready(function ()
{


$("#frmHotelRoomTypeDetails").validate({
    rules: {
        "Hotel.RoomType":
         {
             DropdownRequired: true,
         },
        "Hotel.noOfRooms":
         {
             required: true,
             number: true,
         },
        "Hotel.occupancy":
       {
           required: true,
           number: true,
       }
    },
    messages: {
        "Hotel.RoomType":
            {
                DropdownRequired: "Room type is required."
            },
        "Hotel.noOfRooms":
           {
               required: "Number of rooms is required.",
               number: "Enter digits only."
           },
        "Hotel.occupancy":
          {
              required: "Occupancy is required.",
              number: "Enter digits only."
          },
    }
});

});