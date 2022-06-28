using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment_1_book_management_mvc.ViewModel
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Book title is mandatory")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Book author is mandatory")]
        public string Author { get; set; }
        [Required(ErrorMessage = " Book rating is mandatory")]
        [Range(1, 5, ErrorMessage = "Range must be between 1 to 5")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Book price is mandatory")]
        [Range(1, 300000, ErrorMessage = "Price must be between 1 to 300000")]
        public int Price { get; set; }

    }
}