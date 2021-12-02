using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Door2Door.WebApi.DomainServices;
using Door2Door.WebApi.Models;
using Door2Door.WebApi.Models.GeoJson;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.ApplicationServices
{
	public interface IMapApplicationService
	{
		Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location);
		Task<GeoJson> GetMapPathAsync(string location);
		Task<GeoJson> GetMapPoiAsync(string location);
		Task<GeoJson> GetMapRoomsAsync(string location);
		Task<GeoJson> GetMapWallsAsync(string location);
	}

	public class MapApplicationService : IMapApplicationService
	{
		private readonly IMapDomainService _mapDomainService;
		private readonly ILogger<MapApplicationService> _logger;

		public MapApplicationService(IMapDomainService mapDomainService, ILogger<MapApplicationService> logger)
		{
			_mapDomainService = mapDomainService;
			_logger = logger;
		}

		public async Task<GeoJson> GetMapWallsAsync(string location)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				return await _mapDomainService.GetMapWallsAsync(location);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return new GeoJson();
			}
		}

		public async Task<GeoJson> GetMapRoomsAsync(string location)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				return await _mapDomainService.GetMapRoomsAsync(location);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return new GeoJson();
			}
		}

		public async Task<GeoJson> GetMapPoiAsync(string location)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				return await _mapDomainService.GetMapPoiAsync(location);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return new GeoJson();
			}
		}

		public async Task<GeoJson> GetMapPathAsync(string location)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				return await _mapDomainService.GetMapPathAsync(location);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return new GeoJson();
			}
		}

		public async Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				return await _mapDomainService.GetMapCatagoriesAndRoomsAsync(location);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return new List<CatagoriesWithRooms>();
			}
		}
	}
}
