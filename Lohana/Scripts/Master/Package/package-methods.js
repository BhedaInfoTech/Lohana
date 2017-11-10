function SavePackageBasicDetails() {

    if ($("[name='Package.Status']").val() == 1 || $("[name='Package.Status']").val() == "true") {

        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmPackageBasicDetails").blur();

    var pViewModel = {

        Package: {

            PackageId: $("[name='Package.PackageId']").val(),

            PackageCode: $("[name='Package.PackageCode']").val(),

            PackageCategoryId: $("#drppkgcategory").val(),

            PackageType: $("#hdnPackageType").val(),

            PackageName: $("[name='Package.PackageName']").val(),

            DayDuration: $("[name='Package.DayDuration']").val(),

            NightDuration: $("[name='Package.NightDuration']").val(),

            DepartureCityId: $("#drpdepartureCity").val(),

            TourReportingPoint: $("[name='Package.TourReportingPoint']").val(),

            TourDroppingPoint: $("[name='Package.TourDroppingPoint']").val(),

            PackageCost: $("[name='Package.PackageCost']").val(),

            Adventure: $("[name='Package.Adventure']").val(),

            Speciality: $("[name='Package.Specialty']").val(),

            PlaceToVisit: $("[name='Package.PlaceToVisit']").val(),

            Status: activeFlg

        }
    }

    var url = "";


    if ($("[name='Package.PackageId']").val() == 0) {

        url = "/Package/InsertPackage"
    }

    else {

        url = "/Package/UpdatePackage"
    }

    PostAjaxWithProcessJson(url, pViewModel, AfterSave, $("body"));


}

function AfterSave(data) {

    debugger;

    FriendlyMessage(data);

    $("#hdnpackageOtherDetailsId").val(data.Package.PackageId)

    $("#hdnPackageDateId").val(data.Package.PackageId)

    $("#hdnPackageItineraryId").val(data.Package.PackageId)

    $("[name='Accessories.RefId']").val(data.Package.PackageId);

    $("#link1").show();
    $("#link2").show();
    $("#link3").show();
    $("#link4").show();
    $("#link5").show();

}

//  Multiselect package type

function Set_PackageType() {

    var hexvalues = [];

    var labelvalues = [];

    var PackageType = "";

    var PackageTypeName = "";

    $('.PackageType :selected').each(function (i, selectedElement) {

        hexvalues[i] = $(selectedElement).val();

        labelvalues[i] = $(selectedElement).text();

        debugger;

        PackageType = hexvalues[i] + "," + PackageType;

        PackageTypeName = labelvalues[i] + ", " + PackageTypeName;

    });

    $('#hdnPackageType').val(PackageType);

}


// Image Upload

function SaveImage() {

    var aViewModel =
        {
            Accessories: {

                AttachmentName: $("[name='Accessories.AttachmentName']").val(),

                RefTypeName: $("[name='Accessories.RefTypeName']").val(),

                RefId: $("[name='Accessories.RefId']").val(),

                RefCategory: $("[name='Accessories.RefCategory']").val(),

                UniqueAttachmentId: $("[name='Accessories.UniqueAttachmentId']").val()
            }
        }

    PostAjaxJson("/Accessories/Insert", aViewModel, AfterSaveImage);
}

function AfterSaveImage(data) {

    $("[name='Accessories.AttachmentId']").val(data.Accessories.AttachmentId);

    $("[name='Accessories.RefType']").val(data.Accessories.RefType);

    $("[name='Accessories.RefCategory']").val(data.Accessories.RefCategory);

    // GetImages();
}

function GetImages() {
    debugger;

    var aViewModel = {

        Accessories: {

            AttachmentId: $("[name='Accessories.AttachmentId']").val(),

            RefId: $("[name='Accessories.RefId']").val(),

            RefType: $("[name='Accessories.RefType']").val(),

            RefCategory: $("[name='Accessories.RefCategory']").val()
        }
        }
  
    PostAjaxJson("/Accessories/GetImages", aViewModel, BindImages);
    }


function GetImagesByRefType() {
    debugger;

    var aViewModel = {

        Accessories:
            {

                RefId: $("[name='Accessories.RefId']").val(),

                RefTypeName: $("[name='Accessories.RefTypeName']").val(),
            }
    }

    PostAjaxJson("/Accessories/GetImagesByRefType", aViewModel, BindImages);
}

function UploadFile(obj, files) {
    var files = files;

    var identifier = $(obj).attr("data-identifier");

    var refCategory = $(obj).attr("data-refcat");

    if (files.length > 0) {
        if (window.FormData !== undefined) {
            var formData = new FormData();

            for (var x = 0; x < files.length; x++) {
                formData.append("file" + x, files[x]);
            }

            formData.append("RefId", $("[name='Accessories.RefId']").val());

            formData.append("RefCategory", refCategory);

            PostFileUploadAjaxWithProcessJson("/Accessories/Upload", formData, function (data) {
                FriendlyMessage(data);

                // Set Data in hidden field
                $("[name='Accessories.AttachmentName']").val(data.FileName);

                $("[name='Accessories.UniqueAttachmentId']").val(data.NewFileName)

                $("[name='Accessories.RefCategory']").val(refCategory);

                appendImages(identifier, data.NewFileName);

                // Save Image detail in dtabase
                SaveImage();

            }, $("body"));
        }
        else {
            alert("This browser doesn't support HTML5 file uploads!");
        }
    }
}


function BindImages(data) {
        debugger;
    var htmlText = "";

    var sectionIdentifier, identifier;

    if (data.Images.length > 0) {
        for (i = 0; i < data.Images.length; i++) {
            sectionIdentifier = data.Images[i].RefCategory;

            if (sectionIdentifier == "Upload Photo") {
                identifier = "photo";
            }

            appendImages(identifier, data.Images[i].UniqueAttachmentId);
        }
    }
}

function appendImages(identifier, path) {

    // Create Element (i.e. Image Box)
    var element = "<div class='item' data-id='" + path + "'><br/>";

    element += "<img src='/Upload/" + path + "' width='20%'><br/>";

    element += "<button type='button' class='btn btn-primary confirmdeletion' data-toggle='modal' data-target='#ConfirmationModel'>Remove</button>";

    element += "<a href='/Upload/" + path + "' class='btn btn-primary' role='button' download>Download</a><br/>";

    element += "</div>";

    // Append element (image-box)
    $("." + identifier).append($(element));

    // Attach 'Remove' event to newly created element
    $(".confirmdeletion").on("click", function (e) {

        var fileId = $(this).parents("div.item").attr("data-id");

        $(".removeimg").attr("data-id", fileId);
    });
}

function removeImg(obj) {
    var refId = $("[name='Accessories.RefId']").val();

    var refType = $("[name='Accessories.RefTypeName']").val();

    var uniqueAttachmentId = obj.attr("data-id");

    var aViewModel =
        {
            Accessories: {

                RefId: refId,

                RefTypeName: refType,

                UniqueAttachmentId: uniqueAttachmentId
            }
        }

    PostAjaxWithProcessJson("/Accessories/RemoveImage", aViewModel, function (data) {

        $("div.item[data-id='" + uniqueAttachmentId + "']").remove();

        $('#ConfirmationModel').modal("toggle");

        FriendlyMessage(data);

    }, $("body"));
}



