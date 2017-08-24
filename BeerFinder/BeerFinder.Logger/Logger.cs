using System;
using System.Globalization;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace BeerFinder.Logger
{
	public class Logger: ILogger
	{
		#region Constant Fields

		// constant strings for the custom LogEventInfo properties
		private const string _HttpStatusCode = "HttpStatusCode";

		// constant strings for the rendered layouts
		private const string _NewLineLayout = "${newline}";
		private const string _LongDateLayout = "${longdate}";
		private const string _SeverityLayout = "${level}";
		private const string _MessageLayout = "${message}";
		private const string _ExceptionLayout = "${exception:format=tostring}";
		private const string _SourceLayout = "${logger}";
		private const string _HttpStatusCodeLayout = "${event-context:item=" + _HttpStatusCode + "}";

		#endregion

		#region Properties

		private NLog.Logger logger { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Creates a new logger instance.
		/// </summary>
		/// <param name="loggerClass">The class that hosts the logger instance.</param>        
		public Logger(Type loggerClass)
		{
			if (loggerClass != null)
			{

			}
			SimpleConfigurator.ConfigureForTargetLogging(GetLogTarget(), LogLevel.Trace);
			logger = LogManager.GetLogger(loggerClass.Name);
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Logs the diagnostic message at the specified severity level 
		/// using the specified format parameters. 
		/// </summary>
		/// <param name="severity">The log severity.</param>
		/// <param name="message">The message to be logged, 
		/// that could contain format items.</param>
		/// <param name="args">Arguments to format.</param>
		public void LogMessage(LogSeverity severity,string message, params object[] args)
		{
			Log(severity,  message, null, args);
		}

		/// <summary>
		/// Logs the diagnostic message and exception at the specified severity level. 
		/// </summary>
		/// <param name="severity">The log severity.</param>
		/// <param name="message">The message to be logged.</param>
		/// <param name="exception">The exception to be logged.</param>
		public void LogException(LogSeverity severity, string message, Exception exception)
		{
			Log(severity,  message, exception);
		}

		/// <summary>
		/// Logs the diagnostic message and exception at the specified severity level. 
		/// </summary>
		/// <param name="severity">The log severity.</param>
		/// <param name="message">The message to be logged.</param>
		/// <param name="exception">The exception to be logged.</param>
		/// <param name="requestGuid"></param>
		public void LogException(LogSeverity severity, string message, Exception exception, Guid requestGuid)
		{
			var guid = string.Format("Request Guid: {0}", requestGuid);
			Log(severity, message, exception, new object[] { guid });
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Logs the diagnostic message at the specified severity level 
		/// using the specified format parameters. 
		/// </summary>
		/// <param name="severity">The log severity.</param>
		/// <param name="message">The message to be logged, 
		/// that could contain format items.</param>
		/// <param name="exception">The exception to be logged.</param>
		/// <param name="args">Arguments to format.</param>
		/// <remarks>
		/// All exceptions are suppressed, because this method 
		/// is called during logging from error handling blocks.
		/// </remarks>
		private void Log(LogSeverity severity,string message, Exception exception, params object[] args)
		{
			try
			{
				string httpStatusCode = null;
				// Create the LogEventInfo instance and set the custom event context properties.
				LogEventInfo logEventInfo = new LogEventInfo(ConvertLogSeverityToLogLevel(severity), logger.Name, message);
				logEventInfo.Parameters = args;
				logEventInfo.Exception = exception;
				logEventInfo.Properties[_HttpStatusCode] = httpStatusCode;

				// Log event to the configured targets.
				logger.Log(logEventInfo);
			}
			catch { }
		}

		/// <summary>
		/// Returns a FileTarget instance used to log to a file.
		/// </summary>
		/// <returns></returns>
		private FileTarget GetLogFileTarget()
		{
			CsvLayout csvLayout = new CsvLayout()
			{
				WithHeader = true,
				Quoting = CsvQuotingMode.All,
				QuoteChar = "\"",
				Delimiter = CsvColumnDelimiterMode.Comma
			};
			csvLayout.Columns.Add(new CsvColumn("Log date", _LongDateLayout));
			csvLayout.Columns.Add(new CsvColumn("Message", _MessageLayout));
			csvLayout.Columns.Add(new CsvColumn("Severity", _SeverityLayout));
			csvLayout.Columns.Add(new CsvColumn("Source", _SourceLayout));
			csvLayout.Columns.Add(new CsvColumn("Http status code", _HttpStatusCodeLayout));
			csvLayout.Columns.Add(new CsvColumn("Stack trace", _ExceptionLayout));

			FileTarget fileTarget = new FileTarget()
			{
				Name = "LogFileTarget",
				FileName = "${basedir}/Logs/${logger} ${shortdate}.txt",
				ArchiveFileName = "${basedir}/Logs/Archives/${logger}Log.{#####}.txt",
				ArchiveAboveSize = 1000 * 1024, // archive files greater than 1 MB
				ArchiveNumbering = ArchiveNumberingMode.Sequence,
				CreateDirs = true,
				ConcurrentWrites = true, // this speeds up things when no other processes are writing to the file
				Encoding = Encoding.UTF8,
				KeepFileOpen = false,
				Layout = csvLayout
			};

			return fileTarget;
		}

		/// <summary>
		/// Returns the target instance used for logging.
		/// </summary>
		/// <returns></returns>
		private AsyncTargetWrapper GetLogTarget()
		{
			FallbackGroupTarget fallbackGroupTarget = new FallbackGroupTarget()
			{
				Name = "FallbackGroupTarget",
				ReturnToFirstOnSuccess = true
			};
			fallbackGroupTarget.Targets.Add(GetLogFileTarget());

			AsyncTargetWrapper asyncTargetWrapper = new AsyncTargetWrapper()
			{
				Name = "AsyncTargetWrapper",
				BatchSize = 1,
				QueueLimit = 5000,
				OverflowAction = AsyncTargetWrapperOverflowAction.Grow,
				WrappedTarget = fallbackGroupTarget
			};

			return asyncTargetWrapper;
		}

		/// <summary>
		/// Converts a value from WorkflowLogSeverity enum to a value from LogLevel enum.
		/// </summary>
		/// <param name="severity">The WorkflowLogSeverity value to be converted.</param>
		/// <returns></returns>
		private LogLevel ConvertLogSeverityToLogLevel(LogSeverity severity)
		{
			LogLevel logLevel = LogLevel.Fatal;
			switch (severity)
			{
				case LogSeverity.Fatal:
					{
						logLevel = LogLevel.Fatal;
						break;
					}
				case LogSeverity.Error:
					{
						logLevel = LogLevel.Error;
						break;
					}
				case LogSeverity.Warn:
					{
						logLevel = LogLevel.Warn;
						break;
					}
				case LogSeverity.Info:
					{
						logLevel = LogLevel.Info;
						break;
					}
				case LogSeverity.Debug:
					{
						logLevel = LogLevel.Debug;
						break;
					}
				case LogSeverity.Trace:
					{
						logLevel = LogLevel.Trace;
						break;
					}
				default:
					{
						logLevel = LogLevel.Fatal;
						break;
					}
			}
			return logLevel;
		}

		#endregion
	}
}
