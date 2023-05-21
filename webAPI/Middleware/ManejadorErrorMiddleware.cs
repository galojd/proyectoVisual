using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Newtonsoft.Json;


namespace webAPI.Middleware
{
    public class ManejadorErrorMiddleware
    {
        private readonly RequestDelegate? _next;
        private readonly ILogger<ManejadorErrorMiddleware>? _logger;
        public ManejadorErrorMiddleware(RequestDelegate next, ILogger<ManejadorErrorMiddleware> logger){
            _next = next;
            _logger = logger;
        }

        //metodo para manejar request en el contexto
        public async Task Invoke(HttpContext context){
            try{
                await _next(context);//si todo esta correcto pasa a lo siguiente

            }catch(Exception ex){
                await ManejadroExcepcionAsyncrona(context, ex, _logger);
            }
        }

        private async Task  ManejadroExcepcionAsyncrona(HttpContext context, Exception ex, ILogger<ManejadorErrorMiddleware>? logger){
            object errores = null;
            switch(ex){
                case ManejadorExcepcion me:
                        logger.LogError(ex, "Manejador Error");//me pinta el detalle de la excepcion
                        errores = me.Errores;//me almacena los errores que provienen de esa excepcion
                        context.Response.StatusCode = (int)me.Codigo;//el codigo de status de la excepcion
                        break;
                case Exception e:
                        logger.LogError(ex, "Error de servidor");
                        errores = string.IsNullOrWhiteSpace(e.Message) //se trasnforma el mensaje a string ya que posiblemente devuleva un json
                            ? "error"
                            : e.Message ;
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

            }
            context.Response.ContentType = "application/json";
            if(errores != null){
                var resultados = JsonConvert.SerializeObject(new {errores});
                await context.Response.WriteAsync(resultados);
            }
            
        }
    }
}