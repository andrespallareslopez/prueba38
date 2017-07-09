using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using prueba38.Models;

namespace prueba38.Models {
    public static class DBinitialize {
        public static void EnsureCreated(IServiceProvider serviceProvider){
            var context = new DbProducto(
                serviceProvider.GetRequiredService<DbContextOptions<DbProducto>>()
            );
            context.Database.EnsureCreated();
        }
    }
}