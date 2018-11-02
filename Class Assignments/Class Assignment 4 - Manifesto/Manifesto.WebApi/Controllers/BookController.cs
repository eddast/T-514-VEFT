using Microsoft.AspNetCore.Mvc;
using Manifesto.Models.InputModels;
using Manifesto.Service;
using System;

namespace Manifesto.WebApi.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly BookService _bookService = new BookService();

        // http://localhost:5000/api/books [GET]
        [HttpGet] 
        [Route("")]
        public IActionResult GetAllBooks([FromQuery] string category)
        {
            return Ok(_bookService.GetAllBooks(category));
        }

        // http://localhost:5000/api/books/{id} [GET]
        [HttpGet]
        [Route("{id:int}", Name = "GetBookById")]
        public IActionResult GetBookById(int id)
        {
            try {
                return Ok(_bookService.GetBookById(id));
            } catch (Exception e) {
                return NotFound(e.Message);
            }
        }

        // http://localhost:5000/api/books [POST]
        [HttpPost]
        [Route("")]
        public IActionResult CreateBook([FromBody] BookInputModel book)
        {
            if (!ModelState.IsValid) { return StatusCode(412, book); }
            var id = _bookService.CreateBook(book);

            return CreatedAtRoute("GetBookById", new { id }, null);
        }

        // http://localhost:5000/api/books/{id} [PUT]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookInputModel book)
        {
            if (!ModelState.IsValid) { return StatusCode(412, book); }
            try {
                _bookService.UpdateBookById(book, id);
            } catch (Exception e) {
                return NotFound(e.Message);
            }

            return NoContent();
        }

        // http://localhost:5000/api/books/{id} [DELETE]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBookById(int id)
        {
            try {
                _bookService.DeleteBookById(id);
            } catch (Exception e) {
                return NotFound(e.Message);
            }
            
            
            return NoContent();
        }
    }
}