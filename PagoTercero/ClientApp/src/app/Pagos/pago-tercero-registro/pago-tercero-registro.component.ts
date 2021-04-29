import { Component, Input, OnInit } from '@angular/core';
import { PagoService } from 'src/app/services/pago.service';
import { Pago } from '../models/pago';
import { Tercero } from '../models/tercero';

@Component({
  selector: 'app-pago-tercero-registro',
  templateUrl: './pago-tercero-registro.component.html',
  styleUrls: ['./pago-tercero-registro.component.css']
})
export class PagoTerceroRegistroComponent implements OnInit {
  idTercero : string;
  pago: Pago;
  tercero : Tercero;
  mensaje :string
  
  constructor(private pagoService : PagoService) { }
  
  ngOnInit(): void {
    this.tercero = new Tercero();
  }

  
  get(){
    this.pagoService.getId(this.idTercero).subscribe(result => {
      this.tercero = result;

      if(this.tercero != null){
        this.mensaje = "el usuario esta  registrado es : cc :  "+ this.tercero.terceroId +" --- nombre :"+ this.tercero.nombre +"  --Telefono: "+ this.tercero.telefono;
      }
      console.log(this.tercero);
    });
  }
 
}
