import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import {Tercero} from '../models/tercero';
import {TerceroService} from 'src/app/services/tercero.service';

@Component({
  selector: 'app-tercero-registro',
  templateUrl: './tercero-registro.component.html',
  styleUrls: ['./tercero-registro.component.css']

})
export class TerceroRegistroComponent implements OnInit {
  tercero : Tercero;
  constructor(private terceroServices : TerceroService) { }

  ngOnInit(): void {
   this.tercero = new Tercero();
  }

  RegistrarTercero(){
    this.terceroServices.post(this.tercero).subscribe(p => {
      if(p != null){
        alert("Se registro con exito su tercero");
        this.tercero = p;        
      }
    });
  }
}