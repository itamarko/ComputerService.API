using ComputerService.DataModel.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Services.Interfaces
{
    public interface IDeviceService
    {
        int AddDevice(AddDeviceRequest device);
        GetDeviceResponse GetDevice(int id);
    }
}
