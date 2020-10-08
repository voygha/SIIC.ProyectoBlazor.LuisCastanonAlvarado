using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.APIWebClient;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.BL;

namespace SIIC.ProyectoBlazor.LuisCastanonAlvarado
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddTransient(s => new EmpresasAPI("https://tiendablazor.azurewebsites.net"));
            builder.Services.AddTransient<EmpresasBL>();
            builder.Services.AddTransient(s => new EmpleadosAPI("https://tiendablazor.azurewebsites.net"));
            builder.Services.AddTransient<EmpleadoBL>();

            await builder.Build().RunAsync();
        }
    }
}
