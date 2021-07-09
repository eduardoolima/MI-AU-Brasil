using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MIEAUBRASIL.Models;

    public class MIEAUBRASILContext : DbContext
    {
        public MIEAUBRASILContext (DbContextOptions<MIEAUBRASILContext> options)
            : base(options)
        {
        }

        public DbSet<MIEAUBRASIL.Models.AnimalDoador> AnimalDoador { get; set; }
    }
