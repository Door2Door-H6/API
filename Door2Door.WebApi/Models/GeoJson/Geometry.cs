using System.Collections.Generic;

namespace Door2Door.WebApi.Models.GeoJson
{
	public class Geometry
	{
		public string Type { get; set; }
		public List<List<List<double>>> Coordinates { get; set; }
	}
}