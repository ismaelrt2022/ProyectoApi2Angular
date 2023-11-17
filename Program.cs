using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using ProyectoApi2Angular.Data;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;
//using Microsoft.EntityFrameworkCore.Design;


var builder = WebApplication.CreateBuilder(args);

//Conectando con SqLite
var connectionString =builder.Configuration.GetConnectionString("DefaultConnetion");
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString)
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
