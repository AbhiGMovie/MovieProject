using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movies;

namespace Movies.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MoviesContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public virtual DbSet<booking> booking { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieStills> MovieStills { get; set; }
        public virtual DbSet<Stills> Stills { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
