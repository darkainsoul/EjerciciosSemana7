using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;

namespace Controlador
{
    public class AlumnoControler : Persona
    {
        public void ActualizarDatos(DatosPersona persona)
        {
            AlumnosDataAccess registrar = new AlumnosDataAccess();
            registrar.Actualizar(persona);
        }

        public DatosPersona GetDatosPersona(int ID)
        {
            AlumnosDataAccess obtener = new AlumnosDataAccess();
            return obtener.GetAlumno(ID);
        }

        public List<DatosPersona> GetListaPorTipo(TipoDePersona Tipo)
        {
            throw new NotImplementedException();
        }

        public void Registrar(DatosPersona persona)
        {
            AlumnosDataAccess registrar = new AlumnosDataAccess();
            registrar.Registrar(persona);
        }
    }
}