using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Model;
using Practice.Services;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        private readonly IPracticeService _pracService;

        public PracticeController(IPracticeService pracService)
        {
            _pracService = pracService;
        }

        // OurHeroService.cs

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_pracService.GetAllPrac(isActive));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var hero = _pracService.GetPractice(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post(update_practice pracObject)
        {
            var prac = _pracService.AddPractice(pracObject);

            if (prac == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Data Created Successfully!!!",
                id = prac!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] update_practice pracObject)
        {
            var prac = _pracService.UpdatePractice(id, pracObject);
            if (prac == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Data Updated Successfully!!!",
                id = prac!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_pracService.DeletePractice(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Data Deleted Successfully!!!",
                id = id
            });
        }
    }
}
