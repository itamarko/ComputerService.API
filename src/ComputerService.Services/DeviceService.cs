using ComputerService.DataModel.Device;
using ComputerService.Services.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Services
{
    public class DeviceService : IDeviceService
    {

        private readonly IConfiguration _config;
        private readonly string _connString;

        public DeviceService(IConfiguration configuration)
        {
            _config = configuration;
            _connString = _config.GetConnectionString("CSConnection");
        }

        public int AddDevice(AddDeviceRequest device)
        {
            int deviceId = 0;

            try
            {
                string query = "dbo.UnesiUredjaj";
                using (var sqlConn = new SqlConnection(_connString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Tip", device.TypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    param.Add("@modelId", device.ModelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    param.Add("@opisKlijent", device.DescriptionClient, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@opisZaposleni", device.DescriptionEmployee, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@klijentId", device.ClientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    param.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    sqlConn.Execute(query, param, commandType: CommandType.StoredProcedure);

                    deviceId = param.Get<int>("@id");
                }
            }
            catch (Exception ex)
            {

            }

            return deviceId;
        }

        public GetDeviceResponse GetDevice(int id)
        {
            GetDeviceResponse device = new GetDeviceResponse();

            try
            {
                string query = "dbo.UnesiUredjaj";
                using (var sqlConn = new SqlConnection(_connString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    device = sqlConn.QuerySingle<GetDeviceResponse>(query, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

            }

            return device;
        }
    }
}
