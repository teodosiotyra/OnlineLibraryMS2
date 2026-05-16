using OnlineLibraryMS2.Models.Context;
using OnlineLibraryMS2.Models.Tables;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OnlineLibraryMS2.Controllers
{
    public class BooksController : Controller
    {
        public JsonResult GetBooks()
        {
            using (var db = new LibraryContext())
            {
                var books = db.tbl_books.ToList().Select(b => new {
                    b.BookID,
                    b.Title,
                    b.Author,
                    b.CategoryID,
                    b.Status
                });
                return Json(books, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetStats()
        {
            using (var db = new LibraryContext())
            {
                int total = db.tbl_books.Count();
                int borrowed = db.tbl_books.Count(b => b.Status == "Borrowed");
                int available = db.tbl_books.Count(b => b.Status == "Available");
                return Json(new { total, borrowed, available }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddBook(tbl_books_models book)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    book.Status = "Available";
                    book.DateAdded = DateTime.Now;
                    db.tbl_books.Add(book);
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Book added successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult EditBook(tbl_books_models book)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var existing = db.tbl_books.Find(book.BookID);
                    if (existing == null)
                        return Json(new { success = false, message = "Book not found" });

                    existing.Title = book.Title;
                    existing.Author = book.Author;
                    existing.CategoryID = book.CategoryID;
                    existing.Status = book.Status;
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Book updated successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult Edit(tbl_books_models book)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var existing = db.tbl_books.Find(book.BookID);
                    if (existing == null)
                        return Json(new { success = false, message = "Book not found" });

                    if (!string.IsNullOrEmpty(book.Title))
                        existing.Title = book.Title;

                    if (!string.IsNullOrEmpty(book.Author))
                        existing.Author = book.Author;

                    if (!string.IsNullOrEmpty(book.Status))
                        existing.Status = book.Status;

                    if (book.CategoryID.HasValue)
                        existing.CategoryID = book.CategoryID;

                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Book updated successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteBook(int id)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var book = db.tbl_books.Find(id);
                    if (book == null)
                        return Json(new { success = false, message = "Book not found" });

                    db.tbl_books.Remove(book);
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Book deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}