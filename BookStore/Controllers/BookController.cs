using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        private readonly LanguageRepository languageRepository = null;

        public BookController(BookRepository BookRepository, LanguageRepository LanguageRepository)
        {
            bookRepository = BookRepository;
            languageRepository = LanguageRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooks();
            return View(books);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await bookRepository.GetBookById(id);

            return View(data);

        }
        public async Task<ViewResult>  AddBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();
            ViewBag.languages = new SelectList( await languageRepository.GetLanguages(),"Id","Name");
        
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.languages = new SelectList(await languageRepository.GetLanguages(), "Id", "Name");
            ViewBag.IsSuccess = false;
            ViewBag.BookId = 0;

            return View();
        }
        public ViewResult SearchBook(string bookName, string authorName)
        {
            var SearchedBook = bookRepository.SearchBook(bookName, authorName);
            return View(SearchedBook);
        }
      
    }
}
