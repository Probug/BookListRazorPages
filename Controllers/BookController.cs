using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
        [Route("api/Book")]
        [ApiController]
    public class BookController : Controller
    {
        private readonly BookServices _db;
        public BookController(BookServices db)
        {
            _db = db;
        }  

        [HttpGet]
        public IActionResult GetAll ()
        {
            return Json(new {data = _db.Get().ToList()});
        }
    }
}