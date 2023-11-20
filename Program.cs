using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnHomeworks"));
// builder.Services.AddSqlServer<TareasContext>("DESKTOP-1J4POOS");

//3 maneras de hacer la configuracion de la inyeccion de dependencias
builder.Services.AddScoped<IHelloworldService, HelloWorldService>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
// builder.Services.AddScoped<IHelloworldService>(p=> new HelloWorldService());
//Este se utiliza cuando tenemos que pasar algun parametro a la dependencia


/*
De esta manera estamos creando una nueva instancia de la dependencia que estamos usando, pero a nivel de controlador o a nivel 
de clase, es decir que no importa si estamos inyectando varias veces y en diferentes partes esta dependencia dentro de todo el 
contexto del controlador o todo el contexto de la clase, se va a inyectar exactamente la misma instancia que se creo para todo ese elemento. 
// builder.Services.AddTransient();
*/

// builder.Services.AddSingleton<ITimeService, TimeService>();
/*
De esta manera estamos creando UNA ÚNICA implementación o instancia de esa dependencia EN TODA LA API 
(no es recomendable usar singleton porque hacemos que nuestras dependencias se creen en memoria lo que podría causar un problema, además la tendencia es implementar 
APIS que sean stateless que no manejen ningún tipo de estado sino que con cada request se cree una nueva implementación o instancia de la dependencia configurada.)
*/



// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("PermitirApiRequest",
//     builder => builder.WithOrigins("http://localhost:5001").WithMethods("GET", "POST").AllowAnyHeader());
//     //Permitir el origen de la peticion, el puerto donde se esta ejecutando el cliente
//     //Permitir los metodos que se van a ejecutar
//     //Permitir cualquier header
// });

//Antes del build se hacen las inyecciones de dependencias
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseCors();
//Seguridad quien puede usar el API

app.UseAuthorization();

// app.UseWelcomePage();
// Pagina de bienvenida
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
