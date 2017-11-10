using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaHelper.Logging
{
	[Serializable]
	public class DBLogInfo
	{
		//public int UserId { get; set; }

		//public string Exception { get; set; }

		public string IPAddress
		{
			get;
			set;
		}

		//public DateTime CreatedOn { get; set; }

		public string Client_Name
		{
			get;
			set;
		} // NAME OF THE CLIENT FOR WHOM PROJECT IS DEVELOPED. THIS CANNOT BE <BLANK>. SHOULD BE A CONSTANT / ENUM.

		public string Project_Name
		{
			get;
			set;
		} // NAME OF THE PROJECT. THIS CANNOT BE <BLANK>. SHOULD BE A CONSTANT / ENUM.

		public string Log_Type
		{
			get;
			set;
		} // APPLICATION, SAP, WINDOWS SERVICE. THIS CANNOT BE <BLANK>. SHOULD BE AN ENUM.

		public string Message_Type
		{
			get;
			set;
		}// DATA, SUCCESS, EXCEPTION. THIS CANNOT BE <BLANK>. SHOULD BE AN ENUM.

		public string Session_Id
		{
			get;
			set;
		} // THIS ID WOULD DENOTE THE FLOW OF THE DEBUGGER FROM VARIOUS METHODS. THIS CANNOT BE <BLANK>. THIS WOULD BE A VARIABLE CREATED IN SESSION START METHOD IN GLOBAL.ASAX FILE. ITS VALUE CAN BE NEW GUID().

		public string Controller_Name
		{
			get;
			set;
		} // THIS CANNOT BE <BLANK>

		public string Method_Name
		{
			get;
			set;
		} // THIS CANNOT BE <BLANK>

		public string Page_Name
		{
			get;
			set;
		} // THIS WOULD DENOTE NAME OF PAGE. EG: <DASHBOARD>, <VENDOR LISTING>, <VENDOR>. THIS CANNOT BE <BLANK>.  SHOULD BE AN ENUM.

		public string Data_Value
		{
			get;
			set;
		} // THIS PROPERTY DENOTES THE DATA INFORMATION WHICH NEEDS TO BE LOGGED IN SYSTEM. THIS CANNOT BE <BLANK>

		public int Request_Id
		{
			get;
			set;
		} // THIS PROPERTY DENOTES THE REQUEST ID. THIS CAN BE <BLANK>. IAM THINKING OF BINDING HTML IN THIS PROPERTY TO MAKE IT LOOK BETTER ON DASHBOARD GRID.

		public string Action
		{
			get;
			set;
		} // CREATE, CHANGE, INTERNET CREATE, INTERNET CHANGE, EXTENSION, DELETE, BLOCK. THIS CAN BE <BLANK>.  SHOULD BE AN ENUM.

		public string Object_Type
		{
			get;
			set;
		} // VENDOR, MATERIAL, CUSTOMER. THIS CAN BE <BLANK>.  SHOULD BE AN ENUM.

		public string Logged_In_User
		{
			get;
			set;
		} // ID OF LOGGED IN USER. THIS CAN BE <BLANK>.

		public DateTime Log_Created_On
		{
			get;
			set;
		} // DATETIME WHEN THE LOG WAS CREATED.

		public string Json_Data
		{
			get;
			set;
		}// ALL DATA RELATED TO REQUEST

		public string Exception_Message
		{
			get;
			set;
		} // EXCEPTION MESSAGE

		public string Exception_StackTrace
		{
			get;
			set;
		}// DETAIL INFORMATION OF WHERE EXCEPTION OCCURED

		public int Logger_Id
		{
			get;
			set;
		}
	}
}
