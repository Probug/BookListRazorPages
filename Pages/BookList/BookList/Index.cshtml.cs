using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Services;
using BookListRazor.Model;
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
            
        }
    }
}
