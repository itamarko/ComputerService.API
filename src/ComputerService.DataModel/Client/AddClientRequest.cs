using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.DataModel.Client
{
    public class AddClientRequest
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public string BrojLK { get; set; }
    }
}
