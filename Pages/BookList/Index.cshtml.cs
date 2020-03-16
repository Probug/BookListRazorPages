using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Services;
using BookListRazor.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly BookServices _db;
        public IndexModel(BookServices db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books {get; set;}
        public void OnGet()
        {
            Books = _db.Get().ToList();
        }

        public IActionResult OnPostDelete(string id)
        {
             if (id == null)
            {
                return NotFound();
            }

            var book =  _db.Get().Find(x => x.Id == id);
            
            if (book != null)
            {
                _db.Remove(book);
            }

            return RedirectToPage("Index");
        }
    }
}
