using AutoMapper;
using ComputerService.BusinessModel;
using ComputerService.DataModel.Client;
using ComputerService.DataModel.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Mapper
{
    public class BusinessModel2DataModel : Profile
    {
        public BusinessModel2DataModel()
        {
            CreateMap<Client, AddClientRequest>()
                .ForMember(e => e.ime, evm => evm.MapFrom(c => c.FirstName))
                .ForMember(e => e.prezime, evm => evm.MapFrom(c => c.LastName))
                .ForMember(e => e.email, evm => evm.MapFrom(c => c.Email))
                .ForMember(e => e.brojTelefona, evm => evm.MapFrom(c => c.PhoneNumber))
                .ForMember(e => e.BrojLK, evm => evm.MapFrom(c => c.PersonalIdNumber));

            CreateMap<Device, AddDeviceRequest>();
        }
    }
}
