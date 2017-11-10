$(document).ready(function () {


    debugger;

    GetAutocompleteScript("EnquiryHotel");


    $("#dvHotelAssigneeName").hide();

    if ($("#hdnHotelId").val() == 0) {

        $("#dvHotelAssigneeName").hide();
    }
    else {

      

        $("#dvHotelAssigneeName").show();
    }



    $(".assignedtype").change(function () {

        //alert("uuuuu");

        if ($(this).val() == 1) {
            $("#dvHotelAssigneeName").hide();
        }
        else {
            $("#dvHotelAssigneeName").show();
        }
    });



    ////// Hotel Enquiry Item


    $("#btnSaveHotelDetails").click(function () {

        //alert("abc");

        if ($("#frmHoteldetails").valid()) {

            SaveHotelEnquiryItem();

        }
    });

    $("#btnResetHotelDetails").click(function () {

        document.getElementById("frmHoteldetails").reset();

        //$("#hdnEnquiryId").val("");

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