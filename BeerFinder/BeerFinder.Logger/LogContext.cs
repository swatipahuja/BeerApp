using System.Security.Principal;
using System.Web;

namespace BeerFinder.Logger
{
	public class LogContext
	{
		#region Public Properties

		public string UserLogon { get; set; }
		public string ClientApplication { get; set; }
		public int HttpStatusCode { get; set; }

		#endregion

		#region Public Static Methods

		/// <summary>
		/// Returns the LogContext instance for the current context. 
		/// This method reads context info, like client application, 
		/// http status code from HttpContext.Current (if available).
		/// </summary>
		/// <remarks>
		/// All exceptions are suppressed, because this method 
		/// is called during logging from error handling blocks.
		/// </remarks>
		public static LogContext GetCurrent()
		{
			LogContext logContext = null;
			try
			{
				logContext = new LogContext();
				HttpContext httpContext = HttpContext.Current;
				if (httpContext != null)
				{
					HttpRequest httpRequest = httpContext.Request;
					if (httpRequest != null)
					{
						HttpBrowserCapabilities httpBrowser = httpRequest.Browser;
						if (httpBrowser != null)
						{
							logContext.ClientApplication = httpBrowser.Browser + " " + httpBrowser.Version;
						}
					}
					if (httpContext.Response != null)
					{
						logContext.HttpStatusCode = httpContext.Response.StatusCode;
					}
					if (httpContext.User != null && httpContext.User.Identity != null)
					{
						logContext.UserLogon = httpContext.User.Identity.Name;
					}
				}

				if (string.IsNullOrEmpty(logContext.UserLogon))
				{
					logContext.UserLogon = WindowsIdentity.GetCurrent().Name;
				}
			}
			catch { }

			return logContext;
		}
		#endregion
	}
}
