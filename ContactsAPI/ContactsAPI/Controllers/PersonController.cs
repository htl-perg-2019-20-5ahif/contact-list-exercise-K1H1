using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContactsAPI.Controllers
{
	[ApiController]
	[Route("contacts")]
	public class PersonController : ControllerBase
	{
		private static readonly List<Person> persons = new List<Person>();

		//get all persons
		[HttpGet]
		public IActionResult GetAllPersons()
		{
			return Ok(persons);
		}

		// add a person
		[HttpPost]
		public IActionResult AddItem([FromBody] Person newPerson)
		{

			if( newPerson.Id == null || newPerson.Email == null || newPerson.Email == " ")
			{
				return BadRequest("Invalid input(e.g.required field missing or empty");
			}

			persons.Add(newPerson);
			return Ok(newPerson);


		}

		//delete person with id
		[HttpDelete]
        [Route("{index}")]
		public IActionResult DeletePerson(int index)
		{

			if (index >= 0 && index <= persons.Count)
			{
				persons.RemoveAt(index);
				return NoContent();
			}
			else
			{
				return NotFound();
			}

			return BadRequest("Invalid index");
		}

		//find by name
		[HttpGet]
		[Route("{name}", Name = "GetSpecificItem")]
		public IActionResult GetContact(string name)
		{

			if (name != null || name != "")
			{
				foreach (Person p in persons)
				{
					if (p.FirstName.Equals(name) || p.LastName.Equals(name))
					{
						return Ok(p);
					}
				}

			}

			return BadRequest("Invalid index");
		}

	
	


	}
}
