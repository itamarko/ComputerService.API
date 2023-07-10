using ComputerService.BusinessModel;

namespace ComputerService.BusinessLogic.Interfaces
{
    public interface IDeviceBL
    {
        CommandResponse<AddItemResponse> AddItem(Item item);
    }
}