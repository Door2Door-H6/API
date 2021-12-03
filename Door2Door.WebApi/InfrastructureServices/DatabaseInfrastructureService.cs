using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;

namespace Door2Door.WebApi.InfrastructureServices
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDatabaseInfrastructureService
	{
		Task<IEnumerable<string>> GetMapCatagoriesAndRoomsAsync(string location);
		Task<IEnumerable<string>> GetMapPathAsync(string location);
		Task<IEnumerable<string>> GetMapPoiAsync(string location);
		Task<IEnumerable<string>> GetMapRoomLabelsAsync(string location);
		Task<IEnumerable<string>> GetMapRoomsAsync(string location);
		Task<IEnumerable<string>> GetMapWallsAsync(string location);
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
		public async Task<IEnumerable<string>> GetMapWallsAsync(string location)
		{
			string procedureName = "GetWalls";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<string>(procedureName, parameters);
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
		public async Task<IEnumerable<string>> GetMapRoomsAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<string>(procedureName, parameters);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<string>> GetMapRoomLabelsAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<string>(procedureName, parameters);
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
		public async Task<IEnumerable<string>> GetMapPoiAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<string>(procedureName, parameters);
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
		public async Task<IEnumerable<string>> GetMapPathAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<string>(procedureName, parameters);
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
		public async Task<IEnumerable<string>> GetMapCatagoriesAndRoomsAsync(string location)
		{
			string procedureName = "";

			DynamicParameters parameters = new();
			parameters.Add("@location", location);

			try
			{
				return await ExecuteProcedure<string>(procedureName, parameters);
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
		private async Task<IEnumerable<T>> ExecuteProcedure<T>(string procedureName, DynamicParameters parameters)
		{
			try
			{
				_sqlConnection.Open();
				return await _sqlConnection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Something went wrong when executing procedure", procedureName, _sqlConnection);
				throw;
			}
		}
	}
}
