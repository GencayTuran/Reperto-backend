using Microsoft.EntityFrameworkCore;
using Reperto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reperto.Data
{
    public class RepertoDbContext : DbContext
    {
        public RepertoDbContext(DbContextOptions<RepertoDbContext>
        options) : base(options) { }
        
        //Db tables
        public DbSet<Song> Songs { get; set; }
        public DbSet<Chord> Chords { get; set; }
        public DbSet<Repertoire> Repertoires { get; set; }
    }
}
