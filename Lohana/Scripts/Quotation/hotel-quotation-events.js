$(document).ready(function () {

    $("#frmRoomMealOccupancyDetails").validate();

    $(".add-to-quotation").click(function () {

        //alert(1);
        AddHotelQuotation($(this));

    });

    $(".add-to-cart").click(function () {

        AddHotelInCart($(this));

    });

    $(".room-occupancy").change(function () {

        //alert($(this).attr('name')); 

        $("[name='" + $(this).attr('name') + "']").rules('add', { checkCapacity: true });

        if ($("#frmRoomMealOccupancyDetails").valid()) {
            //alert(1);
            CalculatePrice($(this));
        }

        $("[name='"+$(this).attr('name') +"']").rules('add', { checkCapacity: false });

    });


    $('datepicker-autoclose').datepicker({
        autoclose: true,
        todayHighlight: true
    });


    $(".count").TouchSpin({
        min: 0,
        max: 100,
        step: 1,
        decimals: 0,
        boostat: 5,
        maxboostedstep: 10,
        //postfix: '%',
        buttondown_class: "btn btn-secondary",
        buttonup_class: "btn btn-secondary"
    });




});