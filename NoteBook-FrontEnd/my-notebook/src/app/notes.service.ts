import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  private basePath = 'https://localhost:44381/api/notes/';

  constructor(private http: HttpClient) { }

  // Get all Notes
  public getAllNotes() : Observable<any>{
    return this.http.get(this.basePath);
  }

  // Add New Note
  public addNewNote(note: any) : Observable<any>{
    return this.http.post(this.basePath, note);
  }

  // Delete Note
  public deleteNote(id: number){
    return this.http.delete(this.basePath + id);
  }

  // Update Note
  public updateNote(noteId: number, updatedNote: any) : Observable<any>{
    return this.http.put(this.basePath + noteId, updatedNote);
  }
}
