using Job_Portal_System.Model;
using Job_Portal_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _IAdminRepository;
        private readonly ILogger<AdminController> _Logger;
        public AdminController(IAdminRepository iAdminRepository, ILogger<AdminController> logger)
        {
            _IAdminRepository = iAdminRepository;
            _Logger = logger;
        }
        [HttpPost("User Creation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult InsertUser(UserModel userModel)
        {
            _IAdminRepository.Insert(userModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpPut("User Updation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser(UserModel userModel)
        {
            _IAdminRepository.Update(userModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpPost("HR Creation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult InsertHR(HRModel hrModel)
        {
            _IAdminRepository.Insert(hrModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpPut("HR Updation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateHR(HRModel hrModel)
        {
            _IAdminRepository.Update(hrModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpGet("Applied Summary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var test = _IAdminRepository.get();
            if (!test.Any())
            {
                _Logger.LogError("No Items Present");
                return NotFound("No items");
            }
            return Ok(test);
        }
        [HttpGet("List of Users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       // [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser()
        {
            var test = _IAdminRepository.GetUser();
            /*if (!test.Any())
            {
                _Logger.LogError("No Items Present");
                return NotFound("No items");
            }*/
            return Ok(test);
        }
        [HttpGet("List of HR")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetHR()
        {
            var test = _IAdminRepository.GetHR();
            if (!test.Any())
            {
                _Logger.LogError("No Items Present");
                return NotFound("No items");
            }
            return Ok(test);
        }
        [HttpGet("List of Jobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetJob()
        {
            var test = _IAdminRepository.GetJob();
            if (!test.Any())
            {
                _Logger.LogError("No Items Present");
                return NotFound("No items");
            }
            return Ok(test);
        }
    }
}
