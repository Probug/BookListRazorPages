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
    public class CreateModel : PageModel
    {

        private readonly BookServices _db;
        public CreateModel(BookServices db)
        {
            _db = db;
        }       
        
        [BindProperty]
         public Book Book {get; set;}
         public void OnGet()
        {
        }


    }
}
