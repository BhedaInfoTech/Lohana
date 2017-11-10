$(document).ready(function () {

    //$("#frmLohanaPackageTariffHotel").validate({
    $("#frmRoomDetails").validate({
        rules:
            {

                /*"LohanaPackageTariffHotel.NoOfNight":
                 {
                     required: true,
                     number: true,
                     checknoofnight:true,
                 },*/
                CheckSelectedHotel: {
                    checkduplicatehotel: true,
                    selecthotel:true
                }
              
            },
        messages: {


            /*"LohanaPackageTariffHotel.NoOfNight":
               {
                   required: "No of nights required.",
                   number: "Enter only numbers"
               },*/
            

        }
    });
    /*jQuery.validator.addMethod("checknoofnight", function (value, element) {

        var result = true;

        var newnoofnight = $("[name='LohanaPackageTariffHotel.NoOfNight']").val();

        var oldnoofnight = $("[name='LohanaPackageTariffHotel.Nights']").val();

        newnoofnight = parseInt(newnoofnight, 10);

        oldnoofnight = parseInt(oldnoofnight, 10);

        if (newnoofnight > oldnoofnight) {

            result = false;
        }


        return result;

    }, "Please enter valid no of nights.");*/

    jQuery.validator.addMethod("checkduplicatehotel", function (value, element) {

        var result = true;
        var arrmain = [];
        $("#tblLohanaPackageTariffHotel tr:gt(0)").each(function () {
            arrmain.push($(this).find("td:first").find("input[type=radio]").attr("data-hoteltariffroomoccupancyid")); //put elements into array
        });

        if (arrmain != undefined && arrmain.length != 0) {
            if (jQuery.inArray($("#hdnHotelTariffRoomDetailsId").val(), arrmain) !== -1) {
                result = false;
            }
        }
        return result;

    }, "Duplicate hotel is selected.");

    jQuery.validator.addMethod("selecthotel", function (value, element) {

        var result = true;
        if ($("#hdnHotelTariffRoomDetailsId").val() == '') {
            result = false;
        }
        return result;

    }, "Please select hotel.");

});