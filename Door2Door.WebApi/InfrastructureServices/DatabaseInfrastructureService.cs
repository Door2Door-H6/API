﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Door2Door.WebApi.Models;
using Door2Door.WebApi.Models.GeoJson;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.InfrastructureServices
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDatabaseInfrastructureService
	{
		Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location);
		Task<GeoJson> GetMapPathAsync(string location);
		Task<GeoJson> GetMapPoiAsync(string location);
		Task<GeoJson> GetMapRoomsAsync(string location);
		Task<GeoJson> GetMapWallsAsync(string location);
	}

	/// <summary>
	/// 
	/// </summary>
	public class DatabaseInfrastructureService : IDatabaseInfrastructureService
	{
		/// <summary>
		/// The sql connection on witch to query against
		/// </summary>
		private readonly SqlConnection _sqlConnection;

		/// <summary>
		/// An logger to collect logs for the service
		/// </summary>
		private readonly ILogger<DatabaseInfrastructureService> _logger;

		public DatabaseInfrastructureService(SqlConnection sqlConnection, ILogger<DatabaseInfrastructureService> logger)
		{
			_sqlConnection = sqlConnection;
			_logger = logger;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
		public async Task<GeoJson> GetMapWallsAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<GeoJson>(procedureName, parameters);
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
		public async Task<GeoJson> GetMapRoomsAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<GeoJson>(procedureName, parameters);
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
		public async Task<GeoJson> GetMapPoiAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<GeoJson>(procedureName, parameters);
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
		public async Task<GeoJson> GetMapPathAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<GeoJson>(procedureName, parameters);
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="location"></param>
		/// <returns>The categories and its rooms on location</returns>
		public async Task<List<CatagoriesWithRooms>> GetMapCatagoriesAndRoomsAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<List<CatagoriesWithRooms>>(procedureName, parameters);
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// Executes an query with the parsed parameters
		/// </summary>
		/// <typeparam name="T">The type the stored procedure should return</typeparam>
		/// <param name="procedureName">Name of the stored procedure to be executed</param>
		/// <param name="parameters">Parameters of the procedure</param>
		/// <returns>The result of the stored procedure</returns>
		private async Task<T> ExecuteProcedure<T>(string procedureName, DynamicParameters parameters)
		{
			try
			{
				_sqlConnection.Open();
				return await _sqlConnection.QueryFirstOrDefaultAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when executing procedure", procedureName, _sqlConnection);
				throw;
			}
		}
	}
}
