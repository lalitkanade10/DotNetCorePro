﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBookAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int bookId, BookModel bookModel);

        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);

        Task DeleteBookAsync(int BookId);
    }
}
