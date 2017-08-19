using System;
using BeerFinder.DAL.Interfaces;

namespace BeerFinder.DAL
{
	public class BaseDAL : IDAL, IDisposable
	{
		public virtual void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
