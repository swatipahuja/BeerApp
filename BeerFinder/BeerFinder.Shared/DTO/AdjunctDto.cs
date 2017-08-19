using System;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	[Serializable]
	public class AdjunctDto : IDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public string CategoryDisplay { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
