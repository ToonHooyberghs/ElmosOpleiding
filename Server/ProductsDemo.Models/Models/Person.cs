﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDemo.Models.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int Age { get; set; }
    }
}
