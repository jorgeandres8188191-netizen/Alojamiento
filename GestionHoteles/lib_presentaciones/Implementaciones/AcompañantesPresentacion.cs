using lib_dominio.Entidades; 
using lib_dominio.Nucleo; 
using lib_presentaciones.Interfaces; 
 
namespace lib_presentaciones.Implementaciones 
{ 
    public class AcompañantesPresentacion : IAcompañantesPresentacion 
    { 
        private Comunicaciones? comunicaciones = null; 
 
        public async Task<List<Acompañantes>> Listar() 
        { 
            var lista = new List<Acompañantes>(); 
            var datos = new Dictionary<string, object>(); 
 
            comunicaciones = new Comunicaciones(); 
            datos = comunicaciones.ConstruirUrl(datos, "Acompañantes/Listar"); 
            var respuesta = await comunicaciones!.Execute(datos); 
 
            if (respuesta.ContainsKey("Error")) 
            { 
                throw new Exception(respuesta["Error"].ToString()!); 
            } 
            lista = JsonConversor.ConvertirAObjeto<List<Acompañantes>>( 
                JsonConversor.ConvertirAString(respuesta["Entidades"])); 
 
 
            return lista; 
        } 
 
        /*public async Task<List<Acompañantes>> PorEstudiante(Acompañantes? entidad) 
        { 
            var lista = new List<Acompañantes>(); 
            var datos = new Dictionary<string, object>(); 
            datos["Entidad"] = entidad!; 
 
            comunicaciones = new Comunicaciones(); 
            datos = comunicaciones.ConstruirUrl(datos, "Acompañantes/PorEstudiante"); 
            var respuesta = await comunicaciones!.Execute(datos); 
 
            if (respuesta.ContainsKey("Error")) 
            { 
                throw new Exception(respuesta["Error"].ToString()!); 
            } 
            lista = JsonConversor.ConvertirAObjeto<List<Acompañantes>>( 
                JsonConversor.ConvertirAString(respuesta["Entidades"])); 
            return lista; 
        }*/
 
        public async Task<Acompañantes?> Guardar(Acompañantes? entidad) 
        { 
            if (entidad!.Id != 0) 
            { 
                throw new Exception("lbFaltaInformacion"); 
            } 
 
            var datos = new Dictionary<string, object>(); 
            datos["Entidad"] = entidad; 
 
            comunicaciones = new Comunicaciones(); 
            datos = comunicaciones.ConstruirUrl(datos, "Acompañantes/Guardar"); 
            var respuesta = await comunicaciones!.Execute(datos); 
 
            if (respuesta.ContainsKey("Error")) 
            { 
                throw new Exception(respuesta["Error"].ToString()!); 
            } 
            entidad = JsonConversor.ConvertirAObjeto<Acompañantes>( 
                JsonConversor.ConvertirAString(respuesta["Entidad"])); 
            return entidad; 
        } 
 
        public async Task<Acompañantes?> Modificar(Acompañantes? entidad) 
        { 
            if (entidad!.Id == 0) 
            { 
                throw new Exception("lbFaltaInformacion"); 
            } 
 
            var datos = new Dictionary<string, object>(); 
            datos["Entidad"] = entidad; 
 
 
 
            comunicaciones = new Comunicaciones(); 
            datos = comunicaciones.ConstruirUrl(datos, "Acompañantes/Modificar"); 
            var respuesta = await comunicaciones!.Execute(datos); 
 
            if (respuesta.ContainsKey("Error")) 
            { 
                throw new Exception(respuesta["Error"].ToString()!); 
            } 
            entidad = JsonConversor.ConvertirAObjeto<Acompañantes>( 
                JsonConversor.ConvertirAString(respuesta["Entidad"])); 
            return entidad; 
        } 
 
        public async Task<Acompañantes?> Borrar(Acompañantes? entidad) 
        { 
            if (entidad!.Id == 0) 
            { 
                throw new Exception("lbFaltaInformacion"); 
            } 
 
            var datos = new Dictionary<string, object>(); 
            datos["Entidad"] = entidad; 
 
            comunicaciones = new Comunicaciones(); 
            datos = comunicaciones.ConstruirUrl(datos, "Acompañantes/Borrar"); 
            var respuesta = await comunicaciones!.Execute(datos); 
 
            if (respuesta.ContainsKey("Error")) 
            { 
                throw new Exception(respuesta["Error"].ToString()!); 
            } 
            entidad = JsonConversor.ConvertirAObjeto<Acompañantes>( 
                JsonConversor.ConvertirAString(respuesta["Entidad"])); 
            return entidad; 
        } 
    } 
}