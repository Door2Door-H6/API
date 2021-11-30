namespace Door2Door.WebApi.Models.GeoJson
{
	public class Feature
	{
		public string Type { get; set; }
		public Properties Properties { get; set; }
		public Geometry Geometry { get; set; }
	}
}