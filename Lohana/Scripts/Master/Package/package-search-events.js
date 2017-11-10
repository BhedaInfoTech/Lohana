
$(document).ready(function () {

    document.getElementById("btnEditPackage").disabled = true;
    document.getElementById("btnViewPackage").disabled = true;

    $(document).on('change', "[name='c1']", function (event) {

        debugger;

        if ($(this).prop('checked')) {

            var id = $(this).attr("data-packageid");

            $("#hdnSearchPackageId").val(id);

            document.getElementById("btnEditPackage").disabled = false;
            document.getElementById("btnViewPackage").disabled = false;
            GetPackageGitDays($(this).attr("data-packageid"));
        }

    });


   

    $("#btnSearchPackage").click(function ()
    {

        $("#tblPackage").attr("data-current-page", "0");

        GetPackage();
    });

    GetPackage();

    $("#btnEditPackage").click(function ()
    {
        $("#frmSearchPackage").attr("action", "/Package/GetPackageById");
        $("#frmSearchPackage").submit();
    });

    $("#btnViewPackage").click(function () {

        $("#frmSearchPackage").attr("target", "_blank");
        $("#frmSearchPackage").attr("action", "/Package/PackageView");
        $("#frmSearchPackage")[0].submit();
        $("#frmSearchPackage").attr("target", "_self");
     
        //$("#frmSearchPackage").attr("action", "/Package/PackageView");
        //$("#frmSearchPackage").submit();



        //window.open("", '_blank');
    });

    
 });

