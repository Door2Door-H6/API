using System.Threading.Tasks;
using Door2Door.WebApi.ApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Door2Door.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PathController : Controller
	{
		private readonly IMapApplicationService _mapApplicationService;

		public PathController(IMapApplicationService mapApplicationService)
		{
			_mapApplicationService = mapApplicationService;
			_mapApplicationService = mapApplicationService;
		}

		[HttpGet]
		public async Task<JsonResult> Get(int standId, string roomName)
		{
			string result = await _mapApplicationService.GetMapPathAsync(standId, roomName);

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
