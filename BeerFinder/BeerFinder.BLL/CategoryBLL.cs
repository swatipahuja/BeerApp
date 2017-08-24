using System;
using BeerFinder.BLL.Interfaces;
using BeerFinder.DAL;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Logger;
using BeerFinder.Shared;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL
{
	public class CategoryBLL :  ICategoryBLL
	{
		#region Private Members
		private ILogger _logger = LoggerFactory.CreateLogger(typeof(CategoryBLL));
		#endregion

		#region Public Members
		/// <summary>
		/// Gets category filter data
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		public CategoryResponseMsg GetCategoryFilterData()
		{
			CategoryResponseMsg result = new CategoryResponseMsg();
			try
			{
				using (var beerDAL = DALFactory.CreateDAL<ICategoryDAL>())
				{
					result = beerDAL.GetCategoryFilterData();
				}
			}
			catch (Exception ex)
			{
				_logger.LogException(LogSeverity.Error, Constants.LogExceptionMessages.DataAccessException, ex);
				throw new ApplicationException("Error occurred while fetching data");
			}
			return result;
		}

		/// <summary>
		/// Dispose all resources
		/// </summary>
		public void Dispose()
		{
			_logger = null;
		}
		#endregion
	}
}
