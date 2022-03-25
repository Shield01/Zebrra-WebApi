using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zebrra_WebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zebrra_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BooksController(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        // GET: api/<BooksControllers>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var result = applicationDbContext.Books;

            return Ok(result);
        }

        // GET api/<BooksControllers>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var result = applicationDbContext.Books.FirstOrDefault(x => x.Id == id);

            return Ok(result);
        }

        // POST api/<BooksControllers>
        [HttpPost]
        public ActionResult CreateBooks([FromBody] Book value)
        {
            applicationDbContext.Add(value);

            applicationDbContext.SaveChanges();

            return Ok(value);
        }

        // PUT api/<BooksControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
