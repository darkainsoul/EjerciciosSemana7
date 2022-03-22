using System.Collections.Generic;

namespace Entidades
{
    public interface Persona
    {
        DatosPersona GetDatosPersona(int ID);

        void Registrar(DatosPersona persona);

        void ActualizarDatos(DatosPersona persona);

        List<DatosPersona> GetListaPorTipo(TipoDePersona Tipo);
    }
}