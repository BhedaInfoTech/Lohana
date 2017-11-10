// Package Dates

function SavePackageDate() {

    $("#frmPackageDateDetails").blur();

    var pViewModel = {

        PackageDate: {

            PackageDateId: $("#hdnSearchPackageDateId").val(),

            PackageStartDate: $("[name='Package.packageStartDate']").val(),

            PackageEndDate: $("[name='Package.packageEndDate']").val(),

            PackageCost : $("[ name='Package.PackageCost']").val(),

            PackageId: $("#hdnPackageDateId").val(),

        }
    }

    var url = "";

    if ($("#hdnSearchPackageDateId").val() == 0) {

        url = "/Package/InsertPackageDate"
    }
    else {

        url = "/Package/UpdatePackageDate"
    }
    PostAjaxJson(url, pViewModel, AfterPackageDateSave);
}

function AfterPackageDateSave(data) {

    FriendlyMessage(data);

    $("#hdnPackageDateId").val(data.PackageDate.PackageId);

    GetPackageDate();

    ResetPackageDate();

}

function ResetPackageDate() {

    $("#datepicker-autoclose").val('');

    $("#hdnSearchPackageDateId").val('');

    $("#datepicker1-autoclose").val('');

    $("txtpackageCost").val('');

}

function GetPackageDate() {

    debugger;

    var pViewModel =
		{
		    PackageDate: {

		        PackageId: $("#hdnPackageDateId").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblPackageDate').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/Package/GetPackageDate", pViewModel, BindPackageDate);
}

function BindPackageDate(data) {

    debugger

    var list = JSON.parse(data);

    //alert(list.dt);

    //var startdt = ToJavaScriptDate(PackageStartDate);

    //alert(startdt);

    //var enddt = ToJavaScriptDate(list.PackageEndDate);

    //alert(enddt);

    var kTable = {
        dataList: ["PackageStartDate", "PackageEndDate" , "PackageCost"],
        primayKey: "PackageDateId",
        hiddenFields: ["PackageDateId", "PackageId", "PackageStartDate", "PackageEndDate","PackageCost"],
        headerNames: ["PackageStartDate", "PackageEndDate", "PackageCost"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackageDate'));

    BindPagination(list.Pager, $('#tblPackageDate'), "PackageDatePagination");

}

function PackageDatePagination(CurrentPage) {

    $('#tblPackageDate').attr("data-current-page", CurrentPage);

    GetPackageDate();

}

function GetPackageDateById(data) {

    var pViewModel =
      {

          PackageDate: {

              PackageDateId: $("[name='PackageDateFilter.PackageDateId']").val(),

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/GetPackageDateById", pViewModel, BindPackageDateById);

}

function BindPackageDateById(data) {

    var obj = data;

    $("[name='PackageDateFilter.PackageDateId']").val(obj.PackageDate.PackageDateId),

    $("[name='Package.packageStartDate']").val(obj.PackageDate.PackageStartDate),

    $("[name='Package.packageEndDate']").val(obj.PackageDate.PackageEndDate),

    $("[ name='Package.PackageCost']").val(obj.PackageDate.PackageCost),

    $("[name='PackageDates.PackageId']").val(obj.PackageDate.PackageDateId)

}

function DeletePackageDate() {

    var pViewModel =
      {

          PackageDate: {

              PackageDateId: $("[name='PackageDateFilter.PackageDateId']").val(),

              PackageId: $("#hdnPackageDateId").val()

          },
          Pager: {

              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/Package/DeletePackageDate", pViewModel, AfterPackageDateDelete);

    $("[name='PackageDateFilter.PackageDateId']").val('');

}

function AfterPackageDateDelete(data) {

    FriendlyMessage(data);

    GetPackageDate();

    ResetPackageDate();

}