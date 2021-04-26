using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using PagoModel.Model;
using TerceroModel.Model;


namespace PagoTercero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private PagoService _pagoService;
        public PagoController (PagoContext context)
        {
           _pagoService = new PagoService(context);
        }

        [HttpPost]
        public ActionResult<PagoViewModel> PostPago(PagoInputModel pagoinput)
        {
            var pago = MapearPago(pagoinput);
            var response = _pagoService.GuardarPago(pago);
            if (!response.Error)
            {
                var PagoViewModel = new PagoViewModel(pago);
                return Ok(PagoViewModel);
            }
            return BadRequest(response.Mensaje);
        }

        private Pago MapearPago(PagoInputModel pagoInput){
            var pago = new Pago(){
                PagoId = pagoInput.PagoId,
                TerceroId = pagoInput.Tercero.TerceroId,
                Tercero = new Tercero(){
                    TerceroId = pagoInput.Tercero.TerceroId,
                    Nombre = pagoInput.Tercero.Nombre,
                    Telefono = pagoInput.Tercero.Telefono  
                },
                Valor = pagoInput.Valor,
                Fecha = pagoInput.Fecha,
                PorcentajeIva = pagoInput.PorcentajeIva,
            };
            return pago;
        }
    }
}