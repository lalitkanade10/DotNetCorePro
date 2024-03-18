using BookStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

using AutoMapper;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        public readonly BookStoreContext _context;
        public readonly IMapper _mapper;
        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBookAsync()
        {
            //var records = await _context.Books.Select(x=> new BookModel()
            //{
            //   Id=x.Id,
            //   Title=x.Title,
            //   Descriptions=x.Descriptions
            //}).ToListAsync();

            //return records;

            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var records = await _context.Books.Where(x=> x.Id==bookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Descriptions = x.Descriptions
            //}).FirstOrDefaultAsync();

            //return records;

            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Descriptions = bookModel.Descriptions
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId,BookModel bookModel)
        {
            var book = new Books()
            {
                Id=bookId,
                Title = bookModel.Title,
                Descriptions = bookModel.Descriptions
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book !=null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int BookId)
        {
            var book = new Books()
            {
               Id=BookId
            };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();           
        }

    }
}
