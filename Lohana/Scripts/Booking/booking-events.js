$(document).ready(function () {

    GetAutocompleteScript("Booking");

    //
    var cookies = $("#cookiesdata").val();
    //var cookiesdata = JSON.parse(cookies);
    //alert(cookiesdata);
    if (cookies != null && cookies != "") {
        BindGitDetails(cookies);
        BindFitDetails(cookies)
    }
    else {
        document.getElementById("btnSaveGitDetails").disabled = true;
        document.getElementById("btnSaveFitDetails").disabled = true;
    }
    //

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {
            // GetSetTravellerInformatio($(this));

            document.getElementById("btnEditContactDetails").disabled = false;
            document.getElementById("btnViewContactDetails").disabled = false;
            document.getElementById("btnDeleteContactDetails").disabled = false;
            document.getElementById("btnSaveContactDetails").disabled = true;
            //SetActive($("[name='Country.IsActive']"), $(this).attr("data-isactive"));
        }
    });


    //$("#btnSaveContactDetails").click(function () {

    //    if ($("#frmBasicDetails").valid()) {
    //        SaveTravellersDetails()
    //    }

    //});

    $("#btnEditContactDetails").click(function ()
    {
        //if ($('[name=c1]').find('checked')) {
        document.getElementById("btnViewContactDetails").disabled = true;
        document.getElementById("btnDeleteContactDetails").disabled = true;
        GetSetTravellerInformatio()
        //}
    });

    //$("#btnDeleteContactDetails").click(function ()
    //{
    //    DeleteTravellerDetails();
    //    document.getElementById("btnViewContactDetails").disabled = true;
    //    document.getElementById("btnEditContactDetails").disabled = true;
    //});

    //$(document).on("click", ".btnDeleteContactDetails", function () {

    //    DeleteTravellerDetails();
    //       document.getElementById("btnViewContactDetails").disabled = true;
    //       document.getElementById("btnEditContactDetails").disabled = true;
           
    //});

    


    $("#btnResetCountry").click(function () {

        //if ($("#frmBasicDetails").valid()) {
        ResetTravellersDetails();
        document.getElementById("btnEditContactDetails").disabled = true;
        document.getElementById("btnViewContactDetails").disabled = true;
        document.getElementById("btnDeleteContactDetails").disabled = true;

        document.getElementById("btnSaveContactDetails").disabled = false;
        // }

    });

    $(".btnViewContactDetails").click(function () {

        $("#modalParent .modal-body").load("/Booking/TravellerDocumentDetails");

        $("#modalParent").modal("show");
    });

    $('.file').on('change', function (e) {

        var files = e.target.files;

        UploadFile($(this), files);
    });

    $("#btnSaveDocumentDetails").click(function () {

        SaveImage();
    });

});