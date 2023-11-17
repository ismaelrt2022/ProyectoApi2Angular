
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoApi2Angular.Models
{
    public class Producto
    {
        public int Id {get; set;}
        public string Nombre {get; set;}=string.Empty;
        public string Descripcion {get; set;}=string.Empty;
        public decimal Precio {get; set;}
        public DateTime FechaDeAlta{get;set;}
        public bool Activo {get;set;}
    }
}