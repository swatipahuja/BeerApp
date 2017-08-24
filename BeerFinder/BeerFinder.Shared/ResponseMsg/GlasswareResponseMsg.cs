using System.Collections.Generic;
using System.Runtime.Serialization;
using BeerFinder.Shared.DTO;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.ResponseMsg
{
	[DataContract]
	public class GlasswareResponseMsg : IResponseMsg
	{
		[DataMember(Name = "data")]
		public List<GlasswareDto> Glass { get; set; } = new List<GlasswareDto>();
		[DataMember(Name = "erroMessage")]
		public string ErrorMessage { get; set; }

	}
}
