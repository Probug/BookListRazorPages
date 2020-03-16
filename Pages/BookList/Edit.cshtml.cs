using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using BookListRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private BookServices _db;

        public EditModel(BookServices db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book {get; set;}   
        public string ID {get; set;}
        public IActionResult OnGet(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Book = _db.Get().Find(x => x.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            ID = id;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Update(Book.Id, Book);

                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }
    }
}


 
