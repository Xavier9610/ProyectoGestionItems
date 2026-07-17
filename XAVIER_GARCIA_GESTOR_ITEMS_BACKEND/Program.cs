
using XAVIER_GARCIA_GESTOR_ITEMS_BACKEND.BaseDeDatos.Acceso;
using XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Interfaz;
using XAVIER_GARCIA_ITEMS_BACKEND.APLICACION.Servicio;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Conexion;
using XAVIER_GARCIA_ITEMS_BACKEND.INFRAESTRUCTURA.BaseDeDatos.Repositorios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IConexionBDDClientes, ConexionBDDClientes>();
builder.Services.AddScoped<IConexionBDDItems, ConexionBDDItems>();
builder.Services.AddScoped<IItemsServicio, ItemServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IBDDItems, BDDItems>();
builder.Services.AddScoped<IBDDClientes, BDDClientes>();
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
