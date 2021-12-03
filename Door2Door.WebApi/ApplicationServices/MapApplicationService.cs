using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Door2Door.WebApi.DomainServices;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.ApplicationServices
{
	public interface IMapApplicationService
	{
		Task<List<Models.CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location);
		Task<string> GetMapPathAsync(int standId, string roomName);
		Task<string> GetMapPoiAsync(string location);
		Task<string> GetMapRoomLabelsAsync(string location);
		Task<string> GetMapRoomsAsync(string location);
		Task<string> GetMapWallsAsync(string location);
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

		public async Task<string> GetMapWallsAsync(string location)
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
				return string.Empty;
			}
		}

		public async Task<string> GetMapRoomsAsync(string location)
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
				return string.Empty;
			}
		}

		public async Task<string> GetMapRoomLabelsAsync(string location)
		{
			if (string.IsNullOrEmpty(location))
			{
				throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
			}

			try
			{
				return await _mapDomainService.GetMapRoomLabelsAsync(location);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return string.Empty;
			}
		}

		public async Task<string> GetMapPoiAsync(string location)
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
				return string.Empty;
			}
		}

		public async Task<string> GetMapPathAsync(int standId, string roomName)
		{
			if (string.IsNullOrEmpty(roomName))
			{
				throw new ArgumentException($"'{nameof(roomName)}' cannot be null or empty.", nameof(roomName));
			}

			try
			{
				return await _mapDomainService.GetMapPathAsync(standId, roomName);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "");
				return string.Empty;
			}
		}

		public async Task<List<Models.CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location)
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
				return new List<Models.CatagoriesWithRooms>();
			}
		}
	}
}
