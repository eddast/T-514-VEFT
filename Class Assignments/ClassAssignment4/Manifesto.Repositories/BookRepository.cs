using System.Collections.Generic;
using System.Linq;
using Manifesto.Models.DTOs;
using Manifesto.Models.InputModels;
using Manifesto.Models.Entities;
using System;
using AutoMapper;

namespace Manifesto.Repositories
{
    public class BookRepository
    {
        private readonly BookDbContext _bookDbContext = new BookDbContext();
        public IEnumerable<BookDTO> GetAllBooks(string category)
        {
            return Mapper.Map<IEnumerable<BookDTO>>(_bookDbContext.Books.ToList());
        }
        public BookDetailsDTO GetBookById(int id)
        {
            return Mapper.Map<BookDetailsDTO>(_bookDbContext.Books.FirstOrDefault(b => b.Id == id));
        }
        public int CreateBook(BookInputModel book)
        {
            var nextId = _bookDbContext.Books.Count() - 1;
            var entity = Mapper.Map<Book>(book);
            _bookDbContext.Books.Add(entity);
            _bookDbContext.SaveChanges();
            return nextId;
        }
        public void UpdateBookById(BookInputModel book, int id)
        {
            var updateBook = _bookDbContext.Books.ToList().FirstOrDefault(r => r.Id == id);
            if(updateBook == null) return;
            
            updateBook.Name = book.Name;
            updateBook.Author = book.Author;
            updateBook.Description = book.Description;
            updateBook.ImageUrl = book.ImageUrl;
            updateBook.Isbn = book.Isbn;
            updateBook.Category = book.Category;
            updateBook.Pages = book.Pages;
            updateBook.ModifiedOn = DateTime.Now;
        }
        public void DeleteBookById(int id)
        {
            var deleteBook = Mapper.Map<Book>(_bookDbContext.Books.ToList().FirstOrDefault(b => b.Id == id));
            _bookDbContext.Books.Remove(Mapper.Map<Book>(deleteBook));
            _bookDbContext.SaveChanges();
        }
    }
}