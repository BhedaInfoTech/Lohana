function GetPackage() {

    var pViewModel =
		{
		    Package: {

		        PackageName: $("[name='Package.packageName']").val(),

		        PackageCategoryId: $('#drppkgcategory').val(),

		        PackageTypeId: $('#drppackageType').val()

		    },
		    Pager: {

		        CurrentPage: $('#tblPackage').attr("data-current-page"),

		    },
		}

    PostAjaxJson("/Package/GetPackage", pViewModel, BindPackages);
}

function BindPackages(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["PackageCode", "PackageName", "PackageCategoryStr", "PackageDuration", "PackageCost", ],
        primayKey: "PackageId",
        hiddenFields: ["PackageId", "PackageCategoryId","PackageCode","PackageName"],
        headerNames: ["Package Code", "Package Name", "Package Category", "Package Duration", "Package Cost"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblPackage'));

    BindPagination(list.Pager, $('#tblPackage'), "PackagePagination");


}


function PackagePagination(CurrentPage) {

    $('#tblPackage').attr("data-current-page", CurrentPage);

    GetPackage();

    document.getElementById("btnEditPackage").disabled = true;

}

function ContactPersonPagination(CurrentPage) {

    $('#tblPackage').attr("data-current-page", CurrentPage);

    GetPackage();

}
