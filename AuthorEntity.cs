﻿using System;
using System.Collections.Generic;

namespace EjemploAutoMapper
{
    public class AuthorEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public List<BookEntity> Books { get; set; }
    }
}

