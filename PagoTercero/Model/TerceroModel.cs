using System;
using Entidad;
using PagoModel.Model;


namespace TerceroModel.Model
{
    public class TerceroInputModel{
        public string TerceroId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }

    public class TerceroViewModel{
         public string TerceroId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public TerceroViewModel(Tercero tercero)
        {
            TerceroId = tercero.TerceroId;
            Nombre = tercero.Nombre;
            Telefono = tercero.Telefono;
        }
    }
}