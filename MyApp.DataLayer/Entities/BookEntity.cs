﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataLayer.Entities
{
    public class BookEntity : BaseEntity
    {
       
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        
    }
}
