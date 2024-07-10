// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using PublisherData;

using PublisherDomain;

namespace PublisherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            using (PubContext context = new PubContext())
            {
                // NOTE(crhodes)
                // This is good for demos.  Just create on the fly

                context.Database.EnsureCreated();
            }

            var p = new Program();

            //p.GetAuthors();
            //p.AddAuthors();
            //p.GetAuthors();

            p.AddAuthorWithBook();
            p.GetAuthorsWithBooks();
        }

        private void GetAuthors()
        {
            //using (var context = new PubContext())
            //{

            //}

            // TODO(crhodes)
            // Learn about this syntax

            using var context = new PubContext();

            var authors = context.Authors.ToList();

            foreach (var author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }
        private void AddAuthors()
        {
            var author = new Author { FirstName = "Archer" , LastName = "Schrhodes"};

            using var context = new PubContext();

            context.Authors.Add(author);
            context.SaveChanges();
        }

        void AddAuthorWithBook()
        {
            var author = new Author { FirstName = "Julie", LastName = "Lerman" };
            author.Books.Add(new Book
            {
                Title = "Programming Entity Framework",
                PublishDate = new DateOnly(2009, 1, 1)
            });
            author.Books.Add(new Book
            {
                Title = "Programming Entity Framework 2nd Ed",
                PublishDate = new DateOnly(2010, 8, 1)
            });
            using var context = new PubContext();
            context.Authors.Add(author);
            context.SaveChanges();
        }
        void GetAuthorsWithBooks()
        {
            using var context = new PubContext();
            var authors = context.Authors.Include(a => a.Books).ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
                foreach (var book in author.Books)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }
    }
}