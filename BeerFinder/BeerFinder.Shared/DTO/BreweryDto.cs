using System;
using System.Runtime.Serialization;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	[DataContract]
	public class BreweryDto : IDto
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }
		[DataMember(Name = "name")]
		public string Name { get; set; }
		[DataMember(Name = "createDate")]
		public DateTime? CreatedDate { get; set; }
		[DataMember(Name = "nameShortDisplay")]
		public string NameShortDisplay { get; set; }
		[DataMember(Name = "description")]
		public string Description { get; set; }
		[DataMember(Name = "website")]
		public string Website { get; set; }
	}
}
