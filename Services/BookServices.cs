using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using BookListRazor.Model;
using BooksListRazor.Models;
using Microsoft.Extensions.Configuration;

namespace BookListRazor.Services

{
    public class BookServices
    {
         private readonly IMongoCollection<Book> books;

           public BookServices(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("BookListRazorDb"));
            IMongoDatabase database = client.GetDatabase("BookListRazorDb");
            books = database.GetCollection<Book>("Books");
        }

         public List<Book> Get() =>

            books.Find(book => true).ToList();

        public List<Book> FindByTitle(string title) =>

            books.Find(book => book.Name.ToLower().Contains(title.ToLower())).ToList();

        public Book Get(string id) =>
            books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            books.InsertOne(book);
            return book;
        }



        public void Update(string id, Book bookIn) =>
            books.ReplaceOne(book => book.Id == id, bookIn);



        public void Remove(Book bookIn) =>
            books.DeleteOne(book => book.Id == bookIn.Id);


        public void Remove(string id) =>
            books.DeleteOne(book => book.Id == id);

    }
}