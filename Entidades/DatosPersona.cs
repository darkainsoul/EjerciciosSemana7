namespace Entidades
{
    public abstract class DatosPersona
    {
        public int ID
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }

        public int Edad
        {
            get; set;
        }

        public TipoDePersona Tipo
        {
            get; set;
        }
    }
}