using System.Collections;
using System.Collections.Generic;
using API.DTOs;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/books")]
    [ApiController]

    public class BooksController : ControllerBase {
        private readonly IApiRepo repository;
        //private readonly IMapper mapper;
        public BooksController(IApiRepo repo, IMapper map){
            repository = repo;
            //mapper = map;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetAllBooks()
        {
            var booksList = repository.GetAllBooks();
            var bookDtos = new List<BookReadDto>();

            foreach (var book in booksList)
            {
                var bookDto = new BookReadDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Status = book.Status,
                    Rating = book.Rating,
                    Page = book.Page
                };
                bookDtos.Add(bookDto);
            }

            return Ok(bookDtos);
        }

        [HttpGet("{id}", Name ="GetBookById")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var book = repository.GetBookById(id);
            if (book != null)
            {
                var bookDto = new BookReadDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Status = book.Status,
                    Rating = book.Rating,
                    Page = book.Page
                };
                return Ok(bookDto);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Book> AddBook(BookWriteDto bookWriteDto)
        {
            var book = new Book
            {
                Title = bookWriteDto.Title,
                Author = bookWriteDto.Author,
                Status = bookWriteDto.Status,
                Rating = bookWriteDto.Rating,
                Page = bookWriteDto.Page
            };

            repository.AddBook(book);
            repository.SaveChanges();

            return CreatedAtRoute(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, BookUpdateDto bookUpdateDto)
        {
            var bookInRepo = repository.GetBookById(id);
            if (bookInRepo == null)
            {
                return NotFound();
            }

            bookInRepo.Title = bookUpdateDto.Title;
            bookInRepo.Author = bookUpdateDto.Author;
            bookInRepo.Status = bookUpdateDto.Status;
            bookInRepo.Page = bookUpdateDto.Page;
            bookInRepo.Rating = bookUpdateDto.Rating;

            repository.UpdateBook(bookInRepo);
            repository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int ID){
            var book = repository.GetBookById(ID);
            if(book == null){
                return NotFound();
            }

            repository.DeleteBook(book);
            repository.SaveChanges();
            return Ok();
        }
    }
}