using OnlineLibraryMS2.Models.Context;
using OnlineLibraryMS2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineLibraryMS2.Controllers
{
    public class BorrowsController : Controller
    {
        public JsonResult BorrowBook(tbl_borrows_models borrow)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var book = db.tbl_books.Find(borrow.BookID);
                    if (book == null)
                        return Json(new { success = false, message = "Book not found" });

                    if (book.Status == "Borrowed")
                        return Json(new { success = false, message = "Book is already borrowed" });

                    borrow.BorrowDate = DateTime.Now;
                    borrow.DueDate = DateTime.Now.AddDays(7);
                    borrow.Status = "Borrowed";
                    db.tbl_borrows.Add(borrow);

                    book.Status = "Borrowed";
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Book borrowed successfully! Please return within 7 days." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public JsonResult ReturnBook(int BookID, int UserID)
        {
            try
            {
                using (var db = new LibraryContext())
                {
                    var book = db.tbl_books.Find(BookID);
                    if (book == null)
                        return Json(new { success = false, message = "Book not found" });

                    if (UserID == 0)
                    {
                        var activeBorrow = db.tbl_borrows.FirstOrDefault(b =>
                            b.BookID == BookID && b.Status == "Borrowed");

                        if (activeBorrow != null)
                        {
                            activeBorrow.ReturnDate = DateTime.Now;
                            activeBorrow.Status = "Returned";
                        }

                        book.Status = "Available";
                        db.SaveChanges();

                        return Json(new { success = true, message = "Book returned successfully!" });
                    }

                    var borrow = db.tbl_borrows.FirstOrDefault(b =>
                        b.BookID == BookID &&
                        b.UserID == UserID &&
                        b.Status == "Borrowed");

                    if (borrow == null)
                        return Json(new { success = false, message = "No active borrow record found" });

                    borrow.ReturnDate = DateTime.Now;
                    borrow.Status = "Returned";
                    book.Status = "Available";
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Book returned successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public JsonResult GetMyBorrows(int userID)
        {
            using (var db = new LibraryContext())
            {
                var myBorrows = db.tbl_borrows
                    .Where(b => b.UserID == userID && b.Status == "Borrowed")
                    .Select(b => new { b.BookID })
                    .ToList();
                return Json(myBorrows, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetMonthlyActivity()
        {
            using (var db = new LibraryContext())
            {
                var labels = new List<string>();
                var borrows = new List<int>();
                var returns = new List<int>();

                for (int i = 5; i >= 0; i--)
                {
                    var month = DateTime.Today.AddMonths(-i);
                    labels.Add(month.ToString("MMM"));

                    var borrowCount = db.tbl_borrows.Count(b =>
                        b.BorrowDate.HasValue &&
                        b.BorrowDate.Value.Year == month.Year &&
                        b.BorrowDate.Value.Month == month.Month);

                    var returnCount = db.tbl_borrows.Count(b =>
                        b.ReturnDate.HasValue &&
                        b.ReturnDate.Value.Year == month.Year &&
                        b.ReturnDate.Value.Month == month.Month);

                    borrows.Add(borrowCount);
                    returns.Add(returnCount);
                }

                return Json(new { labels, borrows, returns }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetWeeklyActivity()
        {
            using (var db = new LibraryContext())
            {
                var labels = new List<string>();
                var borrows = new List<int>();
                var returns = new List<int>();

                for (int i = 5; i >= 0; i--)
                {
                    var weekStart = DateTime.Today.AddDays(-(i * 7));
                    var weekEnd = weekStart.AddDays(7);
                    labels.Add("Week " + (6 - i));

                    var borrowCount = db.tbl_borrows.Count(b =>
                        b.BorrowDate.HasValue &&
                        b.BorrowDate.Value >= weekStart &&
                        b.BorrowDate.Value < weekEnd);

                    var returnCount = db.tbl_borrows.Count(b =>
                        b.ReturnDate.HasValue &&
                        b.ReturnDate.Value >= weekStart &&
                        b.ReturnDate.Value < weekEnd);

                    borrows.Add(borrowCount);
                    returns.Add(returnCount);
                }

                return Json(new { labels, borrows, returns }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCategoryStats()
        {
            using (var db = new LibraryContext())
            {
                var result = db.tbl_books
                    .Where(b => b.CategoryID.HasValue)
                    .GroupBy(b => b.CategoryID)
                    .Select(g => new {
                        CategoryID = g.Key,
                        Count = g.Count()
                    }).ToList();

                var categories = db.tbl_categories.ToList();

                var data = result.Select(r => new {
                    label = categories.FirstOrDefault(c => c.CategoryID == r.CategoryID) != null
                        ? categories.First(c => c.CategoryID == r.CategoryID).CategoryName
                        : "Unknown",
                    count = r.Count
                }).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}