using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Data.Repository;
using TaskManager.API.Models;
using TaskManager.API.Models.InputModels;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var response = _activityRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _activityRepository.Get(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] InputActivity inputActivity)
        {
            var activity = new Activity(inputActivity.Name, inputActivity.Detail);
            _activityRepository.Add(activity);
            return Created("", activity);
        }

        [HttpPut()]
        public IActionResult Put(string id, [FromBody] InputActivity inputActivity)
        {
            var activity = _activityRepository.Get(id);

            if (activity == null)
                return NotFound();

            activity.UpdateActivity(inputActivity.Name, inputActivity.Detail, inputActivity.IsCompleted);

            _activityRepository.Update(id.ToString(), activity);

            return Ok(activity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var activity = _activityRepository.Get(id);
            if (activity == null)
                return NotFound();

            _activityRepository.Delete(id.ToString());

            return Ok();
        }
    }
}