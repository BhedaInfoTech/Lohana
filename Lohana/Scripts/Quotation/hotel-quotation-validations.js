$(function () {

    jQuery.validator.addMethod("checkCapacity", function (value, element) { 

        var result = true;  

        var roomCapacity = $(element).parents(".m-item").find(".room-data").attr("data-capacity");

        //alert(roomCapacity);
       // alert($(element).val()); 

        if ($(element).val() > roomCapacity)
        {
            result = false;
        }
       
        return result;

    }, "Please enter occupancy relate with room capacity.");

});