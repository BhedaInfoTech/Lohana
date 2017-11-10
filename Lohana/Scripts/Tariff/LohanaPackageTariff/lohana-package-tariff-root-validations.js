$(document).ready(function () {
    $("#frmTitle").validate({
        rules:
            {
                "Title": {
                required: true,
            }
            },
        messages: {


            "Title":
               {
                   required: "Title is required.",
               },
        }
    });

    $("#frmRoomDetails").validate({
        rules:
            {
                "CheckSelectedHotel": {
                    checkSelectedExist: true,
                }
            },
    });

    $("#frmSearchSightSeeing").validate({
        rules:
            {
                "CheckSelectedSightSeeing": {
                    checkSelectedExist: true,
                }
            },
    });
    $("#frmSearchVehicle").validate({
        rules:
            {
                "CheckSelectedVehicle": {
                    checkSelectedExist: true,
                }
            },
    });

    $("#frmSearchMeal").validate({
        rules:
            {
                "CheckSelectedMeal": {
                    checkSelectedExist: true,
                }
            },
    });


    jQuery.validator.addMethod("checkSelectedExist", function (value, element) {
        var result1 = true;
        var lpViewModel =
       {
           LohanaPackageTariffRoot: {
               LohanaPackageTariffId: $("#txtLohanaPackageTariffId").val(),
               LohanaPackageTariffRootId: $("#hdnLohanaPackageTariffRootId").val(),
               LohanaPackageTariffRefId: $("#hdnLohanaPackageTariffRefId").val(),
               LohanaPackageTariffTypeId: $("#hdnLohanaPackageTariffTypeId").val(),
           },
       }

        $.ajax({
            url: "/LohanaPackageTariff/CheckLohanaPackageTariffRootDetailExist",
            //data: JSON.stringify(lpViewModel),
            //data: { lpViewModel: lpViewModel },
            data: {LohanaPackageTariffId: $("#txtLohanaPackageTariffId").val(),
                LohanaPackageTariffRootId: $("#hdnLohanaPackageTariffRootId").val(),
                LohanaPackageTariffRefId: $("#hdnLohanaPackageTariffRefId").val(),
                LohanaPackageTariffTypeId: $("#hdnLohanaPackageTariffTypeId").val()},
            dataType: 'json',
            method: 'GET',
            async: false,
            contentType: 'application/json',
            success: function (data) {
                if (data > 0) {
                    result1 = false;
                }
            }
        });

        //PostAjaxJson("/LohanaPackageTariff/GetLohanaPackageTariffRootList", lpViewModel, AfterRootSave);
        //return GetAjaxAlreadyExists('/LohanaPackageTariff/GetLohanaPackageTariffRootList', { lpViewModel: lpViewModel }, $("#txtEmailId"), $("#hdnEmailId"));

        return result1;

    }, "Duplicate record is selected for the day.");
});