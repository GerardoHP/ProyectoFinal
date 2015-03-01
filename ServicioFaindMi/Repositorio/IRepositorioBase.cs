using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioFaindMi.Repositorio
{
    public interface IRepositorioBase<T>
    {
        void ActualizarObjeto(string id, T objeto);
        void AgregarObjeto(ref T objeto);
        void EliminarObjeto(string id);
        List<T> ObtenerObjeto();
        T ObtenerObjeto(string id);
    }
}
