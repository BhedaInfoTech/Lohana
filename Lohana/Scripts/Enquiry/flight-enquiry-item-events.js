$(document).ready(function () {


    debugger;

    //GetAutocompleteScript("EnquiryFlight");
    $("[name='Enquiry.FlightType']").trigger('change');

    $("#dvFlightAssigneeName").hide();

    if ($("#hdnFlightId").val() == 0) {

        $("#dvFlightAssigneeName").hide();
    }
    else {

        $("#dvFlightAssigneeName").show();
    }


    $(".assignedtype").change(function () {

        //alert("uuuuu");

        if ($(this).val() == 1) {
            $("#dvFlightAssigneeName").hide();
            $("#dvFitAssigneeNameAuto").show();
        }
        else {
            $("#dvFlightAssigneeName").show();
            $("#dvFitAssigneeNameAuto").hide();
        }
    });


    /////// Flight Enquiry Item

    $("#divbuttonGroup").hide();

    $("#divreturnOn").hide();

    $("#divenquiryFlightDetails").hide();

    $("[name='Enquiry.FlightType']").change(function () {

        $('.custom-radio').attr('checked', false);

        $(this).attr('checked', true);

        if ($(this).attr('checked')) {
            if ($(this).val() == "1") {
                $("#divbuttonGroup").hide();
                $("#divreturnOn").hide();
                $("#divflightType").html("");
                //$("#divenquiryFlightDetails").show();
            }
            else if ($(this).val() == "2") {
                $("#divreturnOn").show();
                $("#divbuttonGroup").hide();
                $("#divflightType").html("");
                // $("#divenquiryFlightDetails").show();
            }
            else {
                $("#divbuttonGroup").show();
                $("#divreturnOn").hide();
                // $("#divenquiryFlightDetails").show();
            }
        }


    });

    $("#btnAdd").click(function () {

        // AddNewFlightDetails();

        //var div = document.createElement("div");  
        //div.htm
        //row.append

        $("#divflightType").append($("#dvTempFlight").html());

        ReArrangeFlightDetailsData();
    });

    $("#btnSaveFlightDetails").click(function () {

        //alert("abc");

        if ($("#frmflightdetails").valid()) {

            SaveFlightEnquiryItem();

        }
    });

    $("#btnResetFlightDetails").click(function () {

        document.getElementById("frmflightdetails").reset();

    });

    $(document).on("click", ".btn-flight-remove", function () {

        $(this).parents(".row").remove();

        ReArrangeFlightDetailsData();
    });


    $('.datepicker-autoclose').datepicker({
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