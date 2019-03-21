import { Injectable } from '@angular/core';
import {API_URL, httpOptions} from '../../define/apiURL';
import {Observable, of} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Student } from 'src/app/models/student';
import { catchError, tap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private studentURL = API_URL + '/students';

  constructor(private http: HttpClient) { }
  getStudents(): Observable<any> {
    return this.http.get(this.studentURL);
  }

  addStudent(student : any) : Observable<Student>{
    return this.http.post<Student>(this.studentURL+"/create", student, httpOptions).pipe(
      catchError(this.handleError<Student>('addStudent'))
    );
  }

  getStudentByID(id: number): Observable<Student> {
    const url = `${this.studentURL}/${id}`;
    return this.http.get<Student>(url).pipe(
      tap(_ => console.log(`fetched student id=${id}`)),
      catchError(this.handleError<Student>(`getStudentByID id=${id}`))
    );
  }

  
  deleteStudent (id : number): Observable<Student> {
    const url = `${this.studentURL}/${id}`;
    return this.http.delete<Student>(url, httpOptions).pipe(
      catchError(this.handleError<Student>('deleteStudent'))
    );
  }

  updateStudent (student : Student): Observable<any> {
    console.log(student);
    const url = `${this.studentURL}/${student.id}`;
    console.log(url);
    return this.http.put(url, student, httpOptions).pipe(
      catchError(this.handleError<any>('updated student'))
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
