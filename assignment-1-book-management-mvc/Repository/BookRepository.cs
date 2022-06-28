using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assignment_1_book_management_mvc.Repository
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            List<Book> books = null;
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                books = new List<Book>();
                books = bookDBEntities.Books.ToList();
            }

            return books;
        }
        public bool AddBook(Book book)
        {
            bool isBookAdded = false;
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                bookDBEntities.Books.Add(book);
                bookDBEntities.SaveChanges();
                isBookAdded = true;
            }
            return isBookAdded;
        }
        public Book GetBookById(int id)
        {
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                var existingBook = bookDBEntities.Books.FirstOrDefault(x => x.Id == id);
                return existingBook;
            }

        }
        public void DeleteBook(int id)
        {
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                var existingBook = bookDBEntities.Books.FirstOrDefault(x => x.Id == id);
                bookDBEntities.Books.Remove(existingBook);
                bookDBEntities.SaveChanges();
            }
        }
        public void UpdateBook(int id, Book book)
        {
            using (BookDBEntities bookDBEntities = new BookDBEntities())
            {
                var existingBook = bookDBEntities.Books.FirstOrDefault(x => x.Id == id);
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Rating = book.Rating;
                existingBook.Price = book.Price;
                bookDBEntities.SaveChanges();
            }

        }





    }
}