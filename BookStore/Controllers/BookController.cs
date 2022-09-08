using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository = null;
        private readonly ILanguageRepository languageRepository = null;
        private readonly IWebHostEnvironment webHostEnviroment = null;

        public BookController(IBookRepository BookRepository,
            ILanguageRepository LanguageRepository,
            IWebHostEnvironment WebHostEnviroment)
        {
            bookRepository = BookRepository;
            languageRepository = LanguageRepository;
            webHostEnviroment = WebHostEnviroment;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooks();
            return View(books);
        }
        [Route("book-details/{id:int:min(1)}",Name = "BookdetailRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await bookRepository.GetBookById(id);

            return View(data);

        }
        public async Task<ViewResult> AddBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string bookCoverPhotoFldr = "Books/CoverPhoto/";
                    bookModel.CoverImgPath = await UploadFile(bookCoverPhotoFldr, bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string bookGalleryPhotoFldr = "Books/Gallery/";

                    bookModel.Gallery = new List<GalleryModel>();


                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadFile(bookGalleryPhotoFldr, file),
                        };
                        bookModel.Gallery.Add(gallery);

                    }

                }
                if (bookModel.BookPDF != null)
                {
                    string bookPDFFldr = "Books/PDF/";
                    bookModel.BookPDFURL = await UploadFile(bookPDFFldr, bookModel.BookPDF);
                }

                int id = await bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = id });
                }
            }
           
            ViewBag.IsSuccess = true;
            ViewBag.BookId = 0;

            return View();
        }

        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            //bookModel.CoverImgPath = bookCoverPhotoFldr;


            string serverFolder = Path.Combine(webHostEnviroment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public ViewResult SearchBook(string bookName, string authorName)
        {
            var SearchedBook = bookRepository.SearchBook(bookName, authorName);
            return View(SearchedBook);
        }

    }
}
