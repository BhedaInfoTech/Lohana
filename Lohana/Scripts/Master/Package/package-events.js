$(document).ready(function () {

    GetAutocompleteScript("Package");
    
    $("#itinerary").find("#divDays").load("/Package/GetPackageGitTariffDays", { PackageId: $("#hdnPackageId").val() }, function () {

    });

    $('#drppackageType').multiSelect();

    if ($("[name='Package.PackageId']").val() == 0) {

        $("#link1").hide();
        $("#link2").hide(); 
        $("#link3").hide();
        $("#link4").hide();
        $("#link5").hide();
        $("#link6").hide();
    }
    else {
        $("#link1").show();
        $("#link2").show();
        $("#link3").show();
        $("#link4").show();
        $("#link5").show();
        $("#link6").show();

    }


    $('.PackageType').trigger('change');


    $("#divHotel").hide();
    $("#divFlight").hide();
    $("#divTrain").hide();
    $("#divBus").hide();
    $("#divVehicle").hide();

  
    GetPackageDate();

    GetPackageItinerary();

    GetImagesByRefType();

    $("#packagedetails").show();

    $("#btnSavePackageDetails").click(function () {
       
        if ($("#frmPackageBasicDetails").valid()) {

            SavePackageBasicDetails();

            $(".nav-link").show();
        }

    });

    $("#btnResetPackageDetails").click(function () {

        document.getElementById("frmPackageBasicDetails").reset();

    });


    $('.file').on('change', function (e) {

        var files = e.target.files;

        UploadFile($(this), files);
    });

    $(".removeimg").on("click", function (e) {

        e.stopImmediatePropagation();

        removeImg($(this));
    });

   
});