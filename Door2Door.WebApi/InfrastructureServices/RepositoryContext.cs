using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Door2Door.WebApi.InfrastructureServices
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions options):base(options)
		{
		}


	}
}
