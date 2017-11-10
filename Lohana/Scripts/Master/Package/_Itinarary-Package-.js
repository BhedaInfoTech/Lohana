$(document).ready(function () {

    var id = 0;

    $("#divIteneraryPackageButtons button").click(function () {

        var PackageDayId = $("[name='PackageDaysTriffInfo.PackageId']").attr("data-packagedayid");

       
        var PackageId = $("#hdnPackageId").val();

        $(this).addClass('active').siblings().removeClass('active');

        if ($(this).val() == 1) {

            LoadModal("/Package/GetDayPackageTitle?=", { PackageDayId: PackageDayId, PackageId: PackageId }, null, "Package Day Title", null);
        }
        else if ($(this).val() == 2) {

            LoadModal("/Package/GetPackageAddHotel", null, null, "Add Hotel", null);

        }
        else if ($(this).val() == 3) {

            LoadModal("/Package/GetPackageAddSightseeing", null, null, "Add Sightseeing", null);


        }
        else if ($(this).val() == 4) {


            LoadModal("/Package/GetpackageAddVehicle", null, null, "Add Vehicle", null);

        }
        else if ($(this).val() == 5) {

            LoadModal("/Package/GetpackageAddMeal", null, null, "Add Meal", null);
        }

    });


    $(document).on('change', "[name='PackageDaysTriffInfo.PackageId']", function (event) {
        
        if ($(this).prop('checked')) {

            id = $(this).attr("data-packagedayid");

            $("#packagedayId").val(id);
       
        }
    });


});