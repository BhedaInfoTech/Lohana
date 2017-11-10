
// Builds the HTML Table out of myList.

function buildHtmlTable(myList, selector)
{
	$(selector).html("");

	addAllColumnHeaders(myList.headerNames, selector);

	var columns = myList.dataList;

	if (myList.data.length > 0)
	{
		for (var i = 0; i < myList.data.length; i++)
		{
			var row$ = $('<tr/>');
			var radio$ = $('<input type="radio" />').attr({
				name: 'c1',
			});

			var hiddenData = myList.hiddenFields;

			for (var j = 0; j < hiddenData.length; j++)
			{
				var hiddenValue = myList.data[i][hiddenData[j]];

				radio$.attr("data-" + hiddenData[j], hiddenValue);
			}

			row$.append($('<td/>').append(radio$));
			for (var colIndex = 0; colIndex < columns.length; colIndex++)
			{
				var cellValue = myList.data[i][columns[colIndex]];
				if (cellValue == null) cellValue = "";

				row$.append($('<td/>').html(cellValue));
			}
			$(selector).append(row$);
		}
	}
	else
	{
		var row$ = $('<tr/>');
		row$.append($('<td/>').attr("span", columns.length).append("No record found..."));


		$(selector).append(row$);
	}
}

// Adds a header row to the table and returns the set of columns.
// Need to do union of keys from all records as some records may not contain
// all records.

function addAllColumnHeaders(headerNames, selector)
{
	var headerTh$ = $('<thead/>').addClass("thead-inverse");
	var headerTr$ = $('<tr/>');

	headerTr$.append($('<th/>'));

	for (var i = 0; i < headerNames.length; i++)
	{
		headerTr$.append($('<th/>').html(headerNames[i]));
	}

	headerTh$.append(headerTr$);

	$(selector).append(headerTh$);
}

function ToJavaScriptDate(value) {
    if (value != "null" && value != null && value != "") {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        var dtDate = dt.getDate();
        if (dtDate.toString().length == 1) {
            dtDate = "0" + dtDate;
        }

        var dtMonth = dt.getMonth() + 1;
        if (dtMonth.toString().length == 1) {
            dtMonth = "0" + dtMonth;
        }

        // return (dt.getMonth() + 1) + "/" + dtDate + "/" + dt.getFullYear();
        //return dtMonth + "/" + dtDate + "/" + dt.getFullYear();
        return dtDate + "/" + dtMonth + "/" + dt.getFullYear();
    }
    else {
        return "";
    }
}

function SetActive(selector, value)
{


	if (value.toLocaleLowerCase() == "true" || value == 1)
	{

		if ($(selector).val() == 0 || $(selector).val().toLocaleLowerCase() == "false")
		{
			$(selector).trigger('click');
		}
	}
	else
	{
		
		if ($(selector).val() == 1 || $(selector).val().toLocaleLowerCase() == "true" || $(selector).val() == "")
		{
			

			$(selector).trigger('click');
		}
	}
}


function buildHtmlViewTable(myList, selector) {
    $(selector).html("");

    addViewColumnHeaders(myList.headerNames, selector);

    var columns = myList.dataList;

    if (myList.data.length > 0) {
        for (var i = 0; i < myList.data.length; i++) {
            var row$ = $('<tr/>');
            
            for (var colIndex = 0; colIndex < columns.length; colIndex++) {
                var cellValue = myList.data[i][columns[colIndex]];
                if (cellValue == null) cellValue = "";

                row$.append($('<td/>').html(cellValue));
            }
            $(selector).append(row$);
        }
    }
    else {
        var row$ = $('<tr/>');
        row$.append($('<td/>').attr("span", columns.length).append("No record found..."));


        $(selector).append(row$);
    }
}

function addViewColumnHeaders(headerNames, selector) {
    var headerTh$ = $('<thead/>').addClass("thead-inverse");
    var headerTr$ = $('<tr/>');


    for (var i = 0; i < headerNames.length; i++) {
        headerTr$.append($('<th/>').html(headerNames[i]));
    }

    headerTh$.append(headerTr$);

    $(selector).append(headerTh$);
}


// HotelTariff Tax Updation for checkbox

function buildHtmlchkboxTable(myList, selector) {

    $(selector).html("");

    addAllColumnHeaders(myList.headerNames, selector);

    var columns = myList.dataList;

    if (myList.data.length > 0) {
        for (var i = 0; i < myList.data.length; i++) {
            var row$ = $('<tr/>');
            var radio$ = $('<input type="checkbox" />').attr({
                name: 'c1',
                //id: 'checkbox_' + HotelTariffPriceDetailsId,
                ////checked;""
                //multiPageSelection: true
            });
            var btn$ = $('<button type="button" name="ViewTax" id="btnViewTaxCharges" >View Tax Charges</button>').attr({
                name: 'ViewTax',
            });
            var hiddenData = myList.hiddenFields;

            for (var j = 0; j < hiddenData.length; j++) {
                var hiddenValue = myList.data[i][hiddenData[j]];

                radio$.attr("data-" + hiddenData[j], hiddenValue);

                btn$.attr("data-" + hiddenData[j], hiddenValue);
            }

            row$.append($('<td/>').append(radio$));

          
            for (var colIndex = 0; colIndex < columns.length; colIndex++) {
                var cellValue = myList.data[i][columns[colIndex]];
                if (cellValue == null) cellValue = "";

                row$.append($('<td/>').html(cellValue));
            }

            row$.append($('<td/>').append(btn$));

            $(selector).append(row$);

        }
    }
    else {
        var row$ = $('<tr/>');
        row$.append($('<td/>').attr("span", columns.length).append("No record found..."));

        $(selector).append(row$);
    }
}


////////////////// Start : Auto Complete methods /////////////
function SetAutocomplete(controlName,idFieldName, textFieldName, tableName, dependentControlName, dependentFieldName,extraFields)
{
	
	$("[name='" + controlName + "']").attr("data-idFieldName", idFieldName);

	$("[name='" + controlName + "']").attr("data-textFieldName", textFieldName);

	$("[name='" + controlName + "']").attr("data-tableName", tableName);

	$("[name='" + controlName + "']").attr("data-extraFields", extraFields);

	$("[name='"+controlName+"']").select2({
		ajax: {
			url: '/AutoComplete/GetTableData',
			dataType: 'json',
			data: function (params)
			{
				return {
					q: params.term, // search term
					page: params.page || 1,
					pageLimit: 10,
					idFieldName: idFieldName,
					textFieldName: textFieldName,
					tableName: tableName,
					dependentFieldName: dependentFieldName,
					dependentFieldValue: GetAllDependentFieldValues(dependentControlName),
					extraFields: extraFields
				};
			},
			processResults: function (data)
			{
				//$("[name='" + controlName + "']").html("");
				//params.page = data.page || 1;
				//alert(params.page);
				// making items selectable

				

				//var modifiedData = $.map(JSON.parse(data.data), function (obj)
				//{
				//	obj.id: obj.id,
				//	obj.text : obj.text,
				//		data = obj.data;
					
				//});
				//alert(modifiedData.data);

				if (data.data.length > 0)
				{
					return {
						results: JSON.parse(data.data),
						pagination: {
							//more: (params.page * 10) < data.totalCount
							more: (data.page * 10) < data.totalCount
						}
					};
				}
				else
				{
					return "";
				}
			},
			cache: false

		},
		//minimumInputLength: 1,
		escapeMarkup: function (markup) { return markup; }
	});
}

function GetAutocomplete(controlName, idFieldName, textFieldName, tableName, extraFields)
{

	var id = $("[name='" + controlName + "']").attr("data-value");

	if(id != null && id != undefined && id != "")
	{
		$.ajax({
			url: "/AutoComplete/GetTableDataById",
			data: {
				id: id, idFieldName: idFieldName, textFieldName: textFieldName, tableName: tableName,extraFields: extraFields
			},
			method: 'GET',
			async: false,
			success: function (data)
			{
				SetAutocompleteExistingData(JSON.parse(data.data), controlName,extraFields);
			}
		});
	}
}

function GetAutocompleteById(controlName)
{
	var id = $("[name='" + controlName + "']").attr("data-value");

	var idFieldName = $("[name='" + controlName + "']").attr("data-idFieldName");

	var textFieldName = $("[name='" + controlName + "']").attr("data-textFieldName");

	var tableName = $("[name='" + controlName + "']").attr("data-tableName");

	var extraFields = $("[name='" + controlName + "']").attr("data-extraFields");

	if (id != null && id != undefined && id != "")
	{
		$.ajax({
			url: "/AutoComplete/GetTableDataById",
			data: { id: id, idFieldName: idFieldName, textFieldName: textFieldName, tableName: tableName, extraFields: extraFields },
			method: 'GET',
			async: false,
			success: function (data)
			{			
				SetAutocompleteExistingData(JSON.parse(data.data), controlName,extraFields);
			}
		});
	}
}

function SetAutocompleteExistingData(data, controlName,extraFields)
{
	var html = "";

	var extras = extraFields.split(',');

	for (var i = 0; i < data.length; i++)
	{
		html += "<option selected='selected' value='" + data[i].id + "'  ";
		
		if (extraFields != "" && extraFields != null)
		{
			for (var j = 0; j < extras.length ; j++)
			{
				html += " data-" + extras[j] + " = '" + eval("data[" + i + "]." + extras[j]) + "' ";
			}
		}

		html += ">" + data[i].text + "</option>";
	}

	$("[name='" + controlName + "']").html(html);

	//var data = $("[name='" + controlName + "']").select2('data');

	//data.push(data[0]);
	//$("[name='" + controlName + "']").val(data[0].id);
	////$("[name='" + controlName + "']").select2("data", data, true);

	//$("[name='" + controlName + "']").select2({
	//	data: data
	//})


	$("[name='" + controlName + "']").trigger("change");
}

function GetAllDependentFieldValues(dependentControlName)
{
	var dependentFieldValue = "";

	if (dependentControlName != null && dependentControlName != "")
	{
		var dependentControlNames = [];

		dependentControlNames = dependentControlName.split(',');

		for (var i = 0; i < dependentControlNames.length ; i++)
		{
			dependentFieldValue += $("[name='" + dependentControlNames[i] + "']").val() + ",";
		}

		dependentFieldValue = dependentFieldValue.substring(0, dependentFieldValue.length - 1);
	}

	return dependentFieldValue;
}

function GetAutocompleteScript(pageName)
{

    debugger;

	$.getScript("/AutoComplete/GetScriptByPageName?pageName=" + pageName)
		.done(function (script, textStatus)
		{ /*DyanmicJs();*/
			console.log("load-junk-js succeeded." + script);

		})
		.fail(function (jqxhr, settings, exception)
		{
			console.log("load-junk-js failed" + exception + jqxhr);
		});
}

function GetAutocompleteExtraParamValue(extraName, control)
{
	var extraValue = "";

	if ($(control).find("option[selected='selected']").attr("data-" + extraName) != undefined)
	{
		extraValue = $(control).find("option[selected='selected']").attr("data-" + extraName);
	}
	else
	{
		var obj = $(control).select2("data");

		extraValue = eval("obj[0]." + extraName);
	}

	return extraValue;
}

////////////////// End : Auto Complete methods /////////////


////////////////// Start : popup methods /////////////
function LoadParentModal(url, param, callback, title, icon)
{
	$("#modalParent").find(".modal-body").load(url, param, function ()
	{
		$("#modalParent").find(".modal-title").html("<span style='vertical-align: middle;' class='s-icon'><i class='" + icon + "'></i></span> &nbsp; " + title);
		$("#modalParent").modal("show");
		 
		if (callback != null)
		{
			callback();
		}
	});
}

function LoadChildModal(url, param, callback, title, icon)
{
	$("#modalChild").find(".modal-body").load(url, param, function ()
	{
		$("#modalChild").find(".modal-title").html("<span style='vertical-align: middle;' class='s-icon'><i class='" + icon + "'></i></span> &nbsp; " + title);
		$("#modalChild").modal("show");

		if (callback != null)
		{
			callback();
		}
	});
}

function LoadModal(url, param, callback, title, icon)
{
	if ($("#modalParent").hasClass("in"))
	{
		modalObj = $("#modalChild");
	}
	else
	{
		modalObj = $("#modalParent");
	}

	$(modalObj).find(".modal-body").load(url, param, function ()
	{
		$(modalObj).find(".modal-title").html("<span style='vertical-align: middle;' class='s-icon'><i class='" + icon + "'></i></span> &nbsp; " + title);
		$(modalObj).modal("show");

		if (callback != null)
		{
			callback();
		}
	});
}

function DisplayConformationPopup(message,icon,title,yesCallback,modalCallback)
{
	var htmlTitle = "<span style='vertical-align: middle;' class='s-icon'><i class='" + icon + "'></i></span>" + title;

	var modalObj = "";

	if ($("#modalParent").hasClass("in"))
	{
		modalObj = $("#modalChild");
	}
	else
	{
		modalObj = $("#modalParent");
	}

	$(modalObj).find(".modal-title").html(htmlTitle);

	$(modalObj).find(".modal-body").load("/Common/GetConformationPopup", { message: message },
		function ()
		{
			$(modalObj).modal("show");

			if (modalCallback != null && modalCallback != "" && modalCallback != undefined)
			{
				modalCallback();
			}

			$(modalObj).find("#btnConformYes").click(function ()
			{
				if (yesCallback != null && yesCallback != "" && yesCallback != undefined)
				{
					yesCallback();
				}

				$(modalObj).find("#btnConformYes").unbind("click");

				ResetModal(modalObj);
			});
			
		});
}

function ResetModal(modalObj)
{
	$(modalObj).modal("hide");

	$(modalObj).find(".modal-title").html("");

	$(modalObj).find(".modal-body").html("");
}

////////////////// End : popup methods /////////////


function ToJavaScriptDateYear(value)
{

    debugger

	if (value != "null" && value != null && value != "")
	{
		var pattern = /Date\(([^)]+)\)/;
		var results = pattern.exec(value);
		var dt = new Date(parseFloat(results[1]));
		var dtDate = dt.getDate();
		if (dtDate.toString().length == 1)
		{
			dtDate = "0" + dtDate;
		}

		var dtMonth = dt.getMonth() + 1;
		if (dtMonth.toString().length == 1)
		{
			dtMonth = "0" + dtMonth;
		}

		// return (dt.getMonth() + 1) + "/" + dtDate + "/" + dt.getFullYear();
		//return dtMonth + "/" + dtDate + "/" + dt.getFullYear();
		return dt.getFullYear() + "-" + dtMonth + "-" + dtDate;
	}
	else
	{
		return "";
	}
}