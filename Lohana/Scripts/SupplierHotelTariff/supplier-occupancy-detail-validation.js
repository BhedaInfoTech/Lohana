$(document).ready(function () {

    $("#frmOccupancyDetail").validate({

        rules: {

            "SupplierOccupancyDetail.OccupancyId":
            {
                required: true,
            },
            
        },

        messages: {

            "SupplierOccupancyDetail.OccupancyId":
                {
                    required: "Occupancy is required."
                },

        }

    });
});

