using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Door2Door.WebApi.DomainServices;
using Door2Door.WebApi.Models.GeoJson;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.ApplicationServices
{
	public interface IMapApplicationService
	{
		Task<List<GeoJson>> GetAllGeoJsonMapAsync(string location, int level);
		Task<GeoJson> GetGeoJsonMapAsync(string location, int level);
	}

	public class MapApplicationService : IMapApplicationService
	{
		private readonly IMapDomainService _mapDomainService;
		private readonly ILogger<MapApplicationService> _logger;

		public MapApplicationService(MapDomainService mapDomainService, ILogger<MapApplicationService> logger)
		{
			_mapDomainService = mapDomainService;
			_logger = logger;
		}

		public async Task<List<GeoJson>> GetAllGeoJsonMapAsync(string location, int level)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				List<GeoJson> geoJson = await _mapDomainService.GetAllGeoJsonAsync(location, level);
				return geoJson;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return new List<GeoJson>();
			}
		}

		public async Task<GeoJson> GetGeoJsonMapAsync(string location, int level)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				GeoJson geoJson = await _mapDomainService.GetGeoJson(location, level);
				return geoJson;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return null;
			}
		}
	}
}
