using System;

namespace BeerFinder.Logger
{
	public class LoggerFactory
	{
		/// <summary>
		/// Creates a new logger instance.
		/// </summary>
		/// <param name="loggerClass">The class that hosts the logger instance.</param>
		/// <returns>An ILogger instance.</returns>
		public static Logger CreateLogger(Type loggerClass)
		{
			return new Logger(loggerClass);
		}
	}
}
