using ComputerService.BusinessLogic.Interfaces;
using ComputerService.BusinessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceBL _deviceBL;

        public DeviceController(IDeviceBL deviceBL)
        {
            _deviceBL = deviceBL;
        }

        [HttpPost]
        public ActionResult<CommandResponse<AddItemResponse>> Post(Item item)
        {
            CommandResponse<AddItemResponse> result = new CommandResponse<AddItemResponse>();
            try
            {
                result = _deviceBL.AddItem(item);
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;   
            }

            return Ok(result);
        }
    }
}
