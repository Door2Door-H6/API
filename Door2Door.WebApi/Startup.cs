using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Door2Door.WebApi.ApplicationServices;
using Door2Door.WebApi.DomainServices;
using Door2Door.WebApi.InfrastructureServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Door2Door.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Infrastructure Service
			services.AddTransient<SqlConnection>(s =>
			{
				string conn = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
				return new SqlConnection(conn);
			});
			services.AddScoped<IDatabaseInfrastructureService, DatabaseInfrastructureService>();

			// Domain Service
			services.AddScoped<IMapDomainService, MapDomainService>();

			// Application Service
			services.AddScoped<IMapApplicationService, MapApplicationService>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Door2Door.WebApi", Version = "v1" });
			});

			services.AddCors(o =>
			{
				o.AddPolicy("Door2door", builder =>
				{
					builder.AllowAnyOrigin();
					builder.AllowAnyMethod();
					builder.AllowAnyHeader();
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Door2Door.WebApi v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseCors();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers().RequireCors("Door2door");
			});
		}
	}
}
