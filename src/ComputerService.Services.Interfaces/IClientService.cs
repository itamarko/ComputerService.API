using ComputerService.DataModel.Client;

namespace ComputerService.Services.Interfaces
{
    public interface IClientService
    {
        int AddClient(AddClientRequest client);

        bool ClientExists(string email);
    }
}