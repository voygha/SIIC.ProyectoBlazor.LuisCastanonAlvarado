using Microsoft.AspNetCore.Components;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.APIWebClient;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.Clases;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisCastanonAlvarado.Pages
{
    public partial class Empresas
    {
        protected override async Task OnInitializedAsync()
        {
            await ObtenerEmpresas();
        }
       
        [Parameter]
        public List<ServiciosEmpresas> ListEmpresas { get; set; } = new List<ServiciosEmpresas>();

        [Parameter]
        public ServiciosEmpresas Empresa { get; set; } = new ServiciosEmpresas();

        [Inject]
        private EmpresasBL EmpresasBL { get; set; }

        public async Task ObtenerEmpresas()
        {
            ListEmpresas = await EmpresasBL.GetEmpresasAsync();
        }
        private void NewEmpresa()
        {
            Empresa = new ServiciosEmpresas();
        }
        private async Task GuardarEmpresa()
        {
            bool resultado = await EmpresasBL.AgregarEmpresaAsync(Empresa);
            await ObtenerEmpresas();
        }
        private async Task EliminarEmpresa(ServiciosEmpresas emp)
        {
            bool resultado = await EmpresasBL.EliminarEmpresaAsync(emp.id);
            await ObtenerEmpresas();
        }
        private void EditarEmpresa(ServiciosEmpresas emp)
        {
            Empresa = emp;
        }
        private async Task ActualizarEmpresa()
        {
            bool resultado = await EmpresasBL.ActualizarEmpresaAsync(Empresa);
            await ObtenerEmpresas();
        }





    }
}
