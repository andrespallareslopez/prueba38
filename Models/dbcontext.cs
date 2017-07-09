using Microsoft.EntityFrameworkCore;
using prueba38.Models;

namespace prueba38.Models {
    public class DbProducto : DbContext {
        
        public DbProducto(DbContextOptions<DbProducto> options) : base(options){
               
        }
        
        public DbSet<Grupo> grupo {get;set;}
        public DbSet<Familia> familia {get;set;}
        public DbSet<Producto> producto {get;set;}
        
        
    }
}