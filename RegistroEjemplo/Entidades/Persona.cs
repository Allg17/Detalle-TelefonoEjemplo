using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEjemplo.Entidades
{
    //Colocamos Public Aqui Para que la clase se pueda encontrar en cualquier parte del proyecto
    public class Persona
    {

        //Esta es la llave primaria y luego de agregarla hay que agregar su libreria llamada using System.ComponentModel.DataAnnotations;
        [Key]
        //Atributos de nuestra clase 
        public int IdPersona { get; set; }
        public string  Nombre { get; set; }
        public string Cedula { get; set; }
        public string  Direccion { get; set; }

        //Lista tipo TelefonoDetalle 
        public virtual List<TelefonoDetalle> Telefono { get; set; }

        //Constructor Con parametros
        public Persona(int idPersona, string nombre, string cedula, string direccion, List<TelefonoDetalle> telefono)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            Cedula = cedula;
            Direccion = direccion;
            Telefono = telefono;
        }

        

        //Constructor vacio
        public Persona()
        {
            IdPersona = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = new List<TelefonoDetalle>();
        }
    }
}
