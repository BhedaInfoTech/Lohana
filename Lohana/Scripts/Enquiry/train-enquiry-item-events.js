$(document).ready(function () {


    debugger;

    //GetAutocompleteScript("EnquiryTrain");


    $("#dvTrainAssigneeName").hide();

    if ($("#hdnTrainId").val() == 0) {

        $("#dvTrainAssigneeName").hide();
    }
    else {

        $("#dvTrainAssigneeName").show();
    }


    $(".assignedtype").change(function () {

        //alert("uuuuu");

        if ($(this).val() == 1) {
            $("#dvTrainAssigneeName").hide();
        }
        else {
            $("#dvTrainAssigneeName").show();
        }
    });


    ///////// Train Enquiry Item


    $("#divTrainPassButtonGroup").hide();

    $("#divtrainTypeButtonGroup").hide();

    $("#divtrainreturnOn").hide();

    //$("#divtrainPass").hide();

    if ($("#hdnTrainId").val() == 0)
    {

        //alert("if");

        $("[name='Enquiry.TrainType']").change(function () {

            $('.custom-radio').attr('checked', false);

            $(this).attr('checked', true);

            if ($(this).attr('checked')) {
                if ($(this).val() == "1") {
                    $("#divtrainTypeButtonGroup").hide();
                    $("#divTrainPassButtonGroup").show();
                    $("#divtrainreturnOn").hide();
                    $("#divtrainType").html("");
                    $("#divtrainPass").html("");

                }
                else if ($(this).val() == "2") {
                    $("#divtrainreturnOn").show();
                    $("#divtrainTypeButtonGroup").hide();
                    $("#divTrainPassButtonGroup").show();
                    $("#divtrainType").html("");
                    $("#divtrainPass").html("");
                }
                else if ($(this).val() == "3") {
                    $("#divtrainTypeButtonGroup").show();
                    //$("#divTrainPassButtonGroup").hide();
                    $("#divtrainreturnOn").hide();
                    $("#divtrainPass").html("");
                }
                else {
                    $("#divTrainPassButtonGroup").show();
                    // $("#divtrainTypeButtonGroup").show();
                    $("#divtrainreturnOn").hide();
                    $("#divtrainPass").show();
                    $("#divtrainType").html("");
                }
            }


        });
    }
    else
    {

        //alert("else");

        $("[name='Enquiry.TrainType']").change(function () {

            $('.custom-radio').attr('checked', false);

            $(this).attr('checked', true);

            if ($(this).attr('checked')) {
                if ($(this).val() == "1") {
                    $("#divtrainTypeButtonGroup").hide();
                    $("#divTrainPassButtonGroup").show();
                    $("#divtrainreturnOn").hide();
                }
                else if ($(this).val() == "2") {
                    $("#divtrainreturnOn").show();
                    $("#divtrainTypeButtonGroup").hide();
                    $("#divTrainPassButtonGroup").show();
                }
                else if ($(this).val() == "3") {
                    $("#divtrainTypeButtonGroup").show();
                    
                    $("#divtrainreturnOn").hide();
                  
                }
                else {
                    $("#divTrainPassButtonGroup").show();
                    $("#divtrainreturnOn").hide();
                    $("#divtrainPass").show();}
            }


        });

    }


    





    $("#btnAddTrainType").click(function () {

        $("#divtrainType").append($("#dvTempTrainType").html());

        ReArrangeTrainTypeDetailsData();
    });

    $("#btnAddTrainPass").click(function () {

        $("#divtrainPass").append($("#dvTempTrainPass").html());

        ReArrangeTrainPassDetailsData();
    });

    $("#btnSaveTrainDetails").click(function () {

        //alert("train");

        if ($("#frmtraindetails").valid()) {

            SaveTrainEnquiryItem();

        }
    });

    $("#btnResetTrainDetails").click(function () {

        document.getElementById("frmtraindetails").reset();

    });

    $(document).on("click", ".btn-train-remove", function () {

        $(this).parents(".row").remove();

        ReArrangeTrainTypeDetailsData();
    });

    $(document).on("click", ".btn-train-pass-remove", function () {

        $(this).parents(".row").remove();

        ReArrangeTrainPassDetailsData();
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