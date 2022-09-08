using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStore.Enums;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Please Enter Title of your Book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Name of Author")]
        public string Author { get; set; }
       
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Category of your Book")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please Choose Language of your Book")]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage ="Please Enter no of Pages")]
        public int? Pages { get; set; }

        [Display(Name = "Upload your book's cover photos")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImgPath { get; set; }

        [Display(Name = "Upload your book's Gallery photos")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }


        [Display(Name ="Upload your book in pdf format")]
        [Required]
        public IFormFile BookPDF { get; set; }
        public string BookPDFURL { get; set; }
    } 
}
