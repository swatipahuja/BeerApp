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
	public class CategoryDAL : ICategoryDAL
	{
		#region Private Members

		private ILogger _logger = LoggerFactory.CreateLogger(typeof(CategoryDAL));

		/// <summary>
		/// Gets category filter data from BrweryDB in asynchronous manner
		/// </summary>
		/// <returns></returns>
		private async Task<CategoryResponseMsg> GetCategoryFilterDataAsync()
		{
			CategoryResponseMsg categoryData = null;

			string[] queryParameters = { "categories" };
			NameValueCollection extraParams = new NameValueCollection();
			try
			{
				HttpClient client = HttpClientProvider.Client;
				Uri requestUri = HttpClientProvider.CreateRequest(queryParameters);
				HttpResponseMessage response = await client.GetAsync(requestUri.AbsoluteUri);

				if (response.IsSuccessStatusCode)
				{
					categoryData = await response.Content.ReadAsAsync<CategoryResponseMsg>();
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
			return categoryData;
		}

		#endregion

		#region Public Members
		public void Dispose()
		{
			_logger = null;
		}

		/// <summary>
		/// Gets search result and filters for the beers
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns>Response object with data required by the view</returns>
		public CategoryResponseMsg GetCategoryFilterData()
		{
			CategoryResponseMsg result = new CategoryResponseMsg();
			result = GetCategoryFilterDataAsync().GetAwaiter().GetResult();
			return result;
		}
		#endregion

	}
}
