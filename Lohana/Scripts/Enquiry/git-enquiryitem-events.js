$(document).ready(function () {

    GetAutocompleteScript("EnquiryGit");

    debugger;

    $("#drpenquirygitAssignedType").trigger("change");

    //$("#dvGitAssigneeName").hide();

    //document.getElementById("#dvGitAssigneeNameAuto").style.display = "none";

    if ($("#hdnGitId").val() == 0)
    {
        $("#dvGitAssigneeName").hide();

        //document.getElementById("#dvGitAssigneeNameAuto").style.display = "none";
    }
    else
    {
        $("#dvGitAssigneeName").show();

        //document.getElementById("#dvGitAssigneeNameAuto").style.display = "none";
    }

    $('select').on('change', function () {

        // Does some stuff and logs the event to the console

        if ($(this).val() == 1)
        {
            $("#dvGitAssigneeName").hide();

            $("#dvGitAssigneeNameAuto").show();
        }
        else
        {
            $("#dvGitAssigneeName").show();

            $("#dvGitAssigneeNameAuto").hide();
        }


    });

    $(".assignedtype").change(function () {

        if ($(this).val() == 1)
        {
            $("#dvGitAssigneeName").hide();

            $("#dvGitAssigneeNameAuto").show();
        }
        else
        {
            $("#dvGitAssigneeName").show();

            $("#dvGitAssigneeNameAuto").hide();         
        }
    });




    ///// Git Enquiry Item

    $("#btnSaveGitDetails").click(function () {

        if ($("#frmgitdetails").valid()) {

            SaveGitEnquiryItem();
        }

    });

    $("#btnResetGitDetails").click(function () {

        document.getElementById("frmgitdetails").reset();

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























    //// Train Enquiry Item

    //$("[name='Enquiry.TrainType']").change(function () {

    //    $('.custom-radio').attr('checked', false);

    //    $(this).attr('checked', true);

    //    if ($(this).attr('checked'))
    //    {

    //        if ($(this).val() == "1")
    //        {
    //            $("#divtraintypebuttonGroup").hide();
    //            $("#divreturnOn").hide();
                
    //        }

    //        else if ($(this).val() == "2")
    //        {

    //            $("#divreturnOn").show();
    //            $("#divtraintypebuttonGroup").hide();
               
    //        }

    //        else if ($(this).val() == "3")
    //        {
    //            $("#divtraintypebuttonGroup").show();
    //            $("#divreturnOn").hide();
                
    //        }
    //        else
    //        {
    //            $("#divtrainpassbuttonGroup").show();
    //            $("#divreturnOn").hide();
    //            $("#divtrainPassType").show();
    //        }
                
    //    }


    //});


    ////$("#btnAdd").click(function () {
    ////    AddNewFlightDetails();
    ////});

    //$("#btnSaveTrainDetails").click(function () {

    //    alert("train");

    //    if ($("#frmtraindetails").valid()) {

    //        SaveTrainEnquiryItem();

    //    }
    //});

    //$("#btnResetTrainDetails").click(function () {

    //    document.getElementById("frmtraindetails").reset();

    //});











   
