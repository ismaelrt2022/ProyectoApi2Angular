using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoApi2Angular.Models;


namespace ProyectoApi2Angular.Data
{
    public class DataContext: DbContext
    {
     public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
           
        }
            public DbSet<Producto> Productos {get; set;} 
    }
}