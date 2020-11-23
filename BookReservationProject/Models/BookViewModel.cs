using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservationProject.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string PublishedYear { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }
        public string Summary { get; set; }

        public bool IsAvailable { get; set; }
    }
}
