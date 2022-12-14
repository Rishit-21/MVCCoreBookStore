using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public int Pages { get; set; }
        public Language Language { get; set; }
        public string CoverImgPath { get; set; }
        public string BookPDFURL { get; set; }


        public ICollection<BookGallery> bookGallery { get; set; }
    }
}
