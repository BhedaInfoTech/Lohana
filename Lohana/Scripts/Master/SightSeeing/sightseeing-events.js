$(document).ready(function () {

  
    GetAutocompleteScript("SightSeeing");

    if ($("[name='SightSeeing.SightSeeingId']").val() == 0) {

        $("#linkPhotos").hide();
    }
    else {
        $("#linkPhotos").show();
        GetAutocompleteById("SightSeeing.VendorId");
        var vendor = $("#hdnvendor").val();
        $("#drpVendor").attr("data-value", vendor);
        GetImagesByRefType();
    }
      

    $("#btnSaveSightSeeing").click(function () {
        if ($("#frmSightSeeing").valid()) {

            SaveSightSeeing();

            $(".nav-link").show();
        }
    });

    $("#btnResetSightSeeing").click(function () {

        document.getElementById("frmSightSeeing").reset();
        //$("[name='SightSeeing.Disclaimer']").val(""),
        //$("[name='SightSeeing.Highlights']").val(""),
        //$("[name='SightSeeing.Description']").val(""),
        //$("[name='SightSeeing.Disclaimer']").val("")

    });

    $('.summernote').summernote({
        toolbar: [
   // [groupName, [list of button]]
   ['style', ['bold', 'italic', 'underline', 'clear']],
   ['fontsize', ['fontsize']],
   ['color', ['color']],
   ['para', ['ul', 'ol', 'paragraph']]

        ]
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