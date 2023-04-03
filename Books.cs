using System.Collections.Generic;

namespace HomeLibrary
{
    public class Book
    {
        private static int IdCount = 0; 
        public int Id { get; private set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public bool IsRead { get; set; }

        public int Year { get; set; }

        public BookFormat Format { get; set; }

        public Book()
        {
            IdCount++;
            Id = IdCount;

        }
    }

    public enum BookFormat
    {
        PaperBack, EBook
    }

    public static class MyBookCollection
    {
        public static List<Book> GetMyCollection()
        {
            return new List<Book>()
            {
                new Book(){ Author = "J.K. Rowling", Format = BookFormat.EBook, IsRead = true, Title = "Harry Potter and the Philosopher's Stone", Year=1997},

                new Book(){ Author = "J.K. Rowling", Format = BookFormat.EBook, IsRead = true, Title = "Harry Potter and the Chamber of Secrets", Year = 1998},

                new Book(){ Author = "J.K. Rowling", Format = BookFormat.PaperBack, IsRead = true, Title = "Harry Potter and the Prisoner of Azkaban", Year = 1999},

                new Book(){ Author = "Jonathan Swift", Format = BookFormat.PaperBack, IsRead = false, Title = "Travels into Several Remote Nations of the World. In Four Parts. By Lemuel Gulliver, First a Surgeon, and then a Captain of several Ships", Year=1972},

                new Book(){Author = "Wayne Thomas Batson", Format = BookFormat.EBook, IsRead = true, Title = "Isle of Swords", Year = 2007},

                new Book(){Author = "Louis A. Meyer", Format = BookFormat.EBook, IsRead = true, Title = "Under the Jolly Roger", Year = 2005},
                
            };

        }
    }
}
