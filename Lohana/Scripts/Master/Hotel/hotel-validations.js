$(document).ready(function () {
    $("#frmHotelBasicDetails").validate({
        rules: {
            "Hotel.HotelName":
             {
                 required: true,
                 CheckHotelNameExist: true
             },
            "Hotel.HotelType":
             {
                 DropdownRequired: true
             },

            "Hotel.HotelGroup":
               {
                   required: true
               },

            "Hotel.StarCategory":
            {
                DropdownRequired: true
            },

            "Hotel.NearestLandMark":
             {
                 required: true
             },
            "Hotel.CityId":
              {
                  DropdownRequired: true
              },
            "Hotel.PinCode":
               {
                   number: true,
                   required: true,
                   maxlength: 6,
               },
            "Hotel.MobileNo":
              {
                  number: true,

                  //required: function (element) {
                  //    return $("#txttelephoneNo").is(':empty');
                  //},

                  required: function () {
                      if ($('#txttelephoneNo').val() == "")//return value based on textbox1 status
                          return true;
                      else
                          return false;
                  },


              },
            "Hotel.TelephoneNo":
            {
                number: true,

                //required: function (element) {
                //    return $("#txtmobileNo").is(':empty');
                //},

                required: function () {
                    if ($('#txtmobileNo').val() == "")//return value based on textbox1 status
                        return true;
                    else
                        return false;
                },

            },

            "Hotel.EmailId":
             {
                 required: true,
                 email: true,
             },
            "Hotel.FaxNo":
             {
                 //required: true
             },
            "Hotel.Website":
             {
                 //Url: true,
                 CheckWebsiteExist: true,
             },
            "Hotel.TelephoneCode":
             {
                 number: true,
                 required:true,
             }
        },
        messages: {
            "Hotel.HotelName":
                {
                    required: "Hotel name is required."
                },
            "Hotel.HotelType":
             {
                 DropdownRequired: "Hotel type is required."
             },
            "Hotel.StarCategory":
            {
                DropdownRequired: "Star category is required."
            },
            "Hotel.CityId":
              {
                  DropdownRequired: "City is required."
              },

            "Hotel.HotelGroup":
                {
                    required: "Hotel group is required."
                },

            "Hotel.NearestLandMark":
                {
                    required: "Nearest landmark is required."
                },

            "Hotel.PinCode":
           {
               required: "PIN code is required.",
               number: "Enter digits only."
           },

            "Hotel.MobileNo":
          {
              required: "Mobile number is required.",
              number: "Enter digits only."
          },

            "Hotel.TelephoneNo":
          {
              required: "Telephone number is required.",
              number: "Enter digits only."
          },

            "Hotel.EmailId":
          {
              required: "Email id is required.",
              email: "Invalid email id.",
          },
            "Hotel.FaxNo":
            {
                required: "Fax no is required."
            },
            //"Hotel.Website":
            // {
            // 	//Url: "Invalid url."
            // }

            "Hotel.TelephoneCode":
                {
                    required: "Telephone Code  is required."
                }
        }
    });

    //jQuery.validator.addMethod("CheckHotelNameExist", function (value, element)
    //{
    //    return GetAjaxAlreadyExists('/Hotel/CheckHotelNameExist', { CityId: value }, $("#drpCity").val());

    //}, "Hotel name is already exist.");


    jQuery.validator.addMethod("CheckHotelNameExist", function (value, element) {

        var result = true;

        if ($("#txthotelName").val() != "" && $("#hdnHotelName").val() != $("#txthotelName").val()) {

            $.ajax({
                url: '/Hotel/CheckHotelNameExist',
                data: {
                    cityId: $("#drpcity").val(),
                    hotelName: value,

                },
                method: 'GET',
                async: false,
                success: function (data) {
                    debugger;
                    if (data == true) {
                        result = false;
                    }
                }
            });
        }

        return result;

    }, "Hotel Name is already exists for this loaction.");



    jQuery.validator.addMethod("CheckWebsiteExist", function (value, element) {
        return GetAjaxAlreadyExists('/Hotel/CheckWebsiteExist', { Website: value }, $("#txtwebsite"), $("#hdnwebsite"));
    }, "Hotel website is already exist.");


});
















































//jQuery.validator.addMethod("Url", function (value, element) {
//    return /^http(s)?:\/\/(www\.)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/.test(value);
//});



//$("#frmHotelbank").validate({
//	rules: {
//		"Hotel.Bank.BankName":
//         {
//         	required: true,
//         },
//		"Hotel.Bank.BranchName":
//         {
//         	required: true
//         },
//		"Hotel.Bank.AccountNo":
//       {
//       	required: true
//       },
//		"Hotel.Bank.IFSCCode":
//         {
//         	required: true,
//         },
//		"Hotel.Bank.MICRCode":
//         {
//         	required: true
//         },
//	},
//	messages: {
//		"Hotel.Bank.BankName":
//            {
//            	required: "Bank Name is Required"
//            },
//		"Hotel.Bank.BranchName":
//           {
//           	required: "Branch Name is required",
//           },
//		"Hotel.Bank.AccountNo":
//          {
//          	required: "Account No is required",
//          },
//		"Hotel.Bank.IFSCCode":
//              {
//              	required: "IFSC Code is required"
//              },
//		"Hotel.Bank.MICRCode":
//           {
//           	required: "MICR Code is required"
//           }
//	}
//});

//$("#frmContactPerson").validate({
//	rules: {
//		"Hotel.ContactPerson.ContactPersonName":
//         {
//         	required: true,
//         },
//		"Hotel.ContactPerson.Designation":
//         {
//         	required: true
//         },

//		"Hotel.ContactPerson.MobileNo":
//         {
//         	required: true,
//         },
//		"Hotel.ContactPerson.EmailId":
//         {
//         	required: true
//         },
//	},
//	messages: {
//		"Hotel.ContactPerson.ContactPersonName":
//         {
//         	required: "Contact Person name is required",
//         },
//		"Hotel.ContactPerson.Designation":
//         {
//         	required: "Designation is required"
//         },
//		"Hotel.ContactPerson.MobileNo":
//         {
//         	required: "Mobile No is required",
//         },
//		"Hotel.ContactPerson.EmailId":
//         {
//         	required: true
//         },
//	}
//});



//jQuery.validator.addMethod("HotelType", function (value, element)
//{
//	var result = true;

//	if ($("#drphotelType").val() == "0")
//	{
//		result = false;
//	}

//	return result;
//}, "Hotel Type is Required.");

//jQuery.validator.addMethod("StarCategory", function (value, element)
//{
//	var result = true;

//	if ($("#drpstarCategory").val() == "0")
//	{
//		result = false;
//	}

//	return result;
//}, "Star Category is Required.");

//jQuery.validator.addMethod("City", function (value, element)
//{
//	var result = true;

//	if ($("#drpCity").val() == "0")
//	{
//		result = false;
//	}

//	return result;
//}, "City Name is Required.");