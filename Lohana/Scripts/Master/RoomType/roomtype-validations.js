$(document).ready(function () {

    $("#frmRoomType").validate({

        rules: {

            "RoomType.RoomTypeName":
             {
                 required: true,
                 CheckRoomTypeNameExist: true
             }

        },
        messages: {

            "RoomType.RoomTypeName":
                {
                    required: "Roomtype name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckRoomTypeNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/RoomType/CheckRoomTypeNameExist', { RoomTypeName: value }, $("#txtRoomTypeName"), $("#hdnRoomTypeName"));

    }, "RoomType name already exist.")

});





