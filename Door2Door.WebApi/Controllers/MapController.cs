using System.Collections.Generic;
using System.Threading.Tasks;
using Door2Door.WebApi.ApplicationServices;
using Door2Door.WebApi.Models.GeoJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Door2Door.WebApi.Controllers
{
	[ApiController]
	public class MapController : Controller
	{
		private readonly IMapApplicationService _mapApplicationService;

		public MapController(IMapApplicationService mapApplicationService)
		{
			_mapApplicationService = mapApplicationService;
		}

		[HttpGet]
		public async Task<JsonResult> Get(string location, int level)
		{
			GeoJson geoJson = await _mapApplicationService.GetGeoJsonMapAsync(location, level);

			if (geoJson is null)
			{
				Response.StatusCode = StatusCodes.Status404NotFound;
				return new JsonResult(null);
			}
			else
			{
				Response.StatusCode = StatusCodes.Status200OK;
				return new JsonResult(geoJson);
			}
		}

		[HttpGet]
		public async Task<JsonResult> GetAll(string location, int level)
		{
			List<GeoJson> geoJson = await _mapApplicationService.GetAllGeoJsonMapAsync(location, level);

			if (geoJson is null)
			{
				Response.StatusCode = StatusCodes.Status404NotFound;
				return new JsonResult(null);
			}
			else
			{
				Response.StatusCode = StatusCodes.Status200OK;
				return new JsonResult(geoJson);
			}
		}
	}
}
