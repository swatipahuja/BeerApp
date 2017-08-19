using System;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	public class BeerDto : IDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public float ABV { get; set; }
		public string NameDisplay { get; set; }
		public int GlassWareId { get; set; }
		public int StyleId { get; set; }
		public bool IsOrganic { get; set; }
		public LabelDto Label { get; set; }
		public string Status { get; set; }
		public string StatusDisplay { get; set; }
		public BreweryDto Brewery { get; set; }

	}
}
