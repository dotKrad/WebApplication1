using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly SampleDBContext _dataContext;

        public DeviceController(SampleDBContext _context)
        {
            _dataContext = _context;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Device> Get()
        {
            return _dataContext.Devices.ToArray();
        }

        [HttpPost]
        public string Register(string deviceId)
        {

            return string.Empty;
        }

        [HttpPost]
        public IActionResult SignIn()
        {

            return Ok();
        }
    }
}
