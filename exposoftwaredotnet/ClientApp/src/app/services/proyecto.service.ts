import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Proyecto } from '../inscripcion/models/proyecto';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class ProyectoService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
    {
      this.baseUrl = baseUrl;
    }

    get(): Observable<Proyecto[]> {
      return this.http.get<Proyecto[]>(this.baseUrl + 'api/Proyecto')
      .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Proyecto[]>('Consulta Proyecto', null))
      );
    }
  
    post(proyecto: Proyecto): Observable<Proyecto> {
      return this.http.post<Proyecto>(this.baseUrl + 'api/Proyecto', proyecto)
      .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Proyecto>('Registrar Proyecto', null))
      );
    }
}
