using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PagoService
    {
        private readonly PagoContext _context;
        public PagoService(PagoContext context)
        {
            _context = context;
        }

        public GuardarPagoResponse GuardarPago(Pago pago)
        {
            try
            {
                var tercero = _context.Terceros.Find(pago.TerceroId);
                if (tercero == null)
                {
                    _context.Terceros.Add(pago.Tercero);
                }
                else
                {
                    pago.Tercero = tercero;///No vuelva a buscar el Tercero
                }

                _context.Pagos.Add(pago);
                _context.SaveChanges();
                return new GuardarPagoResponse(pago);
            }
            catch (Exception e)
            {
                return new GuardarPagoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }

        public ConsultarPagoResponse Consultar()
        {
            try
            {
                var pagos = _context.Pagos.Include(p=>p.Tercero).ToList();
                return new ConsultarPagoResponse(pagos);
            }
            catch (Exception e)
            {
                return new ConsultarPagoResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        
        public BuscarPagoResponse BuscarPagoPorId(string id)
        {
            try
            {
                var pago = _context.Pagos.Find(id);
                if (pago != null)
                {
                    return new BuscarPagoResponse(pago);
                }
                return new BuscarPagoResponse("El Pago consutado no existe");
            }
            catch (Exception e)
            {
                return new BuscarPagoResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public BuscarPagoResponse BuscarPagoPorIdConTercero(string id)
        {
            try
            {
                var pago = _context.Pagos.Where(p => p.PagoId == id).Include(p => p.Tercero).FirstOrDefault();
                if (pago != null)
                {
                    return new BuscarPagoResponse(pago);
                }
                return new BuscarPagoResponse("El Pago consutado no existe");
            }
            catch (Exception e)
            {
                return new BuscarPagoResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }


         




        //Response
        
        public class GuardarPagoResponse{
            public Pago Pago { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarPagoResponse(Pago pago)
            {
                Pago = pago;
                Error = false;
            }

            public GuardarPagoResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }

    }

     public class BuscarPagoResponse
    {
        public Pago Pago { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public BuscarPagoResponse(Pago pago)
        {
            Pago = pago;
            Error = false;
        }

        public BuscarPagoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class ConsultarPagoResponse
    {
        public List<Pago> Pagos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarPagoResponse(List<Pago> pagos)
        {
            Pagos = pagos;
            Error = false;
        }

        public ConsultarPagoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
