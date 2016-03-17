using System;

namespace EjemploAutoMapper
{
    public class BookEntity
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public int Pages { get; set; }
        public int Edition { get; set; }

        public AuthorEntity Author { get; set; }
    }
}

