function GetPackageTariffCustomerCategory() {

    var htViewModel =
		{
		    
		}

    PostAjaxJson("/HotelTariff/GetCustomerCategory", htViewModel, BindHotelTariffCustomerCategory);
}

function BindHotelTariffCustomerCategory(data) {

    var list = JSON.parse(data);

    var myTable = $("#tblHotelTariffCustomerCategory tbody");

    myTable.html("");

    var tblHtml = '';

    if (list.HotelTariffCustomerCategories.length > 0) {
        for (var i = 0; i < list.HotelTariffCustomerCategories.length; i++) {
            tblHtml += "<tr class='item-data-row'>";
                       
            tblHtml += "<td>";
            tblHtml += "<label >" + list.HotelTariffCustomerCategories[i].CustomerCategoryName + "</label>";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryname' name='SupplierCustomerCategories[" + i + "].CustomerCategoryName' value='" + list.HotelTariffCustomerCategories[i].CustomerCategoryName + "' id=hdnCustomerCategoryName_" + i + ">";
            tblHtml += "<input type='hidden' class='form-control input-sm customercategoryid' name='SupplierCustomerCategories[" + i + "].CustomerCategoryId' value='" + list.HotelTariffCustomerCategories[i].CustomerCategoryId + "' id=hdnCustomerCategoryId_" + i + ">";
            tblHtml += "</td>";

            tblHtml += "<td>";
            tblHtml += "<input type='text' class='form-control input-sm' name='HotelTariffCustomerCategories[" + i + "].GlobalMargin' value='" + list.HotelTariffCustomerCategories[i].GlobalMargin + "' id=txtGlobalMargin_" + i + ">";
            tblHtml += "</td>";

            tblHtml += "</tr>";
        }
    }

    var newRow = $(tblHtml);

    myTable.append(newRow);

}

function SavePackageTariffDuration() {

    $("#frmPackageTriffduration").blur();

    var pViewModel = packageTariffViewModel();

    var url = "";

    PostAjaxJson("/SupplierHotelTariff/IsOverrideDate", pViewModel, function (data) {

        AfterIsOverrideDate(data, pViewModel);

    });

}

function packageTariffViewModel() {

    var days = [];
    var customerCategoriesList = [];

    $(".item-data-row").each(function (i) {


        var customerCategories = {

            CustomerCategoryId: $("#hdnCustomerCategoryId_" + i).val(),

            Margin: $("#txtGlobalMargin_" + i).val()

        }

        customerCategoriesList.push(customerCategories);
    });


    //alert(JSON.stringify(customerCategoriesList));

    $('input[name="Packageduration.OperationalDays"]:checked').each(function (i) {
        days.push($(this).val())
    });

    var DaysValue = days.join();

    var pViewModel = {

        PackageCustomerCategory: customerCategoriesList,

        Packageduration: {

            price: $("#txtprice").val(),

            PackageId: $("[name='Package.PackageId']").val(),

            FormDate: $("[name='Packageduration.FromDate']").val(),

            EndDate: $("[name='Packageduration.ToDate']").val(),

            OperationalDays: DaysValue,

            
        }

    }
   // alert(JSON.stringify(pViewModel));
    return pViewModel;

}

function AfterIsOverrideDate(data, pViewModel) {


    if (data == true) {
        DisplayConformationPopup("Some date's price may get override, Do you want to procced ?", "ti-view-list-alt", "Conformation", function () {
            PostAjaxJson("/Package/SavePackageNetRateAndCustomerCategories", pViewModel, AfterDurationSave);

        }, null);
    }
    else {
        PostAjaxJson("/Package/SavePackageNetRateAndCustomerCategories", pViewModel, AfterDurationSave);
    }
}

function AfterDurationSave(data) {

    FriendlyMessagePopup(data);

    //ResetDuration();

    GetHotelTariffDuration($("#dvcalendar1"));

    GetHotelTariffDuration($("#dvcalendar"));

    GetPackageTariffCustomerCategory();

}



function GetPackageTariffDuration(obj) {
    GetAjax("/Package/GetPackageDurationPrice", { PackageId: $("[name='Package.PackageId']").val() }, function (data) { BindSupplierHotelTariffDuration(data, obj) });
}

function BindSupplierHotelTariffDuration(data, obj) {
   // alert(obj.prop("id"));
    var schedules = [];

    var colors = {};
    //alert(data.length);
    
    
    for (var i = 0; i < data.length; i++) {
    
        var date = ToJavaScriptDateYear(data[i].TariffDate);
    
        schedules.push({ name: data[i].price, date: date });
    }
   // alert(JSON.stringify(schedules)); 

    //alert(data.length);
    //for (var i = 0; i < data.length; i++) {
    //    colors[data[i].price] = data[i].Color;
    //}

    //alert(JSON.stringify(colors));
    //alert(colors);
    var scheduleOptions1 = { color: 'black' };

    $(obj).pignoseCalendar({
        scheduleOptions: scheduleOptions1,
        schedules: schedules,
        select: function (date, context) {
            //for (var idx in context.storage.schedules)
            //{
            //	var schedule = context.storage.schedules[idx];

            //	alert(schedule.name);
            //}

            $("#hdnPrice").val(context.storage.schedules[0].name);

           // $("[name='SupplierHotelTariffDurations.TariffDate']").val(context.storage.schedules[0].date);

            //alert(date);
            //alert(context.storage.schedules.name);
            //alert('events for this date', context.storage.schedules.name);
        }
    });
}
