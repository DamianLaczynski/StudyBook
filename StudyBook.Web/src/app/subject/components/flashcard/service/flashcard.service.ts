import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FlashcardSet } from '../model/flashcard-set';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FlashcardService {
  private readonly apiUrl: string = '/api/subject';

  constructor(private _http: HttpClient) { }

  getAllFlashcardSets(): Observable<FlashcardSet[]>
  {
      return this._http.get<FlashcardSet[]>(this.apiUrl);
  }

  getFlashcardSetById(subjectId: number, flashcardSetId: number): Observable<FlashcardSet>
  {
      return this._http.get<FlashcardSet>(`${this.apiUrl}/${subjectId}/flashcardSet/${flashcardSetId}`);
  }

  createFlashcardSet(subjectId: number, flashcardSet: FlashcardSet): Observable<HttpResponse<any>>
  {
      return this._http.post<HttpResponse<any>>(`${this.apiUrl}/${subjectId}/flashcardSet`, flashcardSet);
  }

  deleteFlashcardSet(subjectId: number, flashcardSetId: number): Observable<HttpResponse<unknown>>
  {
    return this._http.delete<HttpResponse<unknown>>(`${this.apiUrl}/${subjectId}/flashcardSet`, {observe: 'response'});
  }

  updateFlashcardSet(subjectId: number, flashcardSetId: number, updatedFlashcardSet: FlashcardSet): Observable<FlashcardSet>
  {
    return this._http.put<FlashcardSet>(`${this.apiUrl}/${subjectId}/flashcardSet/${flashcardSetId}`, updatedFlashcardSet);
  }

}
