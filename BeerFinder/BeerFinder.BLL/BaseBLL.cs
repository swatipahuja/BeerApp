using System;
using BeerFinder.BLL.Interfaces;

namespace BeerFinder.BLL
{
	public class BaseBLL : IBLL, IDisposable
	{
		public virtual void Dispose()
		{
			
		}
	}
}
