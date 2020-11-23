using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservationProject.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string PublishedYear { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }

        public ICollection<Borrow> Borrow { get; set; }
    }
}
