$(document).ready(function () {

    GetRoomTypes();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {
            GetSetRoomTypeValues($(this));

            SetActive($("[name='RoomType.IsActive']"), $(this).attr("data-isactive"));
        }
    });       

    $("#btnSaveRoomType").click(function ()
    {
        if($("#frmRoomType").valid())
        {
            SaveRoomType();
        }

    });

    $("#btnSearchRoomType").click(function ()
    {
        $("#tblRoomType").attr("data-current-page", "0");

        if($("#frmSearchRoomType").valid())
        {

            GetRoomTypes();
        }

    });

    $("#btnResetRoomType").click(function ()
    {
        document.getElementById("frmSearchRoomType").reset();

        ResetRoomType();
    });  

});

