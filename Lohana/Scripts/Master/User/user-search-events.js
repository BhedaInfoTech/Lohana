$(document).ready(function () {

    GetUser();

    document.getElementById("btnEditUser").disabled = true;

    $(document).on('change', "[name='c1']", function (event)
    {
        if ($(this).prop('checked'))
        {
            var id = $(this).attr("data-userid");

            $("#hdnSearchUserId").val(id);

            //alert($("#hdnSearchUserId").val(id));

            document.getElementById("btnEditUser").disabled = false;
        }

    });

    $("#btnSearchUser").click(function () {

        $("#tblUser").attr("data-current-page", "0");

        GetUser();
    });

    $("#btnEditUser").click(function () {

        $("#frmSearchUser").attr("action", "/User/GetUserById");

        $("#frmSearchUser").submit();

    });

    $("#btnResetUser").click(function () {

        document.getElementById("frmSearchUser").reset();

    });
});


