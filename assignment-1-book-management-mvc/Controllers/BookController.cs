using assignment_1_book_management_mvc.Repository;
using assignment_1_book_management_mvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assignment_1_book_management_mvc.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var bookRepository = new BookRepository();
            var books = bookRepository.GetBooks();
            List<BookViewModel> bookList = new List<BookViewModel>();
            foreach (var book in books)
            {
                var bookViewModel = new BookViewModel();
                bookViewModel.Id = book.Id;
                bookViewModel.Title = book.Title;
                bookViewModel.Author = book.Author;
                bookViewModel.Rating = Convert.ToInt32(book.Rating);
                bookViewModel.Price = Convert.ToInt32(book.Price);
                bookList.Add(bookViewModel);

            };
            return View(bookList);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                var bookRepository = new BookRepository();
                var book = new Book
                {
                    Title = createViewModel.Title,
                    Author = createViewModel.Author,
                    Rating = createViewModel.Rating,
                    Price = createViewModel.Price
                };

                bool isBookAdded = bookRepository.AddBook(book);

                if (isBookAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(createViewModel);

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bookRepository = new BookRepository();
            var book = bookRepository.GetBookById(id);
            var deleteViewModel = new DeleteViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author =book.Author,
                Rating = Convert.ToInt32(book.Rating),
                Price = Convert.ToInt32(book.Price),
            };
            return View(deleteViewModel);
        }
        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var bookRepository = new BookRepository();
            bookRepository.DeleteBook(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bookRepository = new BookRepository();
            var book = bookRepository.GetBookById(id);
            var editViewModel = new EditViewModel
            {
                Title = book.Title,
                Author = book.Author,
                Rating = Convert.ToInt32(book.Rating),
                Price = Convert.ToInt32(book.Price),
            };
            return View(editViewModel);
        }
        [HttpPost]
        [ActionName("Edit")]

        public ActionResult EditBook(int id, EditViewModel editViewModel)
        {
            var bookRepository = new BookRepository();
            Book book = new Book
            {
                Title = editViewModel.Title,
                Author = editViewModel.Author,
                Rating = editViewModel.Rating,
                Price = editViewModel.Price

            };
            bookRepository.UpdateBook(id, book);
            return RedirectToAction("Index");
        }





    }
}