
$(document).ready(function () {

    $("#btnAddHotel").click(function (event) {

        $("#modalHotel").modal("show");
        ResetHotel();
       GetHotelListing();

    });

    $(document).on('change', "#drpCity", function (event) {

        GetHotelsDrp($(this).val());

    });
    $("#btnSearchLohanaPackageHotel").click(function () {

        $("#tblHotelTariffRoomDetails").attr("data-current-page", "0");

        GetHotelListing();

    });

    $(document).on('change', "#tblHotelTariffRoomDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            var hoteltariffroomdetailsid = $(this).attr("data-hoteltariffroomdetailsid");

            var hoteltariffroomoccupancyid = $(this).attr("data-hoteltariffroomoccupancyid");

            var noofnight = $(this).attr("data-noofnight");

            var roomtypename = $(this).attr("data-roomtypename");

            var mealname = $(this).attr("data-mealname");

            var Details=roomtypename+"/"+mealname+"/"+noofnight;

            $("#txtHotelTariffRoomDetailsId").val(hoteltariffroomdetailsid);

            $("#hdnHotelTariffRoomDetailsId").val(hoteltariffroomdetailsid);

            $("#hdnHotelTariffRoomOccupancyId").val(hoteltariffroomoccupancyid);

            $("#txtNights").val(noofnight);

            $("#lblDetails").text(Details);

            $("[name='LohanaPackageTariffHotel.Nights']").val(noofnight);

            var id = $(this).attr("data-hoteltariffroomdetailsid");
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffRefId").val(id);
            $("#frmLohanaPackageTariffRootDetails input#hdnLohanaPackageTariffTypeId").val($("#frmRoomDetails input#hdnLohanaPackageTariffTypeId").val());
            $("#btnAddLohanaPackageTariffHotel").attr("disabled", false);

        }

    });

    $(document).on('change', "#tblLohanaPackageTariffHotel [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetHotelValues($(this));
            $("#btnDeleteLohanaPackageTariffHotel").removeAttr("disabled");            
        }

    });



    $("#btnAddLohanaPackageTariffHotel").click(function () {

        //if ($("#frmLohanaPackageTariffHotel").valid()) {
        if ($("#frmRoomDetails").valid()) {

            //SaveHotel();
            SaveRootDetail();
            $("#modalHotel").modal("hide");
            $("#btnAddLohanaPackageTariffHotel").attr("disabled", true);
        }
    });

    $("#btnResetLohanaPackageTariffHotel").click(function () {

        //document.getElementById("frmLohanaPackageTariffHotel").reset();
        document.getElementById("frmRoomDetails").reset();

        //$("#lblDetails").text('');
        ResetHotel();
        $("#btnAddLohanaPackageTariffHotel").attr("disabled", true);

    });

    $("#btnDeleteLohanaPackageTariffHotel").click(function () {

        DeleteHotel();

    });
});