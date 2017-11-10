$(document).ready(function () {
   
    GetSearchPackageDetails();

   
   $("#btnSearchPackage").click(function () {
      
        GetSearchPackageDetails();
    
   });
     
   $("#hdnSearchPckgId").val();

   $("#btnResetPackage").click(function () {
       $("#frmSearchPackageList").valid();
       $("#frmSearchPackageList").attr("action", "/Package/SearchPackage");
       $("#frmSearchPackageList").submit();
   });

});