using Dapper_Contrib.Models;
using Dapper_Contrib.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SchoolController : ControllerBase
	{
		private readonly ISchoolService _schoolService;

		public SchoolController(ISchoolService schoolService)
		{
			_schoolService = schoolService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<School>> Get(int id)
		{
			var school = await _schoolService.GetByIdAsync(id);
			if (school == null)
			{
				return NotFound();
			}
			return Ok(school);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<School>>> GetAll()
		{
			var schools = await _schoolService.GetAllAsync();
			return Ok(schools);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] School school)
		{
			await _schoolService.InsertAsync(school);
			return CreatedAtAction(nameof(Get), new { id = school.School_Id }, school);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] School school)
		{
			if (id != school.School_Id)
			{
				return BadRequest();
			}
			await _schoolService.UpdateAsync(school);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _schoolService.DeleteAsync(id);
			return NoContent();
		}
	}
}
