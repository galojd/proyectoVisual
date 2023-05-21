using System.Text;
using Aplicacion.Contratos;
using Aplicacion.Mantenimiento.Series;
using Aplicacion.Mantenimiento.UsuarioSeries;
using Dominio.Entidades;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistencia;
using Persistencia.DapperConexion;
using Persistencia.DapperConexion.Paginacion;
using Seguridad.TokenSeguridad;
using webAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers(
    opt => {
    //se agrega una nueva regla, se llama un objeto policy desde AuthorizationPolicyBuilder que requerira que el usuario este autenticado
    //esto es para que los controller tengan autorizacion antes de procesar un request
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
}
).AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<NuevoSeries>());



var build = builder.Services.AddIdentityCore<Usuario>();
var identitybuilder = new IdentityBuilder(build.UserType, build.Services);
//necesario para crear los roles
identitybuilder.AddRoles<IdentityRole>();
identitybuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Usuario, IdentityRole>>();

identitybuilder.AddEntityFrameworkStores<SeriesOnlineContext>();
//Le indico que core identitu va a manejar los usuarios
identitybuilder.AddSignInManager<SignInManager<Usuario>>();
builder.Services.TryAddSingleton<ISystemClock, SystemClock>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SeriesOnlineContext>(options =>{options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));});
builder.Services.AddMediatR(typeof(ConsultaSerie.manejador).Assembly);

builder.Services.Configure<ConexionConfiguracion>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddScoped<IJwtGenerador,JwtGenerador>();

builder.Services.AddScoped<IUsuarioSesion, UsuarioSesion>();

builder.Services.AddAutoMapper(typeof(ConsultaSerie.manejador));

builder.Services.AddTransient<IFactoryConeccion, FactoryConeccion>();

builder.Services.AddScoped<IPaginacion, PaginacionRepositorio>();


var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Otra prueba de token basico"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
    opt.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = Key,
        //para este ejemplo es global para una empresa se configura con su ippublico
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1", new OpenApiInfo{
        Title = "Servicios para mantenimiento de series",
        Version = "v1"
    });
    //le indico que trabaje con el nombre completo de las clases que me permiten mapear el nombre del cliente
    c.CustomSchemaIds(c => c.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//esto se agrega para que conecte, debes agregarlo despues del servicio
using(var ambiente = app.Services.CreateScope()){
    var services = ambiente.ServiceProvider;
    try{
        var userManager = services.GetRequiredService<UserManager<Usuario>>();
        var context = services.GetRequiredService<SeriesOnlineContext>();
        context.Database.Migrate();
        DataPrueba.InsertarData(context, userManager).Wait();
    }catch (Exception e){
        var logging = services.GetRequiredService<ILogger<Program>>();
        logging.LogError(e, "Ocurrio un error de migracion");
    }
}

//lo desactivo porque trabajare de forma local
//app.UseHttpsRedirection();
app.UseMiddleware<ManejadorErrorMiddleware>();

app.UseAuthentication();//esto le agrego junto con lo de AddAuthentication

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI( c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Series Online v1");
});

app.Run();
