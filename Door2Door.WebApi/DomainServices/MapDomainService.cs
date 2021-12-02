using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Door2Door.WebApi.InfrastructureServices;
using Door2Door.WebApi.Models;
using Door2Door.WebApi.Models.GeoJson;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.DomainServices
{
	public interface IMapDomainService
	{
		Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location);
		Task<GeoJson> GetMapPathAsync(string location);
		Task<GeoJson> GetMapPoiAsync(string location);
		Task<GeoJson> GetMapRoomsAsync(string location);
		Task<GeoJson> GetMapWallsAsync(string location);
	}

	public class MapDomainService : IMapDomainService
	{
		private readonly IDatabaseInfrastructureService _databaseInfrastructureService;
		private readonly ILogger<MapDomainService> _logger;

		public MapDomainService(IDatabaseInfrastructureService databaseInfrastructureService, ILogger<MapDomainService> ilogger)
		{
			_databaseInfrastructureService = databaseInfrastructureService;
			_logger = ilogger;
		}

		public async Task<GeoJson> GetMapWallsAsync(string location)
		{
			GeoJson result = await _databaseInfrastructureService.GetMapWallsAsync(location);

			if (result is null)
			{
				_logger.LogError("");
			}
			 
			return result;
		}

		public async Task<GeoJson> GetMapRoomsAsync(string location)
		{
			GeoJson result = await _databaseInfrastructureService.GetMapRoomsAsync(location);

			if (result is null)
			{
				_logger.LogError("");
			}

			return result;
		}

		public async Task<GeoJson> GetMapPoiAsync(string location)
		{
			GeoJson result = await _databaseInfrastructureService.GetMapPoiAsync(location);

			if (result is null)
			{
				_logger.LogError("");
			}

			return result;
		}

		public async Task<GeoJson> GetMapPathAsync(string location)
		{
			GeoJson result = await _databaseInfrastructureService.GetMapPathAsync(location);

			if (result is null)
			{
				_logger.LogError("");
			}

			return result;
		}

		public async Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location)
		{
			List<CatagoriesWithRooms> result = await _databaseInfrastructureService.GetMapCatagoriesAndRoomsAsync(location);

			if (!result.Any())
			{
				_logger.LogError("");
			}

			return result;
		}
	}
}
