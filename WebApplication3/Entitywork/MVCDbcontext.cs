
﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace WebApplication3.Entitywork
{
    public class MVCDbcontext : DbContext
    {
        public MVCDbcontext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<RegisterTable> RegisterTable { get; set; }
    }
}