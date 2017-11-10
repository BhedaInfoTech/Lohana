function SaveImage() {

    var aViewModel =
        {

            Accessories: {

                AttachmentName: $("[name='Accessories.AttachmentName']").val(),

                RefTypeName: $("[name='Accessories.RefTypeName']").val(),

                RefId: $("[name='Accessories.RefId']").val(),

                RefCategory: $("[name='Accessories.RefCategory']").val()

            }

        }

    PostAjaxJson("/Accessories/Insert", aViewModel, AfterSaveImage);


}

function AfterSaveImage(data) {


    $("[name='Accessories.AttachmentId']").val(data.Accessories.AttachmentId);

    $("[name='Accessories.RefId']").val(data.Accessories.RefId);

    $("[name='Accessories.RefType']").val(data.Accessories.RefType);

    $("[name='Accessories.RefCategory']").val(data.Accessories.RefCategory);

    debugger;

    GetImages();

}

function GetImages() {

    var aViewModel = {

        Accessories: {

            AttachmentId:  $("[name='Accessories.AttachmentId']").val(),

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

function BindImages(data) {

    var htmlText = "";

    if (data.Images.length > 0) {



        for (i = 0; i < data.Images.length; i++) {

            htmlText += "<div class='item'>";

            htmlText += "<img src='../Upload/" + data.Images[i].AttachmentName + "' width='200' >";

            htmlText += "</div>";

        }

    }

    $("#divImage").append(htmlText);

}

//function BindImages(data) {


//    var htmlText = "";

//    if (data.Images.length > 0) {

//        for (i = 0; i < data.Images.length; i++)
//        {

//            htmlText += "<div class='item'>";

//            htmlText += "<img src='../Upload/" + data.Images[i].AttachmentName + "' width='200' class='img-thumbnail'>";
          
//            htmlText += "</div>";

//        }
       

//    }
//    else {
//        htmlText += "<div>";

//        htmlText += "No Images Found.";

//        htmlText += "</div>";

//    }
   

//    $("#divImage").html(htmlText);



//}

