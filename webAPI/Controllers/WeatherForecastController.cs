using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace webAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    //se crea la inyeccion de dependencia usando un servicio externo dentro de una clase
    //http://localhost:5169/WeatherForecast
    private readonly SeriesOnlineContext contexto;

    public WeatherForecastController(SeriesOnlineContext context){
        this.contexto = context;
    }
    [HttpGet]
    public IEnumerable<Serie> Get(){
        return contexto.Serie!.ToList();

    }
}
