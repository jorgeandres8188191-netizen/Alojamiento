using lib_repositorios.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using lib_aplicaciones.Interfaces;
using ut_presentacion.Nucleo;
namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MascotasController : ControllerBase
    {
        private IMascotasAplicacion? iAplicacion = null; private TokenController? tokenController = null;
        public MascotasController(IMascotasAplicacion? iAplicacion, TokenController tokenController) { this.iAplicacion = iAplicacion; this.tokenController = tokenController; }
        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos)) datos = "{}"; return JsonConversor.ConvertirAObjeto(datos);
        }
        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>(); try
            {
                var datos = ObtenerDatos(); if (!tokenController!.Validate(datos)) { respuesta["Error"] = "lbNoAutenticacion"; return JsonConversor.ConvertirAString(respuesta); }
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion")); respuesta["Entidades"] = this.iAplicacion!.Listar();
                respuesta["Respuesta"] = "OK"; respuesta["Fecha"] = DateTime.Now.ToString(); return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex) { respuesta["Error"] = ex.Message.ToString(); return JsonConversor.ConvertirAString(respuesta); }
        }
        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>(); try
            {
                var datos = ObtenerDatos(); if (!tokenController!.Validate(datos)) { respuesta["Error"] = "lbNoAutenticacion"; return JsonConversor.ConvertirAString(respuesta); }
                var entidad = JsonConversor.ConvertirAObjeto<Mascotas>(JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion")); entidad = this.iAplicacion!.Guardar(entidad);
                respuesta["Entidad"] = entidad!; respuesta["Respuesta"] = "OK"; respuesta["Fecha"] = DateTime.Now.ToString(); return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex) { respuesta["Error"] = ex.Message.ToString(); return JsonConversor.ConvertirAString(respuesta); }
        }
        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Mascotas>(JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString(); return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex) { respuesta["Error"] = ex.Message.ToString(); return JsonConversor.ConvertirAString(respuesta); }
        }
        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>(); try
            {
                var datos = ObtenerDatos(); if (!tokenController!.Validate(datos)) { respuesta["Error"] = "lbNoAutenticacion"; return JsonConversor.ConvertirAString(respuesta); }
                var entidad = JsonConversor.ConvertirAObjeto<Mascotas>(JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}
