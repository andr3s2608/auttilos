using Backend.Shared.Utilities;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.Repositories.Context
{
    public class OracleContext
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public readonly string ConnectionString;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;

        /// <summary>
        /// Initializes a new instance of the <see cref="EcoOracleContext" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="telemetryException">The telemetry exception.</param>
        public OracleContext(IConfiguration configuration,
                             Utilities.Telemetry.ITelemetryException telemetryException)
        {
            ConnectionString = configuration.GetValue<string>(Utilities.Constants.KeyVault.ORACLEConnection);
            TelemetryException = telemetryException;
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<T>> ExecuteQuery<T>(string name, params OracleParameter[] parameters)
        {
            using OracleConnection oracleConnection = new OracleConnection(ConnectionString) ;
            try
            {
                using OracleCommand oracleCommand = new OracleCommand(name)
                {
                    Connection = oracleConnection,
                    CommandType = CommandType.Text,
                    CommandTimeout= 180
                };

                await oracleConnection.OpenAsync();

                if (parameters != null && parameters.Any())
                {
                    oracleCommand.Parameters.AddRange(parameters);
                }

                using OracleDataAdapter oracleDataAdapter = new OracleDataAdapter
                {
                    SelectCommand = oracleCommand
                };

                DataTable dataTable = new DataTable();
                oracleDataAdapter.Fill(dataTable);

                if (typeof(T).Name.Contains("object", StringComparison.InvariantCultureIgnoreCase))
                {
                    return dataTable.ToDynamic<T>();
                }

                return dataTable.ConvertDataTable<T>();
            }
            catch (Exception exc)
            {
                TelemetryException.RegisterException(exc);

                throw new ArgumentException(exc.Message, exc);
            }
            finally
            {
                if (oracleConnection != null && oracleConnection.State == ConnectionState.Open)
                {
                    await oracleConnection.CloseAsync();
                }
            }
        }
    }
}
