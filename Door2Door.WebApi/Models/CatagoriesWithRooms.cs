using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Door2Door.WebApi.Models
{
	public class CatagoriesWithRooms
	{
		public string Name { get; set; }
		public List<string> Rooms { get; set; }
	}
}
