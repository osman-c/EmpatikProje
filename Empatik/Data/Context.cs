using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Empatik.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Empatik.Data
{
    public class Context : DbContext
    {
        public DbSet<HomeModel> HomeModels { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
