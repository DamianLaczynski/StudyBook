import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Test } from '../model/test';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  private readonly apiUrl = "/api/subject";
  constructor(private _http: HttpClient) { }

  getAllTests(): Observable<Test[]>
  {
      return this._http.get<Test[]>(this.apiUrl);
  }

  getTestById(subjectId: number, testId: number): Observable<Test>
  {
      return this._http.get<Test>(`${this.apiUrl}/${subjectId}/test/${testId}`);
  }

  createTest(test: Test, subjectId: number): Observable<HttpResponse<Test>>
  {
      return this._http.post<HttpResponse<Test>>(`${this.apiUrl}/${subjectId}/test`, test);
  }

  deleteTest(subjectId: number, testId: number): Observable<HttpResponse<unknown>>
  {
    return this._http.delete<HttpResponse<unknown>>(`${this.apiUrl}/${subjectId}/test`, {observe: 'response'});
  }

  updateTest(subjectId: number, testId: number, updatedTest: Test): Observable<Test>
  {
    return this._http.put<Test>(`${this.apiUrl}/${subjectId}/test/${testId}`, updatedTest);
  }
  
}
