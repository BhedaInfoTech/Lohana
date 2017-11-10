$(document).ready(function () {

    $("#frmPackageBasicDetails").validate({

        rules: {

            "Package.PackageCode":
             {
                 required: true,
                 CheckPackageCodeExist: true

             },
            "Package.Category":
             {
                 Category: true
             },
            "Package.PackageType":
           {
               PackageType: true
           },
            "Package.PackageName":
             {
                 required: true,
                 CheckPackageNameExist: true
             },
            "Package.PackageDuration":
            {
                required: true,
            },
            "Package.DepartureCity":
           {
               DepartureCity: true,
           },
            "Package.TourReportingPoint":
             {
                 required: true
             },
            "Package.TourDroppingPoint":
             {
                 required: true
             },
            "Package.PackageCost":
             {
                 required: true,
                 number: true
             },

        },
        messages: {

            "Package.PackageCode":
                {
                    required: "Package code is required."
                },
            "Package.PackageName":
           {
               required: "Package name is required.",

           },
            "Package.PackageDuration":
          {

              required: "Package duration is required."
          },

            "Package.TourReportingPoint":
             {
                 required: "Reporting Point is required."
             },
            "Package.TourDroppingPoint":
                  {
                      required: "Dropping Point is required."
                  },
            "Package.PackageCost":
            {
                required: "Package cost is required.",
                number: "Enter digits only."
            },

        }

    });

    jQuery.validator.addMethod("CheckPackageNameExist", function (value, element) {
        
        return GetAjaxAlreadyExists('/Package/CheckPackageNameExist', { PackageName: value }, $("#txtpackageName"), $("#hdnpackageName"));

    }, "Package name already exist.")

    jQuery.validator.addMethod("CheckPackageCodeExist", function (value, element) {
        
        return GetAjaxAlreadyExists('/Package/CheckPackageCodeExist', { PackageCode: value }, $("#txtpackageCode"), $("#hdnpackageCode"));

    }, "Package code already exist")


    jQuery.validator.addMethod("Category", function (value, element) {

        var result = true;

        if ($("#drppkgcategory").val() == "0") {
            result = false;
        }

        return result;

    }, "Category is required.");

    jQuery.validator.addMethod("PackageType", function (value, element) {

        var result = true;

        if ($("#drppackageType").val() == "0") {
            result = false;
        }

        return result;

    }, "Package type is required.");

    jQuery.validator.addMethod("DepartureCity", function (value, element) {

        var result = true;

        if ($("#drpdepartureCity").val() == "0") {
            result = false;
        }

        return result;

    }, "Departure city is required.");


});





