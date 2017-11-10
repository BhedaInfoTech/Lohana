$(document).ready(function () {

    GetMeals();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetMealValues($(this));

            SetActive($("[name='Meal.IsActive']"), $(this).attr("data-isactive"));
        }

    });

    $("#btnSaveMeal").click(function ()
    {
        if ($("#frmMeal").valid())
        {
            SaveMeal();
        }
    });
    $("#btnSearchMeal").click(function ()
    {
        $("#tblMeal").attr("data-current-page", "0");

        GetMeals();
    });

    $("#btnResetMeal").click(function ()
    {
        document.getElementById("frmSearchMeal").reset();

        ResetMeal();
    });

});
