using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	public class GlassWareDto: IDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}
