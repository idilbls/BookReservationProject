using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookReservationProject.Data;
using BookReservationProject.Models;

namespace BookReservationProject.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BorrowsController(ApplicationDbContext db)
        {
            _db = db;
        }
        ///private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Borrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _db.Borrow
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrows/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            var borrow = new Borrow { BookId = book.BookId, BorrowDate = DateTime.Now, Book = book };
            ViewBag.ReaderId = new SelectList(_db.Reader, "ReaderId", "Name");
            return View(borrow);
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BorrowId,BookId,ReaderId,BorrowDate,ReturnDate")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                _db.Borrow.Add(borrow);
                _db.SaveChanges();
                return RedirectToAction("Index", "Books");
            }
            ViewBag.ReaderId = new SelectList(_db.Reader, "ReaderId", "Name", borrow.ReaderId);
            borrow.Book = _db.Books.Find(borrow.BookId);
            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrow borrow = _db.Borrow
                .Include(b => b.Book)
                .Include(c => c.Reader)
                .Where(b => b.BookId == id && b.ReturnDate == null)
                .FirstOrDefault();
            if (borrow == null)
            {
                return NotFound();
            }
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BorrowId,BookId,ReaderId,BorrowDate,ReturnDate")] Borrow borrow)
        {
            if (id != borrow.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var borrowItem = _db.Borrow.Include(i => i.Book)
                    .FirstOrDefault(i => i.BorrowId == borrow.BorrowId);
                if (borrowItem == null)
                {
                    return NotFound();
                }
                borrowItem.ReturnDate = DateTime.Now;
                _db.SaveChanges();
                return RedirectToAction("Index", "Books");
            }
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _db.Borrow
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _db.Borrow.FindAsync(id);
            _db.Borrow.Remove(borrow);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowExists(int id)
        {
            return _db.Borrow.Any(e => e.BorrowId == id);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
