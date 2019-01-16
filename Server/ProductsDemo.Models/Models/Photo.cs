using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDemo.Models.Models
{
    public class Photo : BaseEntity
    {
        public string Title { get; }
        public string Url { get; }


        public Photo(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}
