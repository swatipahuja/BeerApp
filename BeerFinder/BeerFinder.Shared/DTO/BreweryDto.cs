using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	public class BreweryDto : IDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public string NameShortDisplay { get; set; }
		public string Description { get; set; }
		public string Website { get; set; }
	}
}
