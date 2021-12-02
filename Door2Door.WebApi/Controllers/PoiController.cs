﻿using System.Threading.Tasks;
using Door2Door.WebApi.ApplicationServices;
using Door2Door.WebApi.Models.GeoJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Door2Door.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PoiController : Controller
	{
		private readonly IMapApplicationService _mapApplicationService;

		public PoiController(IMapApplicationService mapApplicationService)
		{
			_mapApplicationService = mapApplicationService;
		}

		[HttpGet]
		public async Task<JsonResult> Get(string location)
		{
			GeoJson result = await _mapApplicationService.GetMapPoiAsync(location);

			if (result is null)
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
