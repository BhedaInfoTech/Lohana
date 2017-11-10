//function GetCustomerCategoryMargin() {

//    var htViewModel =
//		{
//		    HotelTariffCustomerCategory: {

//		        CustomerCategoryId: $("#drpCustomerCategory").val(),

//		    }
//		}

//    PostAjaxJson("/HotelTariff/GetCustomerCategoryMargin", htViewModel,BindMargin);
//}
//function BindMargin(data) {

//    $("[name='HotelTariffCustomerCategory.Margin']").val(data.CustomerCategories[0].Margin)

//}

//function SaveHotelTariffCustomerCategory() {

//    $("#frmHotelTariffCustomerCategory").blur();

//    var htViewModel = {

//        HotelTariffCustomerCategory: {

//            HotelTariffCustomerCategoryId: $("[name='HotelTariffCustomerCategoryFilter.HotelTariffCustomerCategoryDetailsId']").val(),

//            HotelTariffDurationDetailsId: $("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val(),

//            HotelTariffRoomDetailsId: $("[name='HotelTariffCustomerCategory.HotelTariffRoomDetailsId']").val(),

//            CustomerCategoryId: $("#drpCustomerCategory").val(),

//            Margin: $("[name='HotelTariffCustomerCategory.Margin']").val(),
//        }
//    }
//    var url = "";

//    if ($("[name='HotelTariffCustomerCategoryFilter.HotelTariffCustomerCategoryDetailsId']").val() == 0) {

//        url = "/HotelTariff/InsertCustomerCategory"
//    }
//    else {

//        url = "/HotelTariff/UpdateCustomerCategory"
//    }
//    PostAjaxJson(url, htViewModel, AfterCustomerCategorySave);
//}

//function AfterCustomerCategorySave(data) {

//    FriendlyMessage(data);

//    ResetCustomerCategory();

//    GetHotelTariffCustomerCategory();

//}

//function ResetCustomerCategory() {

//    $("[name='HotelTariffCustomerCategoryFilter.HotelTariffCustomerCategoryDetailsId']").val('');

//    $("#drpCustomerCategory").val('0');

//    $("[name='HotelTariffCustomerCategory.Margin']").val('');

//    //$("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val('');

//    //$("[name='HotelTariffCustomerCategory.HotelTariffRoomDetailsId']").val('');
//}

//function GetHotelTariffCustomerCategory() {

//    var htViewModel =
//		{
//		    HotelTariffCustomerCategory: {

//		        HotelTariffDurationDetailsId: $("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val(),

//		        HotelTariffRoomOccupancyId: $("[name='HotelTariffCustomerCategory.HotelTariffDateDetailsId']").val(),

//		    },
//		    Pager: {

//		        CurrentPage: $('#tblHotelTariffCustomerCategory').attr("data-current-page"),
//		    },
//		}

//    PostAjaxJson("/HotelTariff/GetCustomerCategory", htViewModel, BindHotelTariffCustomerCategory);
//}

//function BindHotelTariffCustomerCategory(data) {

//    var list = JSON.parse(data);

//    var kTable = {
//        dataList: ["CustomerCategoryName", "Margin"],
//        primayKey: ["HotelTariffCustomerCategoryId"],
//        hiddenFields: ["HotelTariffDurationDetailsId", "HotelTariffDateDetailsId", "HotelTariffCustomerCategoryId", "CustomerCategoryId", "CustomerCategoryName", "Margin"],
//        headerNames: ["Customer Category", "Margin"],
//        data: list.dt,
//    }

//    buildHtmlTable(kTable, $('#tblHotelTariffCustomerCategory'));

//    BindPagination(list.Pager, $('#tblHotelTariffCustomerCategory'), "HotelTariffCustomerCategoryPagination");

//}

//function GetSetHotelTariffCustomerCategory(obj)
//{
//    var customercategoryname = $(obj).attr("data-customercategoryname");

//    var margin = $(obj).attr("data-margin");

//    var customercategoryid = $(obj).attr("data-customercategoryid");

//    $("#drpCustomerCategory").val(customercategoryid);

//    $("[name='HotelTariffCustomerCategory.Margin']").val(margin);

//    $("#lblcategory").text(customercategoryname),

//    $("#lblmargin").text(margin)

//    //ResetPrice();

//    //GetHotelTariffPrice();


//}

//function DeleteCustomerCategory() {

//    var htViewModel =
//      {

//          HotelTariffCustomerCategory: {

//              HotelTariffCustomerCategoryId: $("[name='HotelTariffCustomerCategoryFilter.HotelTariffCustomerCategoryDetailsId']").val(),

//              HotelTariffDurationDetailsId: $("[name='HotelTariffCustomerCategory.HotelTariffDurationDetailsId']").val(),

//              HotelTariffRoomDetailsId: $("[name='HotelTariffCustomerCategory.HotelTariffRoomDetailsId']").val(),

//          },
//          Pager: {

//              CurrentPage: $('#tblHotelTariffCustomerCategory').attr("data-current-page"),
//          },
//      }

//    PostAjaxJson("/HotelTariff/DeleteCustomerCategory", htViewModel, AfterCustomerCategoryDelete);

//}

//function AfterCustomerCategoryDelete(data) {

//    FriendlyMessage(data);

//    ResetCustomerCategory();

//    GetHotelTariffCustomerCategory();
//}

//function HotelTariffCustomerCategoryPagination(CurrentPage) {

//    $('#tblHotelTariffCustomerCategory').attr("data-current-page", CurrentPage);

//    GetHotelTariffCustomerCategory();
//}