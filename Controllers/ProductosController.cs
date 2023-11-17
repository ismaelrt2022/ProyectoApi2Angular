using System.Reflection.Metadata;
using System.Net.Http.Headers;
using System.Collections;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using ProyetoApi2Angular.Models;
using Microsoft.EntityFrameworkCore;
//using ProyetoApi2Angular.Models.Producto;
using ProyectoApi2Angular.Models;
using ProyectoApi2Angular.Data;

namespace ProyectoApi2Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        
    private readonly ILogger<ProductosController> _logger;
    private readonly DataContext _context;

public ProductosController(ILogger<ProductosController> logger, DataContext context){

    _logger = logger;
    _context = context;

}

[HttpGet(Name = "GetProductos")]
public async Task<ActionResult<IEnumerable<Producto>>> GetProductos(){

    return await _context.Productos.ToListAsync();
}


[HttpGet("{id}",Name="GetProducto")]
public async Task<ActionResult<Producto>> GetProducto(int id){
  
    var producto =await _context.Productos.FindAsync(id);

    if(producto==null){

        return NotFound();

    }   

    return producto; 

}


[HttpPost]
public async Task<ActionResult<Producto>> GuardarProducto(Producto producto){

     _context.Productos.Add(producto);
     await _context.SaveChangesAsync();

     return new CreatedAtRouteResult("GetProducto",new {id=producto.Id},producto);
}


[HttpPut("{id}")]
public async Task<ActionResult> Put(int id,Producto producto){

if(id !=producto.Id){
  return BadRequest();
}

_context.Entry(producto).State=EntityState.Modified;
await _context.SaveChangesAsync();

return Ok();

}

[HttpDelete("{id}")]
public async Task<ActionResult<Producto>> Delete(int id){

 var producto  = await _context.Productos.FindAsync(id);

 if(producto == null){

   return  NotFound();
 }

_context.Productos.Remove(producto);    //puede o no llevar la palabra  produscto

await _context.SaveChangesAsync();

return producto;


}


       }
}