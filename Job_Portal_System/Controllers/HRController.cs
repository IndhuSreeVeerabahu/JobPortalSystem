using Job_Portal_System.Model;
using Job_Portal_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HRController : Controller
    {
        private readonly IHRRepository _IHRRepository;
        private readonly ILogger<HRController> _Logger;
        public HRController(IHRRepository iHRRepository, ILogger<HRController> logger)
        {
            _IHRRepository = iHRRepository;
            _Logger = logger;
        }
        [HttpPost("Job Creation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Insert(JobModel jobModel)
        {
            _IHRRepository.Insert(jobModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpPut("Job Updation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateJob(JobModel jobModel)
        {
            _IHRRepository.UpdateJob(jobModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpPut("HR Updation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateHR(HRModel hrModel)
        {
            _IHRRepository.UpdateHR(hrModel);
            _Logger.LogError("Something went wrong");
            return Ok();

        }
        [HttpGet("Applied Details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       // [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(long HRId)
        {
            var test = _IHRRepository.Get(HRId);
           /* if (!test.Any())
            {
                _Logger.LogError("No Items Present");
                return NotFound("No items");
            }*/
            return Ok(test);
        }


    }
}
