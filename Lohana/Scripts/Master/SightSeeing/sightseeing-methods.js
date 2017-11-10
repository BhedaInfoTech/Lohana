

function SaveSightSeeing() {
  //  alert()

    if ($("[name='SightSeeing.IsActive']").val() == 1 || $("[name='SightSeeing.IsActive']").val() == "true") {

        activeFlg = true;
    }
    else {
        activeFlg = false;
    }
    var days=[];

    $('input[name="SightSeeing.OperationalDays"]:checked').each(function (i) {
       
        days[i] = $(this).val();
     
    });

    var DaysValue = days.join();  

    $("#frmSightSeeing").blur();

    var sViewModel = {

        SightSeeing: {

            SightSeeingId:$("[name='SightSeeing.SightSeeingId']").val(),
          
            SightSeeingName: $("[name='SightSeeing.SightSeeingName']").val(),

            CityId: $("#drpCity").val(),

            Description: $("[name='SightSeeing.Description']").val(),

            TimeFrom: $("[name='SightSeeing.TimeFrom']").val(),

            TimeTo: $("[name='SightSeeing.TimeTo']").val(),

            VisitTime: $("[name='SightSeeing.VisitTime']").val(),

            IsActive: activeFlg,

            TotalCost: $("[name='SightSeeing.TotalCost']").val(),

            OperationalDays: DaysValue,

            VehicleType: $("[name='SightSeeing.VehicleType']").val(),

            VendorId: $("[name='SightSeeing.VendorId']").val(),

            DeparturePoint: $("[name='SightSeeing.DeparturePoint']").val(),

            Duration: $("[name='SightSeeing.Duration']").val(),

            Disclaimer: $("[name='SightSeeing.Disclaimer']").val(),

            Highlights: $("[name='SightSeeing.Highlights']").val(),

            AdditionalInformation: $("[name='SightSeeing.AdditionalInformation']").val(),

            DepartureTimeTo: $("[name='SightSeeing.DepartureTimeTo']").val(),

            DepartureTimeFrom: $("[name='SightSeeing.DepartureTimeFrom']").val(),

        }
    }

    var url = "";
  

    if ($("[name='SightSeeing.SightSeeingId']").val() == 0) {


        url = "/SightSeeing/Insert"
    }
    else {


        url = "/SightSeeing/Update"
       
    }

    PostAjaxWithProcessJson(url, sViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    $("#hdnSightSeeingId").val(data.SightSeeing.SightSeeingId);

    $("[name='Accessories.RefId']").val(data.SightSeeing.SightSeeingId);


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