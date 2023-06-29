using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.DataModel.Device
{
    public class GetDeviceResponse
    {
        public int id { get; set; }
		public Guid Guid { get; set; }
        public int ModelId { get; set; }
        public string NazivModela { get; set; }
        public int ProizvodjacId { get; set; }
        public string NazivProizvodjaca { get; set; }
        public string OpisKlijent { get; set; }
        public string OpisZaposleni { get; set; }
        public int StatusId { get; set; }
        public string StatusNaziv { get; set; }
        public DateTime Vreme { get; set; }
        public int KlijentId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public string BrojLicneKarte { get; set; }
    }
}
