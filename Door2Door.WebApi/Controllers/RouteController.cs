using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Door2Door.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Door2Door.WebApi.Controllers
{
	public class RouteController : Controller
	{
		public RouteController()
		{

		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
