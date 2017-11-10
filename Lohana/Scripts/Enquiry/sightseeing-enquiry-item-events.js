$(document).ready(function () {

    debugger;
    GetAutocompleteScript("EnquirySightSeeing");
    //GetAutocompleteScript("EnquirySightseeing");


    $("#dvSightseeingAssigneeName").hide();

    if ($("#hdnSightseeingId").val() == 0) {

        $("#dvSightseeingAssigneeName").hide();
    }
    else {

        $("#dvSightseeingAssigneeName").show();
    }

    $(".assignedtype").change(function () {

        //alert("uuuuu");

        if ($(this).val() == 1) {

            $("#dvSightseeingAssigneeName").hide();
        }
        else {

            $("#dvSightseeingAssigneeName").show();
        }
    });


    /////// Sightseeing Enquiry Item


    $("#btnSaveSightseeingDetails").click(function () {

        //alert("abc");

        if ($("#frmSightseeingdetails").valid()) {

            SaveSightseeingEnquiryItem();

        }
    });

    $("#btnResetSightseeingDetails").click(function () {

        document.getElementById("frmSightseeingdetails").reset();

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