using System;
using System.Collections.Generic;
using System.Text;
using BookReservationProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookReservationProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<BookReservationProject.Models.ProjectRole> ProjectRole { get; set; }
    }
}
