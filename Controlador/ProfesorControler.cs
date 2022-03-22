using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;

namespace Controlador
{
    public class ProfesorControler : Persona
    {
        public void ActualizarDatos(DatosPersona persona)
        {
            ProfesoresDataAccess registrar = new ProfesoresDataAccess();
            registrar.Actualizar(persona);
        }

        public DatosPersona GetDatosPersona(int ID)
        {
            ProfesoresDataAccess obtener = new ProfesoresDataAccess();
            return obtener.GetAlumno(ID);
        }

        public List<DatosPersona> GetListaPorTipo(TipoDePersona Tipo)
        {
            throw new NotImplementedException();
        }

        public void Registrar(DatosPersona persona)
        {
            ProfesoresDataAccess registrar = new ProfesoresDataAccess();
            registrar.Registrar(persona);
        }
    }
}