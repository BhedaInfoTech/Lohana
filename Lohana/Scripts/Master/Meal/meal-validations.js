$(document).ready(function () {

    $("#frmMeal").validate({

        rules: {

            "Meal.MealName":
             {
                 required: true,
                 CheckMealNameExist: true
             },

            "Meal.MealDescription":
             {
                 required:true
             }

        },
        messages: {
         
            "Meal.MealName":
                {
                    required: "Meal name is required."
                },
            "Meal.MealDescription":
             {
                 required: "Meal description is required."
             }

        }

    });

    jQuery.validator.addMethod("CheckMealNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Meal/CheckMealNameExist', { MealName: value }, $("#txtMealName"), $("#hdnMealName"));

    }, "Meal name already exist.")

});





