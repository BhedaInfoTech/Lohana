function CallSaveTraveller()
{
    if ($("#frmBasicDetails").valid()) {
                SaveTravellersDetails()
            }
}

function SaveTravellersDetails() {

    var activeFlg = true;

    if ($("[name='BookingCartDetailsInfo.IsActive']").val() == 1 || $("[name='BookingCartDetailsInfo.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    var bViewModel = {

        BookingCartDetailsInfo: {

            TravellerName: $("[name='BookingCartDetailsInfo.TravellerName']").val(),

            Age: $("[name='BookingCartDetailsInfo.Age']").val(),

            MobileNo: $("[name='BookingCartDetailsInfo.MobileNo']").val(),

            CustomerId: $("[name='BookingCartDetailsInfo.CustomerId']").val(),

            BookingId: $("[name='BookingCartDetailsInfo.BookingId']").val(),

            IsActive: activeFlg,

            TravellerId: $("[name='BookingCartDetailsInfo.TravellerId']").val(),

        }
    }

    var url = "";
    //url = "/Booking/InsertTravellersDetails"

    if ($("[name='BookingCartDetailsInfo.TravellerId']").val() == 0) {

        url = "/Booking/InsertTravellersDetails"
    }
    else {
        url = "/Booking/UpdateTravellersDetails"
    }


    PostAjaxWithProcessJson(url, bViewModel, AfterSave);

    ResetTravellersDetails();
}

function AfterSave(data) {
    FriendlyMessage(data);
    GetTravellersDetails(data);
}

function GetTravellersDetails(data) {

    

    //$("#hdnTravellerId").val(data.BookingCartDetailsInfo.TravellerId);
    $("#hdnBookingId").val(data.BookingCartDetailsInfo.BookingId);

    var bViewModel =
		{
		    BookingCartDetailsInfo: {

		        BookingId: data.BookingCartDetailsInfo.BookingId,
		    },
		    Pager: {

		        CurrentPage: $('#tblTravellersDetails').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Booking/GetTravellersDetails", bViewModel, BindTravellersDetails);
        //, $("#frmBasicDetails"));
}

function BindTravellersDetails(data) {
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["TravellerName", "Age", "MobileNo"],
        primayKey: "TravellersInformationId",
        hiddenFields: ["TravellersInformationId", "BookingId", "TravellerName", "Age", "MobileNo"],
        headerNames: ["Traveller Name", "Age", "Mobile No"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblTravellersDetails'));

    // BindPagination(list.Pager, $('#tblTravellersDetails'));
}

function GetSetTravellerInformatio() {


    //var selectedVal = $('input[name="c1"]:checked').attr("data-travellersinformationid");
    //alert(selectedVal);

    var id = $('input[name="c1"]:checked').attr("data-travellersinformationid");

    // $("#hdnTravellerId").val(id);
    $("[name='BookingCartDetailsInfo.TravellerId']").val(id);

    $("[name='BookingCartDetailsInfo.TravellerName']").val($('input[name="c1"]:checked').attr("data-travellername"));

    $("[name='BookingCartDetailsInfo.Age']").val($('input[name="c1"]:checked').attr("data-age"));
    //$(obj).attr("data-age"));

    $("[name='BookingCartDetailsInfo.MobileNo']").val($('input[name="c1"]:checked').attr("data-mobileno"));
    //$(obj).attr("data-mobileno"));

    document.getElementById("btnEditContactDetails").disabled = true;
    document.getElementById("btnSaveContactDetails").disabled = false;

}

function ResetTravellersDetails() {

    //  $("#hdnTravellerId").val("");

    $("[name='BookingCartDetailsInfo.TravellerId']").val("");

    $("[name='BookingCartDetailsInfo.TravellerName']").val("");

    $("[name='BookingCartDetailsInfo.Age']").val("");

    $("[name='BookingCartDetailsInfo.MobileNo']").val("");

    //if ($("[name='BookingCartDetailsInfo.IsActive']").val() == 0 || $("[name='BookingCartDetailsInfo.IsActive']").val() == "false") {
    //    $("[name='BookingCartDetailsInfo.IsActive']").trigger('click');
    //}
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

            //formData.append("RefId", $("[name='Accessories.RefId']").val());

            //formData.append("RefCategory", refCategory);

            PostFileUploadAjaxWithProcessJson("/Accessories/Upload", formData, function (data) {
                FriendlyMessage(data);

                // Set Data in hidden field
                $("[name='BookingCartDetailsInfo.AttachmentName']").val(data.FileName);

                //$("[name='Accessories.UniqueAttachmentId']").val(data.NewFileName)

                //$("[name='Accessories.RefCategory']").val(refCategory);

                //appendImages(identifier, data.NewFileName);

                // Save Image detail in dtabase
                // SaveImage();

            }, $("body"));
        }
        else {
            alert("This browser doesn't support HTML5 file uploads!");
        }
    }
}

function SaveImage() {

    var aViewModel =
        {
            BookingCartDetailsInfo: {

                AttachmentName: $("[name='BookingCartDetailsInfo.AttachmentName']").val(),

                DocumentTypeId: $("[name='BookingCartDetailsInfo.DocumentTypeId']").val(),

                DocumentNo: $("[name='BookingCartDetailsInfo.DocumentNo']").val(),

                TravellerId: $("[name='BookingCartDetailsInfo.TravellerId']").val(),

                BookingId: $("[name='BookingCartDetailsInfo.BookingId']").val()
            }
        }

    PostAjaxJson("/Booking/InsertTravellersDocumentDetails", aViewModel, AfterSaveImage);
}

function AfterSaveImage(data) {

    $("[name='BookingCartDetailsInfo.TravellerDocumentId']").val(data.BookingCartDetailsInfo.TravellerDocumentId);

    BindHTML(data)

}

function BindHTML(data) {
    
    $("#tbDocumentDetails").html("");
    var htmlstring = "";

    for (var i = 0; i < data.DocumentDetailsList.length; i++) {
        htmlstring += "<tr>";
        htmlstring += "<td>";
        htmlstring += data.DocumentDetailsList[i].TravellerName;
        htmlstring += "</td>";
        htmlstring += "<td>";
        htmlstring += data.DocumentDetailsList[i].DocumentType;
        htmlstring += "</td>";
        htmlstring += "<td>";
        htmlstring += data.DocumentDetailsList[i].DocumentNo;

        htmlstring += "</td>";
        htmlstring += "<td>";
        htmlstring += data.DocumentDetailsList[i].AttachmentName;
        htmlstring += "</td>";
        htmlstring += "<td>";
        htmlstring += "<a class='btn' style='color: red;font-weight: 800;' href='#' onclick='DeleteDoc(" + data.DocumentDetailsList[i].TravellerDocumentId + ")'><i class='ti-close'></i></a>";
        htmlstring += "</td>";
        htmlstring += "</tr>";
    }

    $("#tbDocumentDetails").append(htmlstring);
}

function DeleteTravellerDetails()
{
    var id = $('input[name="c1"]:checked').attr("data-travellersinformationid");
    var aViewModel =
       {
           BookingCartDetailsInfo: {

               TravellerId: id,

               BookingId: $("[name='BookingCartDetailsInfo.BookingId']").val()
           }
       }

    PostAjaxWithProcessJson("/Booking/DeleteTravellersDetails", aViewModel, AfterDeleteMsg);
}

function DeleteContactDetails() {
    DeleteTravellerDetails();
    document.getElementById("btnViewContactDetails").disabled = true;
    document.getElementById("btnEditContactDetails").disabled = true;
}


function AfterDeleteMsg(data) {
    FriendlyMessage(data);
    $("[name='BookingCartDetailsInfo.TravellerId']").val("");
    GetTravellersDetails(data);
    GetDocumentDetails(data);
    
    document.getElementById("btnDeleteContactDetails").disabled = true;
    document.getElementById("btnSaveContactDetails").disabled = false;
    
}

function GetDocumentDetails(data) {
    
    $("#hdnBookingId").val(data.BookingCartDetailsInfo.BookingId);

    var bViewModel =
		{
		    BookingCartDetailsInfo: {

		        BookingId: data.BookingCartDetailsInfo.BookingId,
		    },
		    Pager: {

		        CurrentPage: $('#tblTravellersDetails').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Booking/GetTravellersDocumentDetails", bViewModel, BindHTML);
}

function DeleteDoc(DocId) {
    //alert(DocId);

    var aViewModel =
        {
            BookingCartDetailsInfo: {

                TravellerDocumentId: DocId,
                BookingId: $("[name='BookingCartDetailsInfo.BookingId']").val()
            }
        }

    PostAjaxJson("/Booking/DeleteTravellersDocumentDetails", aViewModel, AfterSaveImage);
}

function BindGitDetails(data) {

    $("#tbGitDetails").html("");

    var list = JSON.parse(data);
    var GitHTMLstring = "";
    var FitHTMLString = "";
    var Counter = 0;

    for (var i = 0; i < list.length; i++) {
        if (list[i].ProductType == 1) {
            Counter =parseInt(Counter) +parseInt(1);
        }
    }

    for (var i = 0; i < list.length; i++) {

        var dd1 = new Date(parseInt(list[i].FromDate.replace('/Date(', '')));
        var dd2 = new Date(parseInt(list[i].ToDate.replace('/Date(', '')));

        if (list[i].ProductType == 1) {
           
            GitHTMLstring += "<tr>";
            GitHTMLstring += "<input type='hidden' name='GitCount' value='" + Counter + "'>"
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].FromDate' value='" + dd1.getDate().toString() + '-' + (dd1.getMonth() + 1).toString() + '-' + dd1.getFullYear().toString() + "'>"
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].ToDate' value='" + dd2.getDate().toString() + '-' + (dd2.getMonth() + 1).toString() + '-' + dd2.getFullYear().toString() + "'>"
            

            GitHTMLstring += "<td>";
            GitHTMLstring += list[i].CategoryId;
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].CategoryId' value='" + list[i].CategoryId + "'>"
            GitHTMLstring += "</td>";
            GitHTMLstring += "<td>";
            GitHTMLstring += list[i].PackageTypeId;
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].PackageTypeId' value='" + list[i].PackageTypeId + "'>"
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].ProductType' value='" + list[i].ProductType + "'>"
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].VendorId' value='" + list[i].VendorId + "'>"

            GitHTMLstring += "</td>";
            GitHTMLstring += "<td>";
            GitHTMLstring += list[i].PackageName;
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].PackageName' value='" + list[i].PackageName + "'>"
            GitHTMLstring += "</td>";
            GitHTMLstring += "<td>";
            GitHTMLstring += list[i].Destination;
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].Destination' value='" + list[i].Destination + "'>"
            GitHTMLstring += "</td>";
            GitHTMLstring += "<td>";
            GitHTMLstring += list[i].Duration;
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].Duration' value='" + list[i].Duration + "'>"
            GitHTMLstring += "</td>";
            GitHTMLstring += "<td>";
            GitHTMLstring += "Adult Count: " + list[i].AdultCount + "<br/>" + "Child Count: " + list[i].ChildCount;
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].AdultCount' value='" + list[i].AdultCount + "'>"
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].ChildCount' value='" + list[i].ChildCount + "'>"
            GitHTMLstring += "</td>";
            GitHTMLstring += "<td>";
            GitHTMLstring += list[i].NetRate;
            GitHTMLstring += "<input type='hidden' name='BookingCartDetailsInfo.GitDetailsList[" + i + "].NetRate' value='" + list[i].NetRate + "'>"
            GitHTMLstring += "</td>";
            GitHTMLstring += "</tr>";
            
        }
    }
    $("#tbGitDetails").append(GitHTMLstring);
   // $("#tbFitDetails").append(FitHTMLString);

}

function SaveGitDetails() {
    // $("#frmflightdetails").blur();

    var ListLength = $("[name='GitCount']").val();
   

    var GitDetailList = [];


    for (var i = 0; i < ListLength; i++) {

        var BookingCartDetailsInfo =

                   {

                       CategoryId: $("[name='BookingCartDetailsInfo.GitDetailsList["+i+"].CategoryId']").val(),

                       PackageTypeId: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].PackageTypeId']").val(),

                       VendorId: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].VendorId']").val(),

                       ProductType: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].ProductType']").val(),

                       PackageName: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].PackageName']").val(),

                       Destination: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].Destination']").val(),

                       AdultCount: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].AdultCount']").val(),

                       ChildCount: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].ChildCount']").val(),

                       NetRate: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].NetRate']").val(),

                       Duration: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].Duration']").val(),

                       FromDate: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].FromDate']").val(),

                       ToDate: $("[name='BookingCartDetailsInfo.GitDetailsList[" + i + "].ToDate']").val(),

                       BookingId: $("[name='BookingCartDetailsInfo.BookingId']").val()

                   }

        GitDetailList.push(BookingCartDetailsInfo);
    }

    var aViewModel = {

        BookingCartDetailsInfo: {
            GitDetailsList: GitDetailList
        }
    }

    PostAjaxWithProcessJson("/Booking/SaveGitDetails", aViewModel, $("body"));
    document.getElementById("btnSaveGitDetails").disabled = true;

}


function BindFitDetails(data)
{
    $("#tbFitDetails").html("");
    var FitHTMLString = "";

    var list = JSON.parse(data);
    var Counter = 0;

    for (var i = 0; i < list.length; i++) {
        if (list[i].ProductType == 2) {
            Counter = parseInt(Counter) + parseInt(1);
        }
    }

    for (var i = 0; i < list.length; i++) {

        var dd1 = new Date(parseInt(list[i].FromDate.replace('/Date(', '')));
        var dd2 = new Date(parseInt(list[i].ToDate.replace('/Date(', '')));

        if (list[i].ProductType == 2) {
            FitHTMLString += "<tr>";
            FitHTMLString += "<input type='hidden' name='FitCount' value='" + list.length + "'>"

                FitHTMLString += "<td>";
                FitHTMLString += list[i].CategoryId;
                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].CategoryId' value='" + list[i].CategoryId + "'>"
                FitHTMLString += "</td>";
                FitHTMLString += "<td>";
                FitHTMLString += list[i].PackageTypeId;
                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].PackageTypeId' value='" + list[i].PackageTypeId + "'>"

                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].ProductType' value='" + list[i].ProductType + "'>"

                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitHTMLString[" + i + "].VendorId' value='" + list[i].VendorId + "'>"

                FitHTMLString += "</td>";
                FitHTMLString += "<td>";
                FitHTMLString += list[i].PackageName;
                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].PackageName' value='" + list[i].PackageName + "'>"
                FitHTMLString += "</td>";

                FitHTMLString += "<td>";
                FitHTMLString += list[i].Destination;
                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].Destination' value='" + list[i].Destination + "'>"

                FitHTMLString += "</td>";
                FitHTMLString += "<td>";
                FitHTMLString += list[i].Duration;
                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].Duration' value='" + list[i].Duration + "'>"

                FitHTMLString += "</td>";
                FitHTMLString += "<td>";
                FitHTMLString += "Adult Count: " + list[i].AdultCount + "<br/>" + "Child Count: " + list[i].ChildCount;
                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].AdultCount' value='" + list[i].AdultCount + "'>"

                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].ChildCount' value='" + list[i].ChildCount + "'>"


                FitHTMLString += "</td>";
                FitHTMLString += "<td>";
                FitHTMLString += list[i].NetRate;
                FitHTMLString += "<input type='hidden' name='BookingCartDetailsInfo.FitDetailsList[" + i + "].NetRate' value='" + list[i].NetRate + "'>"

                FitHTMLString += "</td>";
                FitHTMLString += "</tr>";

        }
    }
    $("#tbFitDetails").append(FitHTMLString);

}

function SaveFitDetails() {
    // $("#frmflightdetails").blur();

    var ListLength = $("[name='FitCount']").val();
    

    var GitDetailList = [];


    for (var i = 0; i < ListLength; i++) {

        var BookingCartDetailsInfo =

                   {

                       CategoryId: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].CategoryId']").val(),

                       ProductType: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].ProductType']").val(),

                       VendorId: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].VendorId']").val(),

                       PackageTypeId: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].PackageTypeId']").val(),

                       PackageName: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].PackageName']").val(),

                       Destination: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].Destination']").val(),

                       AdultCount: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].AdultCount']").val(),

                       ChildCount: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].ChildCount']").val(),

                       NetRate: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].NetRate']").val(),

                       Duration: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].Duration']").val(),

                       FromDate: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].FromDate']").val(),

                       ToDate: $("[name='BookingCartDetailsInfo.FitDetailsList[" + i + "].ToDate']").val(),

                       BookingId: $("[name='BookingCartDetailsInfo.BookingId']").val()

                   }

        GitDetailList.push(BookingCartDetailsInfo);
    }

    var aViewModel = {

        BookingCartDetailsInfo: {
            FitDetailsList: GitDetailList
        }
    }

    PostAjaxWithProcessJson("/Booking/SaveFitDetails", aViewModel, $("body"));
    document.getElementById("btnSaveFitDetails").disabled = true;

}

//Train



//}
