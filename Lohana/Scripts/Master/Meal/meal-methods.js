function SaveMeal() {

    if ($("[name='Meal.IsActive']").val() == 1 || $("[name='Meal.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    $("#frmMeal").blur();

    var mViewModel = {

        Meal: {

            MealName: $("[name='Meal.MealName']").val(),

            MealDescription: $("[name='Meal.MealDescription']").val(),

            IsActive: activeFlg,

            MealId: $("[name='Filter.MealId']").val()      
        }
    }
 
    var url = "";

    if ($("[name='Filter.MealId']").val() == 0)
    {

        url = "/Meal/Insert"
    }
    else
    {
        url = "/Meal/Update"
    }

    PostAjaxWithProcessJson(url, mViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetMeal();

    GetMeals();
}

function GetMeals() {

    var mViewModel =
		{
		    Meal: {

		        MealId: "",

		        MealName: $("[name='Meal.MealName']").val(),

		        MealDescription: $("[name='Meal.MealDescription']").val(),

		        IsActive: $("[name='Meal.IsActive']").val()
		    
		    },
		    Pager: {

		        CurrentPage: $('#tblMeal').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Meal/GetMeals", mViewModel, BindMeals, $("#frmSearchMeal"));
}

function BindMeals(data) {

    var list = JSON.parse(data);
    var kTable = {
        dataList: ["MealName", "MealDescription","IsActiveStr"],
        primayKey: "MealId",
        hiddenFields: ["MealId", "MealName", "MealDescription", "IsActive"],
        headerNames: ["Meal Name", "Meal Description","Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblMeal'));

    BindPagination(list.Pager, $('#tblMeal'));

}

function ResetMeal() {

    $("[name='Meal.MealName']").val("");

    $("[name='Meal.MealDescription']").val("");

    $("[name='Meal.MealId']").val("");

    $("[name='Filter.MealId']").val("");

    if ($("[name='Meal.IsActive']").val() == 0 || $("[name='Meal.IsActive']").val() == "false")
    {
        $("[name='Meal.IsActive']").trigger('click');

    }
}


function Pagination(CurrentPage) {

    $('#tblMeal').attr("data-current-page", CurrentPage);

    GetMeals();

}

function GetSetMealValues(obj) {

    var id = $(obj).attr("data-mealid");

    var mealName = $(obj).attr("data-mealname");

    var mealDescription = $(obj).attr("data-mealdescription");
  
    $("#hdnSearchMealId").val(id);

    $("[name='Meal.MealName']").val(mealName);

    $("[name='Meal.MealDescription']").val(mealDescription);


}

