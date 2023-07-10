using AutoMapper;
using ComputerService.BusinessLogic.Interfaces;
using ComputerService.BusinessModel;
using ComputerService.DataModel.Client;
using ComputerService.DataModel.Device;
using ComputerService.Services.Interfaces;

namespace ComputerService.BusinessLogic
{
    public class DeviceBL : IDeviceBL
    {
        private readonly IClientService _clientService;
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceBL(IClientService clientService, 
                            IDeviceService deviceService,
                            AutoMapper.IMapper mapper)
        {
            _clientService = clientService;
            _deviceService = deviceService;
            _mapper = mapper;
        }
        public CommandResponse<AddItemResponse> AddItem(Item item)
        {
            CommandResponse<AddItemResponse> response = new CommandResponse<AddItemResponse>()
                                                    {
                                                        Success = true
                                                    };

            AddItemResponse addItemResponse = new AddItemResponse();

            try
            {
                // 1. da li je klijent postoji
                int? clientId = _clientService.GetClientId(item.Client.Email);

                // 2. ako ne postoji, uneti ga
                if (clientId == null)
                {
                    AddClientRequest clientRequest = _mapper.Map<AddClientRequest>(item.Client);
                    clientId = _clientService.AddClient(clientRequest);
                }
                // 3. uneti uredjaj
                AddDeviceRequest addDeviceRequest = _mapper.Map<AddDeviceRequest>(item.Device);
                addDeviceRequest.ClientId = clientId.Value;
                addItemResponse.Id = _deviceService.AddDevice(addDeviceRequest);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}