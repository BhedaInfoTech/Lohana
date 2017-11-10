$(function () {
    //GetRootDayWiseList();

    GetAutocompleteScript("LohanaPackageTariffSightSeeing");
    GetAutocompleteScript("LohanaPackageTariffVehicle");
    //GetAutocompleteById("LohanaPackageTariffSightSeeing.CityId");

    $(document).on('change', "[name='LohanaPackageTariff.Day']", function (event) {
        if ($(this).prop('checked')) {
            //GetSetBasicValues($(this));
            //var id = $(this).attr("data-lohanapackagetariffid");
            //$("#hdnLohanaPackageTariffId").val(id);
            //SetActive($("[name='LohanaPackageTariff.IsActive']"), $(this).attr("data-isactive"));
            //GetRootDayWiseList();
            var id = $(this).val();
            var title = $(this).attr('data-Title');
            $("#hdnLohanaPackageTariffRootId").val(id);
            $("#txtTitle").val(title);
            $("#btnAddTitle").attr("disabled", false);
            $("#btnAddHotel").attr("disabled", false);
            $("#btnAddSightSeeing").attr("disabled", false);
            $("#btnAddVehicle").attr("disabled", false);
            $("#btnAddMeal").attr("disabled", false);
            //SetRootValue();
        }

    });

    $(document).on('change', "#tblSightSeeing [name='c1']", function (event) {
        if ($(this).prop('checked')) {
            var id = $(this).attr("data-sightseeingid");
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffRefId").val(id);
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffTypeId").val($("#frmSearchSightSeeing input#hdnLohanaPackageTariffTypeId").val());
            $("#btnSaveSightSeeing").attr("disabled", false);
            //SetRootValue();
        }
    });

    $("#btnSaveSightSeeing").click(function () {

        if ($("#frmSearchSightSeeing").valid()) {
            SaveRootDetail();
            $("#modalSightSeeing").modal("hide");
            //$("#btnDeleteLohanaPackageTariffHotel").attr("disabled", true);
        }
    });

    $("#btnAddSightSeeing").click(function (event) {

        $("#modalSightSeeing").modal("show");
        ResetSightSeeing();
        GetSightSeeingListing();
    });

    $("#btnSearchSightSeeing").click(function () {
        $("#tblSightSeeing").attr("data-current-page", "0");
        GetSightSeeingListing();
    });

    $("#btnResetSightSeeing").click(function () {
        ResetSightSeeing();
    });

    $(document).on('change', "#tblVehicle [name='c1']", function (event) {
        if ($(this).prop('checked')) {
            var id = $(this).attr("data-vehicleid");
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffRefId").val(id);
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffTypeId").val($("#frmSearchVehicle input#hdnLohanaPackageTariffTypeId").val());
            $("#btnSaveVehicle").attr("disabled", false);
            //SetRootValue();
        }
    });

    $("#btnSaveVehicle").click(function () {

        if ($("#frmSearchVehicle").valid()) {
            SaveRootDetail();
            $("#modalVehicle").modal("hide");
            //$("#btnDeleteLohanaPackageTariffHotel").attr("disabled", true);
        }
    });

    $("#btnAddVehicle").click(function (event) {

        $("#modalVehicle").modal("show");
        ResetVehicle();
        GetVehicleListing();
    });

    $("#btnSearchVehicle").click(function () {
        $("#tblVehicle").attr("data-current-page", "0");
        GetVehicleListing();
    });

    $("#btnResetVehicle").click(function () {
        ResetVehicle();
    });

    $(document).on('change', "#tblMeal [name='c1']", function (event) {
        if ($(this).prop('checked')) {
            var id = $(this).attr("data-mealid");
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffRefId").val(id);
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffTypeId").val($("#frmSearchMeal input#hdnLohanaPackageTariffTypeId").val());
            $("#btnSaveMeal").attr("disabled", false);
            //SetRootValue();
        }
    });

    $("#btnSaveMeal").click(function () {

        if ($("#frmSearchMeal").valid()) {
            SaveRootDetail();
            $("#modalMeal").modal("hide");
            //$("#btnDeleteLohanaPackageTariffHotel").attr("disabled", true);
        }
    });

    $("#btnAddMeal").click(function (event) {
        $("#modalMeal").modal("show");
        $("#btnSaveMeal").attr("disabled", true);
        //ResetMeal();
        GetMealsList();
    });

    $("#btnSearchMeal").click(function () {
        $("#tblMeal").attr("data-current-page", "0");
        GetMealsList();
    });

    $("#btnResetMeal").click(function () {
        document.getElementById("frmSearchMeal").reset();
        $("#btnSaveMeal").attr("disabled", true);
        //ResetMealList();
    });

    $("#btnAddTitle").click(function (event) {
        $("#txtTile").val($("#hdnLohanaPackageTariffTitle").val());
        $("#modalTitle").modal("show");
    });

    $("#btnSaveTitle").click(function (event) {
        if ($("#frmTitle").valid()) {
            SaveRootTitle();
            $("#modalTitle").modal("hide");
        }
    });

    $("#btnYes").click(function (event) {
            DeleteRoot();
            $("#modalConfirmDelete").modal("hide");
    }); 
});