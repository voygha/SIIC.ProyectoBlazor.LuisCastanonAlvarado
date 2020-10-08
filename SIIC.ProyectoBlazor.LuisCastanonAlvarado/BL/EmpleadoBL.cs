using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.APIWebClient;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisCastanonAlvarado.BL
{
    public class EmpleadoBL
    {
        EmpleadosAPI empleadoBL;
        public EmpleadoBL(EmpleadosAPI _empleadoBL)
        {
            this.empleadoBL = _empleadoBL;
        }
        public async Task<List<ServiciosEmpleados>> GetEmpleadosAsync()
        {
            var empleados = await empleadoBL.GetEmpleadosAsync();
            return empleados;
        }
        public async Task<bool> AgregarEmpleadoAsync(ServiciosEmpleados empleado)
        {
            var guardo = await empleadoBL.AgregarEmpleadoAsync(empleado);
            return guardo;
        }
        public async Task<bool> EliminarEmpleadoAsync(Guid id)
        {
            var guardo = await empleadoBL.EliminarEmpleadoAsync(id);
            return guardo;
        }
        public async Task<bool> ActualizarEmpleadoAsync(ServiciosEmpleados empleado)
        {
            var guardo = await empleadoBL.ActualizarEmpleadoAsync(empleado);
            return guardo;
        }

    }

}
