import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
 
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
 
import { Insurrance } from '../model/Insurrance';
import { MessageService } from './message.service';
import { LoginService } from './Login.service';
 

 
@Injectable({ providedIn: 'root' })
export class InsurranceService {
 
  private InsurrancesUrl = 'http://localhost:51719/api/Insurrance'; 
 
  constructor(
    private http: HttpClient,
    private messageService: MessageService,
    private loginService: LoginService) { }
 
  /** GET Insurrancees from the server */
  getInsurrances (): Observable<Insurrance[]> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'Bearer '+this.loginService.getToken()})
    };
    return this.http.get<Insurrance[]>(this.InsurrancesUrl, httpOptions)
      .pipe(
        tap(Insurrances => this.log(`fetched Insurrances`)),
        catchError(this.handleError('getInsurrances', []))
      );
  }
 
  /** GET Insurrance by id. Return `undefined` when id not found */
  getInsurranceNo404<Data>(id: number): Observable<Insurrance> {
    const url = `${this.InsurrancesUrl}/${id}`;
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'Bearer '+this.loginService.getToken()})
    };
    return this.http.get<Insurrance[]>(url, httpOptions)
      .pipe(
        map(Insurrancees => Insurrancees[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} Insurrance id=${id}`);
        }),
        catchError(this.handleError<Insurrance>(`getInsurrance id=${id}`))
      );
  }
 
  /** GET Insurrance by id. Will 404 if id not found */
  getInsurrance(id: number): Observable<Insurrance> {
    const url = `${this.InsurrancesUrl}/${id}`;
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'Bearer '+this.loginService.getToken()})
    };
    return this.http.get<Insurrance>(url,httpOptions).pipe(
      tap(_ => this.log(`fetched Insurrance id=${id}`)),
      catchError(this.handleError<Insurrance>(`getInsurrance id=${id}`))
    );
  }
 
 
  //////// Save methods //////////
 
  /** POST: add a new Insurrance to the server */
  addInsurrance (Insurrance: Insurrance): Observable<Insurrance> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'Bearer '+this.loginService.getToken()})
    };
    return this.http.post<Insurrance>(this.InsurrancesUrl, Insurrance, httpOptions).pipe(
      tap((Insurrance: Insurrance) => this.log(`added Insurrance w/ id=${Insurrance.id}`)),
      catchError(this.handleError<Insurrance>('addInsurrance'))
    );
  }
 
  /** DELETE: delete the Insurrance from the server */
  deleteInsurrance (Insurrance: Insurrance | number): Observable<Insurrance> {
    const id = typeof Insurrance === 'number' ? Insurrance : Insurrance.id;
    const url = `${this.InsurrancesUrl}/${id}`;
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'Bearer '+this.loginService.getToken()})
    };
    return this.http.delete<Insurrance>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted Insurrance id=${id}`)),
      catchError(this.handleError<Insurrance>('deleteInsurrance'))
    );
  }
 
  /** PUT: update the Insurrance on the server */
  updateInsurrance (Insurrance: Insurrance): Observable<any> {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'Bearer '+this.loginService.getToken()})
    };
    const url = `${this.InsurrancesUrl}/${Insurrance.id}`;
    return this.http.put(url, Insurrance, httpOptions).pipe(
      tap(_ => this.log(`updated Insurrance id=${Insurrance.id}`)),
      catchError(this.handleError<any>('updateInsurrance'))
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
 
  /** Log a InsurranceService message with the MessageService */
  private log(message: string) {
    this.messageService.add('InsurranceService: ' + message);
  }
}