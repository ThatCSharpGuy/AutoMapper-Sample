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
                Name = "Joanne Rowling",
                Age = 50,
                Books = new List<BookEntity>() 
                {
                    new BookEntity { Title = "Harry Potter", Subtitle = "y la piedra filosofal" },
                    new BookEntity { Title = "Harry Potter", Subtitle = "y la cámara secreta" },
                    new BookEntity { Title = "Una vacante imprevista" }
                }
            };

            var bookEntity = new BookEntity
            {
                    Title ="C# 6 in a Nutshell",
                    Edition = 6,
                    Pages = 1114,
                    Author = new AuthorEntity 
                    {
                        Name = "Joseph Albahari",
                        Age = 35
                    }
            };
            
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
                        .ForMember(model=> model.AuthorName, 
                            opt => opt.ResolveUsing(entity => entity.Author.Name))
                        .ForMember(model => model.FullTitle,
                            opt => opt.ResolveUsing(entity => entity.Title + " " + entity.Subtitle));
            });

            return automappingConfiguration.CreateMapper();
        }
    }
}
