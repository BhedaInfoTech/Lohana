// Hotle Basic Details and Facility Details

function SaveBasicDetails() {
    if ($("[name='Hotel.status']").val() == 1 || $("[name='Hotel.status']").val().toLowerCase() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    var hViewModel = {

        Hotel: {

            HotelId: $("[name='Hotel.HotelId']").val(),

            HotelType: $("#drphotelType").val(),

            HotelName: $("[name='Hotel.HotelName']").val(),

            HotelGroup: $("[name='Hotel.HotelGroup']").val(),

            StarCategory: $("#drpstarCategory").val(),

            HotelGroup: $("[name='Hotel.HotelGroup']").val(),

            NearestAirport: $("[name='Hotel.NearestAirport']").val(),

            NearestRailwayStation: $("[name='Hotel.NearestRailwayStation']").val(),

            NearestLandMark: $("[name='Hotel.NearestLandMark']").val(),

            CityId: $("#drpcity").val(),

            Pincode: $("[name='Hotel.PinCode']").val(),

            Address: $("[name='Hotel.Address']").val(),

            MobileNo: $("[name='Hotel.MobileNo']").val(),

            TelephoneCode: $("[name='Hotel.TelephoneCode']").val(),

            TelephoneNo: $("[name='Hotel.TelephoneNo']").val(),

            EmailId: $("[name='Hotel.EmailId']").val(),

            FaxNo: $("[name='Hotel.FaxNo']").val(),

            Website: $("[name='Hotel.Website']").val(),

            LohanaRatings: $("#drplohanaRatings").val(),

            HotelDescription: $("[name='Hotel.HotelDescription']").val(),

            TopAttractionsNearBy: $("[name='Hotel.TopAttractionNearBy']").val(),

            UsefulHotelStats: $("[name='Hotel.Stats']").val(),

            Notes: $("[name='Hotel.Notes']").val(),

            Comments: $("[name='Hotel.Comments']").val(),

            Status: activeFlg
        }
    }

    var url = "";

    if ($("[name='Hotel.HotelId']").val() == 0) {
        url = "/Hotel/Insert"
    }

    else {
        url = "/Hotel/UpdateHotel"
    }

    PostAjaxWithProcessJson(url, hViewModel, AfterSave, $("#basicdetails"));
}

function AfterSave(data) {
    FriendlyMessage(data);

    $("[name='Hotel.HotelId']").val(data.Hotel.HotelId);

    $("[name='Facility.HotelId']").val(data.Hotel.HotelId)

    $("[name='HotelRoomType.HotelId']").val(data.Hotel.HotelId)

    $("[name='HotelContactPerson.HotelId']").val(data.Hotel.HotelId)

    $("[name='Hotel.Bank.HotelId']").val(data.Hotel.HotelId)

    $("[name='Accessories.RefId']").val(data.Hotel.HotelId);

    $("#hdnHotelName").val($("[name='Hotel.HotelName']").val());

    $("#link1").show();
    $("#link2").show();
    $("#link3").show();
    $("#link4").show();
    $("#link5").show();

    //GetHotelRoomType(obj.Hotel.HotelId);

    //GetContactPerson(obj.Hotel.HotelId);

    // BindHotelFacilities(data);
}


//Image Upload

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

}

function GetImages() {

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

    var aViewModel = {

        Accessories:
            {

                RefId: $("[name='Accessories.RefId']").val(),

                RefTypeName: $("[name='Accessories.RefTypeName']").val(),
            }
    }
    
    PostAjaxJson("/Accessories/GetImagesByRefType", aViewModel, BindImages);
}

function UploadFile(obj, files)
{
    var files = files;

    var identifier = $(obj).attr("data-identifier");

    var refCategory = $(obj).attr("data-refcat");

    if (files.length > 0)
    {
        if (window.FormData !== undefined)
        {
            var formData = new FormData();

            for (var x = 0; x < files.length; x++)
            {
                formData.append("file" + x, files[x]);
            }

            formData.append("RefId", $("[name='Accessories.RefId']").val());

            formData.append("RefCategory", refCategory);          

            PostFileUploadAjaxWithProcessJson("/Accessories/Upload", formData, function (data)
            {
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
        else
        {
            alert("This browser doesn't support HTML5 file uploads!");
        }
    }
}


function BindImages(data)
{
    var htmlText = "";

    var sectionIdentifier, identifier;

    if (data.Images.length > 0)
    {
        for (i = 0; i < data.Images.length; i++)
        {
            sectionIdentifier = data.Images[i].RefCategory;

            if (sectionIdentifier == "Exterior View")
            {
                identifier = "exterior";
            }
            else if (sectionIdentifier == "Reception / Lobby")
            {
                identifier = "lobby";
            }
            else if (sectionIdentifier == "Room Type")
            {
                identifier = "roomtypes";
            }
            else if (sectionIdentifier == "Restaurant") {
                identifier = "restaurant";
            }
            else if (sectionIdentifier == "Facilities") {
                identifier = "facilities";
            }

            appendImages(identifier, data.Images[i].UniqueAttachmentId);               
        }
    }       
}

function appendImages(identifier, path)
{
    // Create Element (i.e. Image Box)

    var element = "<div class='item' data-id='" + path + "'><br/>";

    element += "<img src='/Upload/" + path + "' width='20%'><br/>";    

    element += "<button type='button' class='btn btn-primary confirmdeletion' data-toggle='modal' data-target='#ConfirmationModel'>Remove</button>";

    element += "<a href='/Upload/" + path + "' class='btn btn-primary' role='button' download>Download</a><br/>";

    element += "</div>";    
    
    // Append element (image-box)

    $("." + identifier).append($(element));

    // Attach 'Remove' event to newly created element

    $(".confirmdeletion").on("click", function (e)
    {
        var fileId = $(this).parents("div.item").attr("data-id");

        $(".removeimg").attr("data-id", fileId);
    }); 
}

function removeImg(obj)
{
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

    PostAjaxWithProcessJson("/Accessories/RemoveImage", aViewModel, function (data)
    {
        $("div.item[data-id='" + uniqueAttachmentId + "']").remove();

        $('#ConfirmationModel').modal("toggle");

        FriendlyMessage(data);

    },$("body"));
}






















































