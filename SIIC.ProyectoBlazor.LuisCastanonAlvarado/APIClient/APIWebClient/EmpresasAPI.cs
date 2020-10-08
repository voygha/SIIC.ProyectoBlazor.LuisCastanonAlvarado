using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.APIWebClient
{
    public class EmpresasAPI:HttpClient
    {
        public EmpresasAPI(string urlServer)
        {
            urlServer+=(urlServer.EndsWith('/')) ? "api/Empresas/" : "/api/Empresas/";
            BaseAddress = new Uri(urlServer);
        }
        public async Task<List<ServiciosEmpresas>> GetEmpresasAsync()
        {
            try
            {
                var res = await this.GetFromJsonAsync<List<ServiciosEmpresas>>("ObtenerEmpresas");
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ServiciosEmpresas>();
                throw;
            }
        }
        
        public async Task<bool> AgregarEmpresaAsync(ServiciosEmpresas empresas)
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("GuardarEmpresa", empresas);
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
        public async Task<bool> EliminarEmpresaAsync(Guid id)
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("EliminarEmpresa", id);
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
        
        public async Task<bool> ActualizarEmpresaAsync(ServiciosEmpresas empresas)
        {
            try
            {
                var resultado = await this.PostAsJsonAsync("ActualizarEmpresa", empresas);
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
