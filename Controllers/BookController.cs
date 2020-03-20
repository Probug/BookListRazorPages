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

        [HttpDelete]
        public IActionResult Delete (string id)
        {
           
            var bookFromDb = _db.Get().Find(x => x.Id == id);

            if (bookFromDb == null)
            {
                return Json( new{ success = false, message = "Error while Deleting"});
            }
 
               _db.Remove(bookFromDb.Id); 
            
            return Json( new{ success = true, message="Delete Successful"});
               
        }
    }
}