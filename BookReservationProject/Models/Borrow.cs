using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservationProject.Models
{
    public class Borrow
    {
        public int BorrowId { get; set; }

        [Required]
        [Display(Name = "BookName")]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [Required]
        [Display(Name = "Reader")]
        public int ReaderId { get; set; }

        public Reader Reader { get; set; }

        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }
    }
}
