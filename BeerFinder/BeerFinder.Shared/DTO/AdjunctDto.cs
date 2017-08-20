using System;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	public class AdjunctDto : IDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public string CategoryDisplay { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}
