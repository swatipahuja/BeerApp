using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Logger;
using BeerFinder.Shared;
using BeerFinder.Shared.ResponseMsg;
using BeerFinder.Shared.Utilities;

namespace BeerFinder.DAL
{
	public class GlasswareDAL : IGlasswareDAL
	{
		#region Private Members

		private ILogger _logger = LoggerFactory.CreateLogger(typeof(GlasswareDAL));

		/// <summary>
		/// Gets glassware filter data from BrweryDB in asynchronous manner
		/// </summary>
		/// <returns></returns>
		private async Task<GlasswareResponseMsg> GetGlasswareFilterDataAsync()
		{
			GlasswareResponseMsg glasswareData = null;

			string[] queryParameters = { "glassware" };
			NameValueCollection extraParams = new NameValueCollection();
			try
			{
				HttpClient client = HttpClientProvider.Client;
				Uri requestUri = HttpClientProvider.CreateRequest(queryParameters);
				HttpResponseMessage response = await client.GetAsync(requestUri.AbsoluteUri);

				if (response.IsSuccessStatusCode)
				{
					glasswareData = await response.Content.ReadAsAsync<GlasswareResponseMsg>();
				}
				else
				{
					string error = await response.Content.ReadAsStringAsync();
					string errorMessage = $"{(int)response.StatusCode} - {response.ReasonPhrase} : {error}.";
					ApplicationException ex = new ApplicationException();
					_logger.LogException(LogSeverity.Error, errorMessage, ex);
					throw ex;
				}
			}
			catch (Exception ex)
			{
				_logger.LogException(LogSeverity.Error, Constants.LogExceptionMessages.DataAccessException, ex);
				throw;
			}
			return glasswareData;
		}

		#endregion

		#region Public Members
		public void Dispose()
		{
			_logger = null;
		}

		/// <summary>
		/// Gets glassware filter data
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		public GlasswareResponseMsg GetGlasswareFilterData()
		{
			GlasswareResponseMsg result = new GlasswareResponseMsg();
			result = GetGlasswareFilterDataAsync().GetAwaiter().GetResult();
			return result;
		}
		#endregion

	}
}
