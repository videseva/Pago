import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Tercero } from '../Pagos/models/tercero';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';
//import { error } from 'selenium-webdriver';

@Injectable({
  providedIn: 'root'
})
export class TerceroService {
  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }
    get(): Observable <Tercero[]>{
      return this.http.get<Tercero[]>(this.baseUrl +'api/Tercero').pipe(
        tap(_ => console.log('Datos registrado')),
        catchError(error =>{
          console.log("error al registrar")
          return of(error as Tercero[])
        })
        );
    }

    post(tercero : Tercero): Observable<Tercero>{
      return this.http.post<Tercero>(this.baseUrl + 'api/Tercero', tercero)
      .pipe(
        tap(_ => console.log('registrar')),
          catchError(error =>{
            console.log("error al registrar")
            return of(tercero)
        })
      );
    }
  }
