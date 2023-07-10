using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.BusinessModel
{
    public class CommandResponse
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class CommandResponse<T> : CommandResponse
    {
        public T Data { get; set; }
    }
}
