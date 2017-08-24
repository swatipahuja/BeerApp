using BeerFinder.DAL.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace BeerFinder.DAL.Tests
{
	[TestFixture]
	public class DALFactoryTest
	{
		[Test]
		public void CreateDALInstance()
		{
			DALFactory.UnitTestMode = false;
			using (var dal = DALFactory.CreateDAL<IBeerDAL>())
			{
				Assert.NotNull(dal);
				Assert.AreEqual(dal.GetType().Name, "BeerDAL");
			}
		}

		[Test]
		public void CreateDALInstanceForTesting()
		{
			DALFactory.UnitTestMode = true;
			var dal = Substitute.For<IBeerDAL>();
			DALFactory.SetDALForUnitTest(dal);
			Assert.NotNull(dal);
			Assert.AreEqual(dal.GetType().Name, "IBeerDALProxy");
		}


	}
}
