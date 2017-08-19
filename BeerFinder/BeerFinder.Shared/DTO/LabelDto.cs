using System;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	public class LabelDto : IDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Icon { get; set; }
		public string Medium { get; set; }
		public string Large { get; set; }
	}
}
