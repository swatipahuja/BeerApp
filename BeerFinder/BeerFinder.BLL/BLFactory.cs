using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BeerFinder.BLL.Interfaces;

namespace BeerFinder.BLL
{
	public class BLFactory
	{
		#region Private Members

		/// <summary>
		/// Holds the mapping of BL types to BL objects.
		/// This mapping will be used to return the mock BL object in unit testing mode 
		/// </summary>
		private static readonly Dictionary<Type, IBLL> BLs = new Dictionary<Type, IBLL>();

		#endregion

		#region Public Properties/Methods

		/// <summary>
		/// This property indicates that mock BLs will be used for unit test scenarios.
		/// </summary>
		public static bool UnitTestMode { get; set; }

		/// <summary>
		/// Create a BL of the specified type.
		/// </summary>
		/// <typeparam name="TBL">Must be a class that implements the IBL interface.</typeparam>
		/// <returns></returns>
		public static TBL CreateBL<TBL>()
			where TBL : class, IBLL
		{
			TBL result = default(TBL);

			if (UnitTestMode)
			{
				//If 
				if (BLs.ContainsKey(typeof(TBL)))
				{
					result = BLs[typeof(TBL)] as TBL;
				}
				else
				{
					var blType = typeof(TBL);

					foreach (var valuePair in BLs)
					{
						if (valuePair.Value is TBL)
						{
							result = valuePair.Value as TBL;
							break;
						}
					}
					if (result == null)
					{
						var msg = string.Format("A BL of Type '{0}' was not provided to the BLFactory",
												typeof(TBL).Name);
						throw new Exception(msg);
					}
				}
			}
			else
			{
				var blType = typeof(TBL);
				if (blType.IsInterface)
				{
					var assembly = Assembly.GetExecutingAssembly();
					var bls = assembly.GetTypes().Where(r => r.IsClass && !r.IsAbstract && !r.IsNested).ToList();
					var bl = bls.FirstOrDefault(blType.IsAssignableFrom);
					if (bl == null)
					{
						var msg = string.Format("A BL with an interface of '{0}' could not be found by the BLFactory.", typeof(TBL).Name);
						throw new Exception(msg);
					}
					result = Activator.CreateInstance(bl, true) as TBL;
				}
				else
				{
					result = Activator.CreateInstance(typeof(TBL), true) as TBL;
				}
			}
			return result;
		}

		/// <summary>
		/// This is a means to provide Mock BL for BLFactory to serve up for unit testing.
		/// </summary>
		/// <param name="bl"></param>
		public static void SetBLForUnitTest(IBLL bl)
		{
			//Update mock object if mapping for this type already exists
			if (BLs.ContainsKey(bl.GetType()))
			{
				BLs[bl.GetType()] = bl;
			}
			else //Add mock object if mapping for this type does not exist
			{
				BLs.Add(bl.GetType(), bl);
			}
		}

		#endregion
	}
}
