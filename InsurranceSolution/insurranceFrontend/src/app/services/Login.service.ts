import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
 
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
 
import { Usuario } from '../model/Usuario';
import { MessageService } from './message.service';
 
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
 
@Injectable({ providedIn: 'root' })
export class LoginService {
 
  private LoginsUrl = 'http://localhost:51719/api/Login'; 
   

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
 
  /** GET Logines from the server */
  Login (usuario: Usuario): Observable<string> {
    return this.http.post<string>(this.LoginsUrl, usuario, httpOptions).pipe(
      tap((token: string) => localStorage.setItem('Token', token)),
      catchError(this.handleError<string>('Login'))
    );
  }

  getToken():string{
    let token = '';
    token = localStorage.getItem('Token');
    return token;
  }
 
  logout(){

    localStorage.removeItem('Token');
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
 
  /** Log a LoginService message with the MessageService */
  private log(message: string) {
    this.messageService.add('LoginService: ' + message);
  }
}