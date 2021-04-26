using System;
using Entidad;
using TerceroModel.Model;

namespace PagoModel.Model
{
    public class PagoInputModel{
        public string PagoId { get; set; }
        public TerceroInputModel Tercero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal PorcentajeIva { get; set; }
        // no me pide ni el total ni el iva porque son atributos que se calculan por mi entidad.
    }
    public class PagoViewModel{
        public string PagoId { get; set; }
        public TerceroViewModel Tercero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public PagoViewModel(Pago pago)
             {
            PagoId = pago.PagoId;
            Valor = pago.Valor;
            Fecha = pago.Fecha;
            Tercero = new TerceroViewModel(pago.Tercero);
            PorcentajeIva = pago.PorcentajeIva;
            Iva = pago.Iva;
            Total = pago.Total;
        }
    }
}
