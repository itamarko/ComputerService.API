using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.DataModel.Device
{
    public class AddDeviceRequest
    {
        public int TypeId { get; set; }
        public int ModelId { get; set; }
        public string DescriptionClient { get; set; }
        public string DescriptionEmployee { get; set; }
        public int ClientId { get; set; }
    }
}
