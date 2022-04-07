using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactRegister.Models;

namespace WebContactRegister.Data
{
    public class ContactRegDBContext:DbContext
    {
        public ContactRegDBContext(DbContextOptions<ContactRegDBContext> options) : base(options) 
        { 

        }
        //Virtual properties
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Person> People { get; set; }

    }
}
