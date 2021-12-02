using System.Collections.Generic;

namespace Door2Door.WebApi.Models.GeoJson
{
	public class GeoJson
	{
		public string Type { get; set; }
		public string Name { get; set; }
		public Crs Crs { get; set; }
		public List<Feature> Features { get; set; }
	}
}
