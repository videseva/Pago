import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Pago } from '../Pagos/models/pago';
import { Tercero } from '../Pagos/models/tercero';


@Injectable({
  providedIn: 'root'
})
export class PagoService {
  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
   }

   getId(id : string): Observable <Tercero>{
    return this.http.get<Tercero>(this.baseUrl +'api/Tercero/'+id).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Tercero)
      })
      );
  }

}
