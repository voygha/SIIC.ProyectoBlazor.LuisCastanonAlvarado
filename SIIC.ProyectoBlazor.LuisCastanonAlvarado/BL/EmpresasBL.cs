using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.APIWebClient;
using SIIC.ProyectoBlazor.LuisCastanonAlvarado.APIClient.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIC.ProyectoBlazor.LuisCastanonAlvarado.BL
{
    public class EmpresasBL
    {
        EmpresasAPI empresasBL;
        public EmpresasBL(EmpresasAPI _empresasBL)
        {
            this.empresasBL = _empresasBL;
        }
        public async Task<List<ServiciosEmpresas>> GetEmpresasAsync()
        {
            var empresas = await empresasBL.GetEmpresasAsync();
            return empresas;
        }
        public async Task<bool> AgregarEmpresaAsync(ServiciosEmpresas empresas)
        {
            var guardo = await empresasBL.AgregarEmpresaAsync(empresas);
            return guardo;
        }
        public async Task<bool> EliminarEmpresaAsync(Guid id)
        {
            var guardo = await empresasBL.EliminarEmpresaAsync(id);
            return guardo;
        }
       
        public async Task<bool> ActualizarEmpresaAsync(ServiciosEmpresas empresas)
        {
            var guardo = await empresasBL.ActualizarEmpresaAsync(empresas);
            return guardo;
        }



    }
}
