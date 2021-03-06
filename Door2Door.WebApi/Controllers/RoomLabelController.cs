using System.Threading.Tasks;
using Door2Door.WebApi.ApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Door2Door.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RoomLabelController : Controller
	{
		private readonly IMapApplicationService _mapApplicationService;

		public RoomLabelController(IMapApplicationService mapApplicationService)
		{
			_mapApplicationService = mapApplicationService;
		}

		[HttpGet]
		public async Task<JsonResult> Get(string location)
		{
			string result = await _mapApplicationService.GetMapRoomLabelsAsync(location);

			if (string.IsNullOrWhiteSpace(result))
			{
				Response.StatusCode = StatusCodes.Status404NotFound;
				return new JsonResult(null);
			}
			else
			{
				Response.StatusCode = StatusCodes.Status200OK;
				return new JsonResult(result);
			}
		}
	}
}
