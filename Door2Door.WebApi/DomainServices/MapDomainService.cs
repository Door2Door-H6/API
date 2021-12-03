using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Door2Door.WebApi.InfrastructureServices;
using Door2Door.WebApi.Models;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.DomainServices
{
	public interface IMapDomainService
	{
		Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location);
		Task<string> GetMapPathAsync(int standId, string roomName);
		Task<string> GetMapPoiAsync(string location);
		Task<string> GetMapRoomLabelsAsync(string location);
		Task<string> GetMapRoomsAsync(string location);
		Task<string> GetMapWallsAsync(string location);
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

		public async Task<string> GetMapWallsAsync(string location)
		{
			IEnumerable<string> result = await _databaseInfrastructureService.GetMapWallsAsync(location);

			if (!result.Any())
			{
				_logger.LogError("");
			}

			StringBuilder stringBuilder = new();

			foreach (string str in result)
			{
				stringBuilder.Append(str);
			}

			return stringBuilder.ToString();
		}

		public async Task<string> GetMapRoomsAsync(string location)
		{
			IEnumerable<string> result = await _databaseInfrastructureService.GetMapRoomsAsync(location);

			if (!result.Any())
			{
				_logger.LogError("");
			}

			StringBuilder stringBuilder = new();

			foreach (string str in result)
			{
				stringBuilder.Append(str);
			}

			return stringBuilder.ToString();
		}

		public async Task<string> GetMapRoomLabelsAsync(string location)
		{
			IEnumerable<string> result = await _databaseInfrastructureService.GetMapRoomLabelsAsync(location);

			if (!result.Any())
			{
				_logger.LogError("");
			}

			StringBuilder stringBuilder = new();

			foreach (string str in result)
			{
				stringBuilder.Append(str);
			}

			return stringBuilder.ToString();
		}

		public async Task<string> GetMapPoiAsync(string location)
		{
			IEnumerable<string> result = await _databaseInfrastructureService.GetMapPoiAsync(location);

			if (!result.Any())
			{
				_logger.LogError("");
			}

			StringBuilder stringBuilder = new();

			foreach (string str in result)
			{
				stringBuilder.Append(str);
			}

			return stringBuilder.ToString();
		}

		public async Task<string> GetMapPathAsync(int standId, string roomName)
		{
			IEnumerable<string> result = await _databaseInfrastructureService.GetMapPathAsync(standId, roomName);

			if (!result.Any())
			{
				_logger.LogError("");
			}

			StringBuilder stringBuilder = new();

			foreach (string str in result)
			{
				stringBuilder.Append(str);
			}

			return stringBuilder.ToString();
		}

		public async Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location)
		{
			IEnumerable<Room> result = await _databaseInfrastructureService.GetMapCatagoriesAndRoomsAsync(location);

			if (!result.Any())
			{
				_logger.LogError("");
			}

			List<string> roomTypes = result.Select(x => x.TypeName).Distinct().ToList();
			List<CatagoriesWithRooms> catagoriesWithRooms = new();

			foreach (string room in roomTypes)
			{
				catagoriesWithRooms.Add(new CatagoriesWithRooms { Name = room, Rooms = result.Where(x => x.TypeName == room).Select(x => x.Name).ToList() });
			}

			return catagoriesWithRooms;
		}
	}
}
