using System;

namespace BeerFinder.Logger
{
	public interface ILogger
	{
		/// <summary>
		/// Logs the diagnostic message at the specified severity level 
		/// using the specified format parameters. 
		/// </summary>
		/// <param name="severity">The log severity.</param>
		/// <param name="message">The message to be logged, 
		/// that could contain format items.</param>
		/// <param name="args">Arguments to format.</param>
		void LogMessage(LogSeverity severity, string message, params object[] args);

		/// <summary>
		/// Logs the diagnostic message and exception at the specified severity level. 
		/// </summary>
		/// <param name="severity">The log severity.</param>
		/// client key, client name, client application, http status code).</param>
		/// <param name="message">The message to be logged.</param>
		/// <param name="exception">The exception to be logged.</param>
		void LogException(LogSeverity severity, string message, Exception exception);

	}
}
