using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace SiReCRUD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private static List<Book> books = new List<Book>()
        {
            new Book("It", "Devin Mcquire", 150, 1000000000001),
            new Book("De Vises Sten", "J K Rowling", 320, 1000000000002),
            new Book("Mit Liv", "Bill Clinton", 400, 1000000000003),
            new Book("Fall of Giants", "Ken Follett", 900, 1000000000004)
        };

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET: api/Books/5
        [HttpGet("{ISBN13}", Name = "Get")]
        public Book Get(long ISBN13)
        {
            return books.Find(i => i.ISBN13 == ISBN13);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut("{ISBN13}")]
        public void Put(long ISBN13, [FromBody] Book value)
        {
            Book book = Get(ISBN13);
            if (book != null)
            {
                book.ISBN13 = value.ISBN13;
                book.Title = value.Title;
                book.Author = value.Author;
                book.PageNr = value.PageNr;
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{ISBN13}")]
        public void Delete(long ISBN13)
        {
            Book book = Get(ISBN13);
            books.Remove(book);
        }
    }
}
