using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.BusinessModel
{
    public class Device
    {
        public int TypeId { get; set; }
        public int ModelId { get; set; }
        public string DescriptionClient { get; set; }
        public string DescriptionEmployee { get; set; }
    }
}
