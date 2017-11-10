function SavePackageOtherDetails() {

    $("#frmPackageOtherDetails").blur();

    var pViewModel = {

        Package: {

            PackageId: $("#hdnpackageOtherDetailsId").val(),

            Inclusions: $("[name='Package.inclusions']").val(),

            Exclusions: $("[name='Package.exclusions']").val(),

            PaymentTems: $("[name='Package.paymentModeDescription']").val(),

            TourRequirements: $("[name='Package.tourRequirements']").val(),

            ThingsToCarryAlong: $("[name='Package.thingsToCarryAlong']").val(),

            Weather: $("[name='Package.weather']").val(),

            Shopping: $("[name='Package.shopping']").val(),

            DosAndDonts: $("[name='Package.dosAndDonts']").val(),

            TermsCondition: $("[name='Package.termsAndCondition']").val(),

            CancellationDetails: $("[name='Package.cancellation']").val(),

            RouteChanges: $("[name='Package.routeChangesPostponementDelay']").val(),

        }
    }


    var url = "";

    url = "/Package/UpdatePackageOtherDetails"

    PostAjaxWithProcessJson(url, pViewModel, AfterOtherDetailsSave, $("body"));

}

function AfterOtherDetailsSave(data) {
    debugger;

    FriendlyMessage(data);

    $("#hdnpackageOtherDetailsId").val(data.Package.PackageId)   

}

function ResetPackageOtherDetails() {

     $("#hdnpackageOtherDetailsId").val(),

     $("[name='Package.inclusions']").val(),

     $("[name='Package.exclusions']").val(),

     $("[name='Package.paymentModeDescription']").val(),

     $("[name='Package.tourRequirements']").val(),

     $("[name='Package.thingsToCarryAlong']").val(),

     $("[name='Package.weather']").val(),

     $("[name='Package.shopping']").val(),

     $("[name='Package.dosAndDonts']").val(),

     $("[name='Package.termsAndCondition']").val(),

     $("[name='Package.cancellation']").val(),

     $("[name='Package.routeChangesPostponementDelay']").val()

}