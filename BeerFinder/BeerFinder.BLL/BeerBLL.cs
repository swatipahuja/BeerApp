using System;
using System.Collections.Generic;
using System.Linq;
using BeerFinder.BLL.Interfaces;
using BeerFinder.DAL;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Logger;
using BeerFinder.Shared;
using BeerFinder.Shared.DTO;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL
{
	public class BeerBLL : IBeerBLL
	{
		#region Private Members
		private readonly int _pageSize = 50;
		private ILogger _logger = LoggerFactory.CreateLogger(typeof(BeerBLL));

		/// <summary>
		/// Get the filtered data from the response
		/// </summary>
		/// <param name="data">Response object</param>
		/// <param name="requestMsg">Request Message object</param>
		/// <returns>Response object with filetered data</returns>
		private void GetFilteredData(BeerResponseMsg data, BeerRequestMsg requestMsg)
		{
			List<BeerDto> filteredData = new List<BeerDto>();
			if (!string.IsNullOrEmpty(requestMsg.GlasswareId))
			{
				filteredData.AddRange(data.Beers.Where(b => b.GlassWareId != null
				&& b.GlassWareId.Equals(requestMsg.GlasswareId)).ToList());
			}
			if (!string.IsNullOrEmpty(requestMsg.CategoryId))
			{
				filteredData.AddRange(data.Beers.Where(b => b.CategoryId != null
				&& b.CategoryId.Equals(requestMsg.CategoryId)).ToList());
			}
			if (string.IsNullOrEmpty(requestMsg.CategoryId) && string.IsNullOrEmpty(requestMsg.GlasswareId))
			{
				string.IsNullOrEmpty(requestMsg.GlasswareId);
			}
			else
			{
				data.Beers = filteredData.OrderBy(b => b.Name).ToList();
				UpdatePagingInfoForFilteredData(data, requestMsg);
			}
		}
		/// <summary>
		/// Updates paging information for filtered data
		/// </summary>
		/// <param name="data">Response data</param>
		/// <param name="requestMsg">Resquest message</param>
		private void UpdatePagingInfoForFilteredData(BeerResponseMsg data, BeerRequestMsg requestMsg)
		{
			data.CurrentPage = Convert.ToInt32(requestMsg.PageNumber);
			data.TotalResults = data.Beers.Count();
			data.NumberOfPages = (int)Math.Ceiling((double)(data.TotalResults / _pageSize));

		}
		#endregion

		#region Public Members

		public void Dispose()
		{
			_logger = null;
		}

		/// <summary>
		/// Gets search result for the beers
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns>Response object with data required by the view</returns>
		public BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg)
		{
			BeerResponseMsg result = new BeerResponseMsg();
			try
			{
				using (var beerDAL = DALFactory.CreateDAL<IBeerDAL>())
				{
					result = beerDAL.GetBeerData(requestMsg);
				}
				GetFilteredData(result, requestMsg);
			}
			catch (Exception ex)
			{
				_logger.LogException(LogSeverity.Error, Constants.LogExceptionMessages.DataAccessException, ex);
				throw new ApplicationException("Error occurred while fetching data");
			}
			return result;
		}
		
		#endregion
	}
}
