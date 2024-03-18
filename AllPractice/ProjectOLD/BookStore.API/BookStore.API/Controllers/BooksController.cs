using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Repository;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        public readonly IBookRepository _BookRepository;
        public BooksController(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books =await _BookRepository.GetAllBookAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooksById([FromRoute]int id)
        {
            var book = await _BookRepository.GetBookByIdAsync(id);
            if(book==null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var id = await _BookRepository.AddBookAsync(bookModel);

            // return created id 
            // here we are passing the created ID to GetBooksById action method
            return CreatedAtAction(nameof(GetBooksById), new { id = id, controller = "books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel,[FromRoute]int id)
        {
            await _BookRepository.UpdateBookAsync(id,bookModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await _BookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _BookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
