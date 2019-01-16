using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDemo.Models.Models
{
    public class Photo : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }


        public Photo(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}
