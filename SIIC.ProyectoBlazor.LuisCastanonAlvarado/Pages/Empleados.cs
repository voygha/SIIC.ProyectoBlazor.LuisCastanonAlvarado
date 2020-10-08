using Microsoft.AspNetCore.Components;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.Clases;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisCastanonAlvarado.Pages
{
    public partial class Empleados
    {
        protected override async Task OnInitializedAsync()
        {
            await ObtenerEmpleados();
        }

        [Parameter]
        public List<ServiciosEmpleados> ListEmpleados { get; set; } = new List<ServiciosEmpleados>();
        [Parameter]
        public ServiciosEmpleados Empleado { get; set; } = new ServiciosEmpleados();
        [Inject]
        private EmpleadoBL empleadoBL { get; set; }
        public async Task ObtenerEmpleados()
        {
            ListEmpleados= await empleadoBL.GetEmpleadosAsync();
        }
        private void NewEmpresa()
        {
            Empleado = new ServiciosEmpleados();
        }
        private async Task GuardarEmpleado()
        {
            bool resultado = await empleadoBL.AgregarEmpleadoAsync(Empleado);
            await ObtenerEmpleados();
        }
        private async Task EliminarEmpleado(ServiciosEmpleados emp)
        {
            bool resultado = await empleadoBL.EliminarEmpleadoAsync(emp.id);
            await ObtenerEmpleados();
        }
        private void EditarEmpleado(ServiciosEmpleados emp)
        {
            Empleado = emp;
        }
        private async Task ActualizarEmpleados()
        {
            bool resultado = await empleadoBL.ActualizarEmpleadoAsync(Empleado);
            await ObtenerEmpleados();
        }

    }
}
