using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;


namespace Logica
{
    public class TerceroService
    {
        
        private readonly PagoContext _context;

        public TerceroService(PagoContext context)
        {
            _context = context;
        }

        public GuardarTerceroResponse GuardarTercero(Tercero tercero){
            try
            {
                var _tercero = _context.Terceros.Find(tercero.TerceroId);
                if (_tercero == null)
                {
                    _context.Terceros.Add(tercero);
                    _context.SaveChanges();
                    return new GuardarTerceroResponse(tercero);
                }

                return new GuardarTerceroResponse("El tercero ya se encuentra Registrado");
            }
            catch (Exception e)
            {
                return new GuardarTerceroResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
        public ConsultarTerceroResponse Consultar()
        {
            try
            {
                var terceros = _context.Terceros.ToList();
                return new ConsultarTerceroResponse(terceros);
            }
            catch (Exception e)
            {
                return new ConsultarTerceroResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

//Response
        public class GuardarTerceroResponse
        {
            public Tercero Tercero { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public GuardarTerceroResponse(Tercero tercero)
            {
                Tercero = tercero;
                Error = false;
            }

            public GuardarTerceroResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }

        }

        public class ConsultarTerceroResponse
        {
            public List<Tercero> Terceros { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }


            public ConsultarTerceroResponse(List<Tercero> terceros)
            {
                Terceros = terceros;
                Error = false;
            }

            public ConsultarTerceroResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
        }
    }
}