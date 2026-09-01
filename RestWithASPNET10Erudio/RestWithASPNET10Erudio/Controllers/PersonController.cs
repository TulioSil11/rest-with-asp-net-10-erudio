using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Models;
using RestWithASPNET10Erudio.Models.DTOs;
using RestWithASPNET10Erudio.Service;

namespace RestWithASPNET10Erudio.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;
		private readonly ILogger<PersonController> _logger;

		public PersonController(
			IPersonService personService,
			ILogger<PersonController> logger)
		{
			_personService = personService;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<PersonDTO>))]
		[ProducesResponseType(500)]
		public IActionResult GetAll()
		{
			try
			{
				_logger.LogInformation(
					"GET /Person started. StatusCode: {StatusCode}",
					StatusCodes.Status200OK);

				var people = _personService.GetAll();

				_logger.LogInformation(
					"GET /Person completed successfully. StatusCode: {StatusCode}",
					StatusCodes.Status200OK);

				return Ok(people);
			}
			catch (Exception ex)
			{
				_logger.LogError(
					ex,
					"GET /Person failed. StatusCode: {StatusCode}",
					StatusCodes.Status500InternalServerError);

				return StatusCode(
					StatusCodes.Status500InternalServerError,
					"An unexpected error occurred while retrieving people.");
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(PersonDTO))]
		[ProducesResponseType(500)]
		[ProducesResponseType(404)]
		public IActionResult GetById(Guid id)
		{
			try
			{
				_logger.LogInformation(
					"GET /Person/{PersonId} started.",
					id);

				var person = _personService.GetById(id);

				if (person == null)
				{
					_logger.LogWarning(
						"Person not found. PersonId: {PersonId}. StatusCode: {StatusCode}",
						id,
						StatusCodes.Status404NotFound);

					return NotFound();
				}

				_logger.LogInformation(
					"GET /Person/{PersonId} completed successfully. StatusCode: {StatusCode}",
					id,
					StatusCodes.Status200OK);

				return Ok(person);
			}
			catch (Exception ex)
			{
				_logger.LogError(
					ex,
					"GET /Person/{PersonId} failed. StatusCode: {StatusCode}",
					id,
					StatusCodes.Status500InternalServerError);

				return StatusCode(
					StatusCodes.Status500InternalServerError,
					"An unexpected error occurred while retrieving the person.");
			}
		}

		[HttpPost]
		[ProducesResponseType(201, Type = typeof(PersonDTO))]
		[ProducesResponseType(500)]
		public IActionResult Create([FromBody] PersonDTO person)
		{
			try
			{
				_logger.LogInformation(
					"POST /Person started.");

				_personService.Create(person);

				_logger.LogInformation(
					"Person created successfully. PersonId: {PersonId}. StatusCode: {StatusCode}",
					person.Id,
					StatusCodes.Status201Created);

				return StatusCode(
					StatusCodes.Status201Created,
					person);
			}
			catch (Exception ex)
			{
				_logger.LogError(
					ex,
					"POST /Person failed. StatusCode: {StatusCode}",
					StatusCodes.Status500InternalServerError);

				return StatusCode(
					StatusCodes.Status500InternalServerError,
					"An unexpected error occurred while creating the person.");
			}
		}

		[HttpPut]
		[ProducesResponseType(200, Type = typeof(PersonDTO))]
		[ProducesResponseType(500)]
		public IActionResult Update([FromBody] PersonDTO person)
		{
			try
			{
				_logger.LogInformation(
					"PUT /Person started. PersonId: {PersonId}",
					person.Id);

				_personService.Update(person);

				_logger.LogInformation(
					"Person updated successfully. PersonId: {PersonId}. StatusCode: {StatusCode}",
					person.Id,
					StatusCodes.Status200OK);

				return Ok(person);
			}
			catch (Exception ex)
			{
				_logger.LogError(
					ex,
					"PUT /Person failed. PersonId: {PersonId}. StatusCode: {StatusCode}",
					person.Id,
					StatusCodes.Status500InternalServerError);

				return StatusCode(
					StatusCodes.Status500InternalServerError,
					"An unexpected error occurred while updating the person.");
			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200, Type = typeof(PersonDTO))]
		[ProducesResponseType(500)]
		public IActionResult Delete(Guid id)
		{
			try
			{
				_logger.LogInformation(
					"DELETE /Person/{PersonId} started.",
					id);

				_personService.Delete(id);

				_logger.LogInformation(
					"Person deleted successfully. PersonId: {PersonId}. StatusCode: {StatusCode}",
					id,
					StatusCodes.Status200OK);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError(
					ex,
					"DELETE /Person/{PersonId} failed. StatusCode: {StatusCode}",
					id,
					StatusCodes.Status500InternalServerError);

				return StatusCode(
					StatusCodes.Status500InternalServerError,
					"An unexpected error occurred while deleting the person.");
			}
		}
	}
}