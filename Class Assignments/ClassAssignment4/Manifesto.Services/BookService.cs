using Manifesto.Models.DTOs;
using Manifesto.Models.InputModels;
using Manifesto.Repositories;
using System;
using System.Collections.Generic;

namespace Manifesto.Service
{
    public class BookService
    {
    
        private readonly BookRepository _bookRepository = new BookRepository();
        public int CreateBook(BookInputModel book)
        {
            return _bookRepository.CreateBook(book);
        }
        public void DeleteBookById(int id)
        {
            var entity = _bookRepository.GetBookById(id);
            if(entity == null) { throw new Exception($"Book with id {id} was not found."); }
            _bookRepository.DeleteBookById(id);
        }
        public IEnumerable<BookDTO> GetAllBooks(string category)
        {
            return _bookRepository.GetAllBooks(category);
        }
        public BookDetailsDTO GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if(book == null) { throw new Exception($"Book with id {id} was not found"); }

            return book;
        }
        public void UpdateBookById(BookInputModel book, int id)
        {
            var entity = _bookRepository.GetBookById(id);
            if(entity == null) { throw new Exception($"Book with id {id} was not found"); }
            _bookRepository.UpdateBookById(book, id);
        }
    }
}