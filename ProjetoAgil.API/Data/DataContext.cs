using Microsoft.EntityFrameworkCore;
using ProjetoAgil.API.Models;

namespace ProjetoAgil.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(){}
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=ProAgil.db");
            }
        }

        public DbSet<Evento> Eventos{get; set;}
    }
}