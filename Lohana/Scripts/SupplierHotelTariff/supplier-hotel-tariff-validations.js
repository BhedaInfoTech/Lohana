$(document).ready(function () {

	$("#frmBasicDetail").validate({

		rules: {

			"SupplierHotelTariff.SupplierId":
            {
            	required: true
            },
			"SupplierHotelTariff.PackageName":
             {
             	required: true
             },
		},
		messages: {

			"SupplierHotelTariff.SupplierId":
                {
                	required: "Supplier name is required.",
                },
			"SupplierHotelTariff.PackageName":
                {
                	required: "Package name is required.",
                },
		}

	});

});

    


