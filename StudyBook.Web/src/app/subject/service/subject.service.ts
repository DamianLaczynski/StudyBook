import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { Subject } from '../model/subject';
import { CreateSubjectRequest } from '../model/create-subject-request';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private readonly apiUrl: string = "/api/subject"
  constructor(private _http: HttpClient) { }

  getAllSubjects(): Observable<Subject[]>
  {
    return this._http.get<Subject[]>(this.apiUrl);
  }

  getSubjectById(id: number): Observable<Subject>
  {
    return this._http.get<Subject>(`${this.apiUrl}/${id}`);
  }

  createSubject(subject: CreateSubjectRequest): Observable<HttpResponse<unknown>>
  {
    return this._http.post<HttpResponse<unknown>>(this.apiUrl, subject, { observe: 'response' });
  }
  deleteSubjectById(id: number): Observable<HttpResponse<unknown>>
  {
    return this._http.delete<HttpResponse<unknown>>(`${this.apiUrl}/${id}`, { observe: 'response' });
  }
}
