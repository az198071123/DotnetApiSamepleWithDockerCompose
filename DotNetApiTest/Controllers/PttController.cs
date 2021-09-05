using System.Collections.Generic;
using DotNetApiTest.Models;
using DotNetApiTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PttController : ControllerBase
    {
        private readonly PttService _bookService;

        public PttController(PttService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Articles>> Get()
        {
            // return _bookService.GetFirst();
            return _bookService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Articles> Get(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }


        // [HttpGet("/first")]
        // public ActionResult<Articles> GetFirst()
        // {
        //     return _bookService.GetFirst();
        // }

        [HttpPost]
        public ActionResult<Articles> Create(Articles book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Articles bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}