using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEjemplo.Entidades
{
    //Colocamos Public Aqui Para que la clase se pueda encontrar en cualquier parte del proyecto
    public class TelefonoDetalle
    {
        //Esta es la llave primaria y luego de agregarla hay que agregar su libreria llamada using System.ComponentModel.DataAnnotations;
        [Key]
        // Atributos de nuestra clase 
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }

        //Constructor Con parametros
        public TelefonoDetalle( int idPersona, string tipoTelefono, string telefono)
        {
          
            IdPersona = idPersona;
            TipoTelefono = tipoTelefono;
            Telefono = telefono;
        }

        public TelefonoDetalle(int id, int idPersona, string tipoTelefono, string telefono)
        {
            Id = id;
            IdPersona = idPersona;
            TipoTelefono = tipoTelefono;
            Telefono = telefono;
        }


        //Constructor vacio
        public TelefonoDetalle()
        {
            Id = 0;
            IdPersona = 0;
            TipoTelefono = string.Empty;
            Telefono = string.Empty;
        }
    }
}
