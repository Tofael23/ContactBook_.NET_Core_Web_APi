using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PersonController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonContact>>>  GetContact()
        {
            return await _appDbContext.PersonContacts.ToListAsync();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> ContactEntry(PersonContact personContact)
        {
             _appDbContext.PersonContacts.Add(personContact);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction("GetContact",new {id=personContact.ContactId },personContact);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, PersonContact personContact)
        {
            personContact.ContactId = id;
            _appDbContext.Entry(personContact).State = EntityState.Modified;
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonContact>> DeleteContact(int id)
        {
            var person = await _appDbContext.PersonContacts.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _appDbContext.PersonContacts.Remove(person);
            await _appDbContext.SaveChangesAsync();
            return person;
        }
    }
}
