
$(function ()
{
	$(document).on("change", ".js-switch", function ()
	{
		if ($(this).prop("checked"))
		{
			$(this).val(true);
		}
		else
		{
			$(this).val(false);
		}
	});

});