using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using BookListRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private readonly BookServices _db;
        public CreateModel(BookServices db)
        {
            _db = db;
        }       
        
        [BindProperty]
         public Book Book {get; set;}
        public IActionResult OnGet()
        {
            return Page();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        // public IActionResult Create(Book Book)
        //{

        // }



        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _db.Create(Book);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
        /* public async Task <IActionResult> OnPost()
         {
             if (ModelState.IsValid)
             {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
             }
             else
             {
                 return Page();
             }
         }*/
    }
}
