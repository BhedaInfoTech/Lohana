function FriendlyMessage(data)
{
	if (data.FriendlyMessage != null)
	{
		if (data.FriendlyMessage.length > 0)
		{
		    var message = "";
		    var messageType = "";

		    var dt = new Date();
		    var Id = dt.getHours() + "" + dt.getMinutes() + "" + dt.getSeconds();

			for (var i = 0; i < data.FriendlyMessage.length; i++)
			{
				switch (data.FriendlyMessage[i].Type)
				{
					case 1:
						messageType = "Information";
						break;
					case 2:
						messageType = "Error";
						break;
					case 3:
						messageType = "Success";
						break;
					case 4:
						messageType = "Warning";
						break;
				    case 5:
				        messageType = "AcessDenied";
				        break;
				}

				if (messageType == "Information")
				{
					message += "<div class='alert alert-info alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-info'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
				else if (messageType == "Error")
				{
					message += "<div class='alert alert-danger alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-ban'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
				else if (messageType == "Success")
				{
					message += "<div class='alert alert-success alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-check'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
				else if (messageType == "AcessDenied")
				{
				    message += "<div class='alert alert-danger alert-dismissable' id='" + Id + "'>"
				    message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
				    message += "<h4><i class='icon fa fa-ban'></i> Alert!</h4>";
				    message += "Sorry, you don't have permission to access on this server";
				    message += " </div>";
				}
				else
				{
					message += "<div class='alert alert-warning alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-warning'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
			}

			$('#message').append(message);

			$("html, body").animate({ scrollTop: 0 }, "slow");
		}
	}	
    
    TimeOut(Id);
    
}

function FriendlyMessagePopup(data)
{
	if (data.FriendlyMessage != null)
	{
		if (data.FriendlyMessage.length > 0)
		{
			var message = "";
			var messageType = "";

			var dt = new Date();
			var Id = dt.getHours() + "" + dt.getMinutes() + "" + dt.getSeconds();

			for (var i = 0; i < data.FriendlyMessage.length; i++)
			{
				switch (data.FriendlyMessage[i].Type)
				{
					case 1:
						messageType = "Information";
						break;
					case 2:
						messageType = "Error";
						break;
					case 3:
						messageType = "Success";
						break;
					case 4:
						messageType = "Warning";
						break;
					case 5:
						messageType = "AcessDenied";
						break;
				}

				if (messageType == "Information")
				{
					message += "<div class='alert alert-info alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-info'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
				else if (messageType == "Error")
				{
					message += "<div class='alert alert-danger alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-ban'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
				else if (messageType == "Success")
				{
					message += "<div class='alert alert-success alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-check'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
				else if (messageType == "AcessDenied")
				{
					message += "<div class='alert alert-danger alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-ban'></i> Alert!</h4>";
					message += "Sorry, you don't have permission to access on this server";
					message += " </div>";
				}
				else
				{
					message += "<div class='alert alert-warning alert-dismissable' id='" + Id + "'>"
					message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
					message += "<h4><i class='icon fa fa-warning'></i> Alert!</h4>";
					message += data.FriendlyMessage[i].Text;
					message += " </div>";
				}
			}

			$('#popupmessage').append(message);

			//$("html, body").animate({ scrollTop: 0 }, "slow");
		}
	}

	TimeOut(Id);

}

function TimeOut(Id) {
    setTimeout(
      function () {
      	$("#" + Id).fadeOut(2000);
      	$("#" + Id).remove();
      }, 5000);
}