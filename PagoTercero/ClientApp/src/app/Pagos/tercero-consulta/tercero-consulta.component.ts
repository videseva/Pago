import { Component, OnInit } from '@angular/core';
import {Tercero} from '../models/tercero';
import {TerceroService} from 'src/app/services/tercero.service';

@Component({
  selector: 'app-tercero-consulta',
  templateUrl: './tercero-consulta.component.html',
  styleUrls: ['./tercero-consulta.component.css']
})
export class TerceroConsultaComponent implements OnInit {
  terceros : Tercero[];
  searchText :string;
  
  constructor(private terceroServices : TerceroService) { }
  ngOnInit(): void {
    this.get();
  }
  get(){
    this.terceroServices.get().subscribe(result => {
      this.terceros = result;
    });
    console.log(this.terceros);
  }
}
