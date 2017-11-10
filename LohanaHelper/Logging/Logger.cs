using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaHelper.Logging
{
	public static class Logger
	{
		//This property should be used to write values to file (.txt).
		private static ILog _fileLogger;

		//This property should be used to push information to MSMQ server.
		private static ILog _msmqLogger;

		static Logger()
		{
			// This property reads information from Log4Net.config setting for FileLogger.
			_fileLogger = LogManager.GetLogger("FileLogger");

			// This property reads information from Log4Net.config setting for MSMQLogger.
			_msmqLogger = LogManager.GetLogger("MSMQLogger");

			// Important.
			log4net.Config.XmlConfigurator.Configure();
		}

		#region Methods to write log to a File (.txt)

		public static void Info(object message)
		{
			if(_fileLogger.IsInfoEnabled)
				_fileLogger.Info(message);
		}

		public static void Warn(object message)
		{
			if(_fileLogger.IsWarnEnabled)
				_fileLogger.Warn(message);
		}

		public static void Debug(object message)
		{
			if(_fileLogger.IsDebugEnabled)
				_fileLogger.Debug(message);
		}

		public static void Error(object message)
		{
			if(_fileLogger.IsErrorEnabled)
				_fileLogger.Error(message);
		}

		public static void Fatal(object message)
		{
			if(_fileLogger.IsFatalEnabled)
				_fileLogger.Fatal(message);
		}

		#endregion

		#region Methods to push log to MSMQ server.

		public static void Info(DBLogInfo message)
		{
			if(_msmqLogger.IsInfoEnabled)
				_msmqLogger.Info(message);
		}

		public static void Warn(DBLogInfo message)
		{
			if(_msmqLogger.IsWarnEnabled)
				_msmqLogger.Warn(message);
		}

		public static void Debug(DBLogInfo message)
		{
			if(_msmqLogger.IsDebugEnabled)
				_msmqLogger.Debug(message);
		}

		public static void Error(DBLogInfo message)
		{
			if(_msmqLogger.IsErrorEnabled)
				_msmqLogger.Error(message);
		}

		public static void Fatal(DBLogInfo message)
		{
			if(_msmqLogger.IsFatalEnabled)
				_msmqLogger.Fatal(message);
		}

		#endregion

		#region Set Dblog info

		public static void Set_DBLog(Exception ex, string client_Name, string project_Name, string action, string object_Type, string page_Name, string controller_Name, string message_Type, string method_Name, string data_Value, string log_Type, int request_Id, string iPAddress, string logged_In_User, string session_Id, string json_Data)
		{
			DBLogInfo log = new DBLogInfo();

			log.Client_Name = client_Name;

			log.Project_Name = project_Name;

			log.Controller_Name = controller_Name;

			log.IPAddress = iPAddress;//HttpContext.Current.Request.UserHostAddress;

			log.Log_Created_On = DateTime.Now;

			log.Message_Type = message_Type;

			log.Log_Type = log_Type;

			log.Data_Value = data_Value;

			log.Request_Id = request_Id;

			log.Action = action;

			log.Object_Type = object_Type;

			log.Logged_In_User = logged_In_User;//((SessionInfo)HttpContext.Current.Session["SessionInfo"]).User_Id;

			log.Session_Id = session_Id;//Convert.ToString(HttpContext.Current.Session["Session_Id"]);

			if(ex != null)
			{
				log.Exception_Message = ex.Message;

				log.Exception_StackTrace = ex.StackTrace;
			}

			log.Method_Name = method_Name;

			log.Page_Name = page_Name;

			log.Json_Data = json_Data;

			if(message_Type == "Error")
			{
				Logger.Error(log);
			}
			else if(message_Type == "Success")
			{
				Logger.Debug(log);
			}
			else
			{
				Logger.Info(log);
			}
		}

		#endregion
	}
}
