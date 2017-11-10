 $(document).ready(function () {


    debugger;

    GetAutocompleteScript("EnquiryFit");

    $('.assignedtype').trigger("change");


    $("#dvFitAssigneeName").hide();
     $("#dvFitAssigneeNameAuto").show();


    if ($("#hdnFitId").val() == 0)
    {
        $("#dvFitAssigneeName").hide();

    }
    else
    {     
        $("#dvFitAssigneeName").show();
        $("#dvFitAssigneeNameAuto").show();
    }



    $(".assignedtype").change(function () {

        debugger;

        if ($(this).val() == 1)
        {
            //alert("if");

            $("#dvFitAssigneeName").hide();
            $("#dvFitAssigneeNameAuto").show();
        }
        else
        {
            //alert("show");

            debugger;

            $("#dvFitAssigneeName").show();
            $("#dvFitAssigneeNameAuto").hide();
        }
    });



    ///// Fit Enquiry Item

    $("#btnSaveFitDetails").click(function () {

        //alert("abc");

        if ($("#frmfitdetails").valid()) {

            SaveFitEnquiryItem();

        }
    });

    $("#btnResetFitDetails").click(function () {

        document.getElementById("frmfitdetails").reset();

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