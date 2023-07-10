using ComputerService.DataModel.Client;

namespace ComputerService.Services.Interfaces
{
    public interface IClientService
    {
        int AddClient(AddClientRequest client);

        int? GetClientId(string email);
    }
}