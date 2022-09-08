using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStore.Models.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration _configuration = null;

        public BookRepository(BookStoreContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                Pages = model.Pages.HasValue ? model.Pages.Value : 0,
                Category = model.Category,
                LanguageId = model.LanguageId,
                CoverImgPath = model.CoverImgPath,
                BookPDFURL = model.BookPDFURL,

            };
            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Title = book.Title,
                Pages = book.Pages,
                CoverImgPath = book.CoverImgPath

            }).ToListAsync();
        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    Pages = book.Pages,
                    CoverImgPath = book.CoverImgPath,
                    Gallery = book.bookGallery.Select(g => new GalleryModel()
                    {
                        id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookPDFURL = book.BookPDFURL,


                }).FirstOrDefaultAsync();
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                Title = book.Title,
                Pages = book.Pages,
                CoverImgPath = book.CoverImgPath

            }).Take(count).ToListAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }
        public string GetAppName()
        {
            return _configuration["AppName"];
        }

    }
}
