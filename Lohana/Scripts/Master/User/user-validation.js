$(document).ready(function () {

    $("#frmUser").validate({

        rules: {

            "User.FirstName":
             {
                 required: true,
             },
            "User.MiddleName":
            {
                required: true,
            },
            "User.LastName":
            {
                required: true,
            },            
           
            "User.EmailId":
             {
                 email: true,
                 required: true,                 
             },
            "User.PhoneNo":
            {
                required: true,
                number: true,
               
            },
            "User.MobileNo":
           {
               required: true,
               number: true,
              

           },
          
            "User.UserName":
          {
              required: true,

              CheckUserNameExist:true

          },
            "User.Password":
        {
            required: true,

            //PasswordCheck: true,

            //MatchPassword: true,

        },
            "User.ConfirmPassword":
          {
              required: true,

              //PasswordCheck: true,

              MatchPassword: true,

          },
            "User.City":
             {
                 City: true,
             },
            "User.Role":
            {
                Role: true,
            },
        },
        messages: {

            "User.FirstName":
                {
                    required: "First name is required."
                },
            "User.MiddleName":
                {
                    required: "Middle name is required."
                },
            "User.LastName":
                {
                    required: "Last name is required."
                },

            "User.Emaild":
              {
                  email: "Invalid email id.",
                  required: "Email id is required."
              },

            "User.PhoneNo":
             {
                 required: "Phone number is required.",
                 number: "Please enter numbers only.",
                
             },
            "User.MobileNo":
                  {
                      required: "Mobile number is required.",
                      number: "Please enter numbers only.",
                      
                  },
            "User.UserName":
                   {
                       required: "User name is required."
                   },

            "User.Password":
                  {
                      required: "Password is required.",
                      
                  },

            "User.ConfirmPassword":
                  {
                      required: "Confirm password is required."
                  },
        }

    });
    debugger;
    jQuery.validator.addMethod("CheckUserNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/User/CheckUserNameExist', { UserName: value }, $("#txtUserName"), $("#hdnUserName"));

    }, "User name already exist")  

    jQuery.validator.addMethod("City", function (value, element) {
        var result = true;

        if ($("#drpCity").val() == "0") {
            result = false;
        }

        return result;

    }, "City is required.");

    jQuery.validator.addMethod("Role", function (value, element) {
        var result = true;

        if ($("#drpUserRole").val() == "0") {
            result = false;
        }

        return result;

    }, "User role is required.");

});


//jQuery.validator.addMethod("PasswordCheck", function (value, element) {
//    debugger;
//    return /^[A-Za-z0-9\d=!\-@._*#]*$/.test(value) // consists of only these
//    && /[A-Z]/.test(value) // has a Uppercase letter
//    && /[a-z]/.test(value) // has a Lowercase letter
//    && /\d/.test(value) // has a digit
//    && /[=!\-@._*#$^]/.test(value) //has special character
//});


jQuery.validator.addMethod("MatchPassword", function (value, element) {
    var result = true;

    if ($("#txtPassword").val() != $("#txtConfirmPassword").val()) {
        result = false;
    }
    return result;

}, "Please Enter Same Password");



























