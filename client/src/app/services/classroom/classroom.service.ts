import { Injectable } from '@angular/core';
import {API_URL, httpOptions} from '../../define/apiURL';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Classroom } from 'src/app/models/classroom';
import { catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ClassroomService {

    private classroomURL = API_URL + '/classrooms';
  
    constructor(private http: HttpClient) { }
    getClassrooms(): Observable<any> {
      return this.http.get(this.classroomURL);
    }

    getClassroomByID(id: number): Observable<Classroom> {
      const url = `${this.classroomURL}/${id}`;
      return this.http.get<Classroom>(url).pipe(
        catchError(this.handleError<Classroom>(`getClassroomByID id=${id}`))
      );
    }

    private handleError<T> (operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
        // TODO: send the error to remote logging infrastructure
        console.error(error); // log to console instead
        // Let the app keep running by returning an empty result.
        return of(result as T);
      };
    }
  
}
