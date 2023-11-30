using Job_Portal_System.Model;
using Job_Portal_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _IUserRepository;
        private readonly ILogger<UserController> _Logger;
        public UserController(IUserRepository iUserRepository, ILogger<UserController> logger)
        {
            _IUserRepository = iUserRepository;
            _Logger = logger;
        }
        [HttpPost("User Creation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult InsertUser(UserModel userModel)
        {
            _IUserRepository.Insert(userModel);
            _Logger.LogError("Something went wrong");
            return Ok();
    
        }
        [HttpPut("User Updation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(UserModel userModel)
        {
            _IUserRepository.Update(userModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpGet("List of Jobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetJob()
        {
            var test = _IUserRepository.GetJob();
            if (!test.Any())
            {
                _Logger.LogError("No Items Present");
                return NotFound("No items");
            }
            return Ok(test);
        }
        [HttpGet("Applied Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetApplied(long userId)
        {
            var test = _IUserRepository.GetApplied(userId);
            if (!test.Any())
            {
                _Logger.LogError("No ID Present");
                return NotFound("No ID Present");
            }
            _Logger.LogInformation($"The ID is Not found");
            return Ok(test);
        }
      
    }
}
