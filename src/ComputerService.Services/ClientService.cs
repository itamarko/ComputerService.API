using ComputerService.DataModel.Client;
using ComputerService.Services.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ComputerService.Services
{
    public class ClientService : IClientService
    {
        private readonly IConfiguration _config;
        private readonly string _connString;

        public ClientService(IConfiguration configuration)
        {
            _config = configuration;
            _connString = _config.GetConnectionString("CSConnection");
        }

        public int AddClient(AddClientRequest client)
        {
            int clientId = 0;

            try
            {
                string query = "dbo.UnesiKlijenta";
                using (var sqlConn = new SqlConnection(_connString))
                {
                    var param = new DynamicParameters();
                    param.Add("@ime", client.ime, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@prezime", client.prezime, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@email", client.email, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@brojTelefona", client.brojTelefona, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@BrojLK", client.BrojLK, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    sqlConn.Execute(query, param, commandType: CommandType.StoredProcedure);

                    clientId = param.Get<int>("@id");
                }
            }
            catch (Exception ex)
            {

            }

            return clientId;
        }

        public bool ClientExists(string email)
        {
            bool clientExists = false;

            try
            {
                string query = "dbo.DaLiKlijentPostoji";
                using (var sqlConn = new SqlConnection(_connString))
                {
                    var param = new DynamicParameters();
                    param.Add("@email", email, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@daLiPostoji", dbType: DbType.Binary, direction: ParameterDirection.Output);

                    sqlConn.Execute(query, param, commandType: CommandType.StoredProcedure);

                    clientExists = param.Get<bool>("@daLiPostoji");
                }
            }
            catch (Exception ex)
            {

            }

            return clientExists;
        }
    }
}