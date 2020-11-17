using MicroServicio.Api.libro.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroServicio.Api.libro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<LibreriaMaterial> libreriaMaterials { get; set; }
    }
}