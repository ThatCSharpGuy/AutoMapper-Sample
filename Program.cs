using System;
using AutoMapper;
using System.Collections.Generic;

namespace EjemploAutoMapper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var mapper = CreateMapper();
            var entidadAutor = new AuthorEntity
            {
                Id = 2,
                Name = "Joanne Rowling",
                Age = 50,
                Books = new List<BookEntity>()
                {
                    new BookEntity { Id = 4, Title = "Harry Potter", Subtitle = "y la piedra filosofal" },
                    new BookEntity { Id = 3, Title = "Harry Potter", Subtitle = "y la cámara secreta" },
                    new BookEntity { Id = 9, Title = "Una vacante imprevista" }
                }
            };

            #region Manual mapping

            #endregion

            var bookEntity = new BookEntity
            {
                Id = 30,
                Title = "C# 6 in a Nutshell",
                Edition = 6,
                Pages = 1114,
                Author = new AuthorEntity
                {
                    Name = "Joseph Albahari",
                    Age = 35
                }
            };

            #region Manual mapping
            //var modeloAutor = new AuthorModel();
            //modeloAutor.Name = entidadAutor.Name;
            //modeloAutor.Age = entidadAutor.Age;
            //modeloAutor.BooksCount = entidadAutor.Books != null ? entidadAutor.Books.Count : 0;

            //var modeloLibro = new BookModel();
            //modeloLibro.FullTitle = bookEntity.Title + " " + bookEntity.Subtitle;
            //modeloLibro.AuthorName = bookEntity.Author != null ? bookEntity.Author.Name : null;
            //modeloLibro.Pages = bookEntity.Pages;
            #endregion
            
            var modeloAutor = mapper.Map<AuthorModel>(entidadAutor);
            Console.WriteLine("Información de autor");
            Console.WriteLine("Autor: " + modeloAutor.Name);
            Console.WriteLine("Edad: " + modeloAutor.Age);
            Console.WriteLine("Libros: " + modeloAutor.BooksCount);

            var modeloLibro = mapper.Map<BookModel>(bookEntity);
            Console.WriteLine("Información de libro");
            Console.WriteLine("Título: " + modeloLibro.FullTitle);
            Console.WriteLine("Autor: " + modeloLibro.AuthorName);
            Console.WriteLine("Páginas: " + modeloLibro.Pages);



        }

        static IMapper CreateMapper()
        {
            var automappingConfiguration = new AutoMapper.MapperConfiguration(config =>
                {
                    config.CreateMap<AuthorEntity, AuthorModel>();

                    config.CreateMap<BookEntity, BookModel>()
                        .ForMember(model => model.AuthorName, 
                        opt => opt.ResolveUsing(entity => entity.Author.Name))
                        .ForMember(model => model.FullTitle,
                        opt => opt.ResolveUsing(entity => entity.Title + " " + entity.Subtitle));
                });

            return automappingConfiguration.CreateMapper();
        }
    }
}
