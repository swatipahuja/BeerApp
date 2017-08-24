using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BeerFinder.DAL.Interfaces;

namespace BeerFinder.DAL
{
	public class DALFactory
	{
		#region Private Members

		/// <summary>
		/// Holds the mapping of DAL types to DAL objects.
		/// This mapping will be used to return the mock DAL object in unit testing mode 
		/// </summary>
		private static readonly Dictionary<Type, IDAL> DACs = new Dictionary<Type, IDAL>();

		#endregion

		#region Public Properties/Methods

		/// <summary>
		/// This property indicates that mock data access components will be used for unit test scenarios.
		/// </summary>
		public static bool UnitTestMode { get; set; }

		/// <summary>
		/// Create a DAL of the specified type.
		/// </summary>
		/// <typeparam name="TDAL">Must be a class that implements the IDAL interface.</typeparam>
		/// <returns></returns>
		public static TDAL CreateDAL<TDAL>()
			where TDAL : class, IDAL
		{
			TDAL result = default(TDAL);
			var dalType = typeof(TDAL);

			if (UnitTestMode)
			{
				if (DACs.ContainsKey(dalType))
				{
					result = DACs[dalType] as TDAL;
				}
				else
				{
					foreach (var valuePair in DACs)
					{
						if (valuePair.Value is TDAL)
						{
							result = valuePair.Value as TDAL;
							break;
						}
					}
					if (result == null)
					{
						var msg = string.Format("A DAC of Type '{0}' was not provided to the DALFactory", dalType.Name);
						throw new Exception(msg);
					}
				}
			}
			else
			{
				//If passed DAL type is an interface then we need to find an assignable class from the assembly and create instance of it
				if (dalType.IsInterface)
				{
					var assembly = Assembly.GetExecutingAssembly();
					var dals = assembly.GetTypes().Where(r => r.IsClass && !r.IsAbstract && !r.IsNested).ToList();
					var dal = dals.FirstOrDefault(dalType.IsAssignableFrom);
					if (dal == null)
					{
						var msg = string.Format("A DAC with an interface of '{0}' could not be found by the DALFactory.", dalType.Name);
						throw new Exception(msg);
					}
					result = Activator.CreateInstance(dal, true) as TDAL;
				}
				else
				{
					result = Activator.CreateInstance(dalType, true) as TDAL;
				}
			}
			return result;
		}



		/// <summary>
		/// This is a means to provide Mock data access components for DALFactory to serve up for unit testing.
		/// </summary>
		/// <param name="dal"></param>
		public static void SetDALForUnitTest(IDAL dal)
		{
			//Update mock object if mapping for this type already exists
			if (DACs.ContainsKey(dal.GetType()))
			{
				DACs[dal.GetType()] = dal;
			}
			else //Add mock object if mapping for this type does not exist
			{
				DACs.Add(dal.GetType(), dal);
			}
		}

		#endregion
	}
}
