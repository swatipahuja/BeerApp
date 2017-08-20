using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BeerFinder.Shared.DTO;

namespace BeerFinder.Shared.ResponseMsg
{
	[DataContract]
	public class BeerResponseMsg
	{
		[DataMember(Name = "currentPage")]
		public int CurrentPage { get; set; }

		[DataMember(Name = "numberOfPages")]
		public int NumberOfPages { get; set; }

		[DataMember(Name = "totalResults")]
		public int TotalResults { get; set; }

		[DataMember(Name = "data")]
		public List<BeerDto> Beers { get; set; } = new List<BeerDto>();
		[DataMember(Name = "categories")]
		public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
		[DataMember(Name = "styles")]
		public List<StyleDto> Styles { get; set; } = new List<StyleDto>();
		[DataMember(Name = "glassWare")]
		public List<GlassWareDto> GlassWare { get; set; }

		public BeerResponseMsg()
		{
			Beers = new List<BeerDto>();
		}
	}
}
