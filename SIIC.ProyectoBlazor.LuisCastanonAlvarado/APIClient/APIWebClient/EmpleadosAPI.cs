using Newtonsoft.Json;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.APIWebClient
{
    public class EmpleadosAPI:HttpClient
    {
        public EmpleadosAPI(string urlServer)
        {
            urlServer += (urlServer.EndsWith('/')) ? "api/Empleados/" : "/api/Empleados/";
            BaseAddress = new Uri(urlServer);
        }
        public async Task<List<ServiciosEmpleados>> GetEmpleadosAsync()
        {
            try
            {
                var res = await this.GetFromJsonAsync<List<ServiciosEmpleados>>("ObtenerEmpleados");
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ServiciosEmpleados>();
                throw;
            }
        }
        public async Task<bool> AgregarEmpleadoAsync(ServiciosEmpleados empleado)
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("GuardarEmpleado", empleado);
                if (resultado.IsSuccessStatusCode)
                {
                    var s = resultado.Content.ReadAsStringAsync().Result;
                    var responde = JsonConvert.DeserializeObject<bool>(s);
                    return responde;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
        public async Task<bool> EliminarEmpleadoAsync(Guid id)
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("EliminarEmpleado", id);
                if (resultado.IsSuccessStatusCode)
                {
                    var s = resultado.Content.ReadAsStringAsync().Result;
                    var response = JsonConvert.DeserializeObject<bool>(s);
                    return response;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
        public async Task<bool> ActualizarEmpleadoAsync(ServiciosEmpleados empleado)
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("ActualizarEmpleado", empleado);
                if (resultado.IsSuccessStatusCode)
                {
                    var s = resultado.Content.ReadAsStringAsync().Result;
                    var responde = JsonConvert.DeserializeObject<bool>(s);
                    return responde;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
    }
}
