using System;
using Xunit;
using Movies.Controllers;
using Movies.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MoviesTests
{
    public class UnitTest1
    {
        MoviesController _controller;
        MoviesContext _context;

        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
        public UnitTest1()
        {
            var config = InitConfiguration();
            var connection = config.GetConnectionString("MoviesContext");
            optionsBuilder.UseSqlServer(connection);
            _context = new MoviesContext(new DbContextOptions<MoviesContext>());
            _controller = new MoviesController(_context);
        }
        [Fact]
        public async void Test1()
        {
            try
            {
                var movies = await _controller.GetMovie();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [Fact]
        public async void Test2()
        {
            try
            {
                var movies = await _controller.GetMovieByID(1);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [Fact]
        public async void Test3()
        {
            try
            {
                var movies = await _controller.SearchMovie("Title", "National");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
