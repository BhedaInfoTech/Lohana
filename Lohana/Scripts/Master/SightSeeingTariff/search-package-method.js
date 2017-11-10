
function GetSearchPackageDetails() {

    var pViewModel =
		{
		    Package: {

		        PackageName: $("[name='Package.packageName']").val(),

		        PackageCategoryId: $('#drppkgcategory').val(),

		        PackageTypeId: $('#drppackageType').val()

		    },
		    Pager: {

		       
		    },
		}


    PostAjaxJson("/Package/GetSearchPackageDetails", pViewModel, function (data) { $("#divPackgeBasicDetails").html(data); });
}

function ViewPackageData(rowId) {
   
    $("#hdnSearchPckgId").val(rowId);

    $("#frmSearchPackageList").attr("target", "_blank");
    $("#frmSearchPackageList").attr("action", "/Package/PackageView");
    $("#frmSearchPackageList")[0].submit();
    $("#frmSearchPackageList").attr("target", "_self");

}
