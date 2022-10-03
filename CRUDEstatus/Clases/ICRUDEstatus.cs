using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstatus.Clases
{
    internal interface ICRUDEstatus
    {
        void Eliminar(int idEstatus);
        void Actualizar(int idEstatus, string nombreEstatus, String Clave);
        void Agregar(string Nombre, string Clave);
        EstatusAlumnosEntity ConsultarUno(int idEstatus);
        List<EstatusAlumnosEntity> ObtenerTodos();
    }
}
