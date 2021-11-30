using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Door2Door.WebApi.InfrastructureServices;
using Door2Door.WebApi.Models.GeoJson;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.DomainServices
{
	public interface IMapDomainService
	{
		Task<List<GeoJson>> GetAllGeoJsonAsync(string location, int level);
		Task<GeoJson> GetGeoJson(string location, int level);
	}

	public class MapDomainService : IMapDomainService
	{
		private readonly RepositoryContext _repositoryContext;
		private readonly ILogger<MapDomainService> _logger;

		public MapDomainService(RepositoryContext repositoryContext, ILogger<MapDomainService> ilogger)
		{
			_repositoryContext = repositoryContext;
			_logger = ilogger;
		}

		public async Task<GeoJson> GetGeoJson(string location, int level)
		{
			List<Feature> features = await _repositoryContext.Get(location, level);

			if (!features.Any())
			{
				_logger.LogError("");
			}

			return GenerateGeoJson($"{location}-{level}", features);
		}

		public async Task<List<GeoJson>> GetAllGeoJsonAsync(string location, int level)
		{
			List<List<Feature>> features = await _repositoryContext.Get(location, level);

			if (!features.Any())
			{
				_logger.LogError("");
			}

			List<GeoJson> geoJsons = new();

			foreach (List<Feature> feature in features)
			{
				geoJsons.Add(GenerateGeoJson($"{location}",feature));
			}

			return geoJsons;
		}

		public GeoJson GenerateGeoJson(string name, List<Feature> features)
		{
			return new GeoJson
			{
				Type = "FeatureCollection",
				Name = name,
				Crs = new Crs
				{
					Type = "name",
					Properties = new Properties
					{
						Name = "urn:ogc:def:crs:EPSG::3395"
					}
				},
				Features = features
			};
		}

	}
}
