import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
 
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
 
import { TiposCubrimiento } from '../model/TiposCubrimiento';
import { MessageService } from './message.service';
 
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
 
@Injectable({ providedIn: 'root' })
export class TiposCubrimientoService {
 
  private TiposCubrimientosUrl = 'http://localhost:51719/api/TiposCubrimientos'; 
 
  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
 
  /** GET TiposCubrimientoes from the server */
  getTiposCubrimientos (): Observable<TiposCubrimiento[]> {
    return this.http.get<TiposCubrimiento[]>(this.TiposCubrimientosUrl)
      .pipe(
        tap(TiposCubrimientos => this.log(`fetched TiposCubrimientos`)),
        catchError(this.handleError('getTiposCubrimientos', []))
      );
  }
 
  
 
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
 
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
 
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
 
  /** Log a TiposCubrimientoService message with the MessageService */
  private log(message: string) {
    this.messageService.add('TiposCubrimientoService: ' + message);
  }
}