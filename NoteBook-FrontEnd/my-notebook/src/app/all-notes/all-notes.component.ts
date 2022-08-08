import { Component, OnInit } from '@angular/core';
import { NotesService } from '../notes.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-notes',
  templateUrl: './all-notes.component.html',
  styleUrls: ['./all-notes.component.scss']
})
export class AllNotesComponent implements OnInit {

  public notes: any;
  constructor(private service: NotesService, private router: Router) { }

  ngOnInit(): void {
    this.getAllNotes();
  }

  // method to get all nootes
  private getAllNotes(): void {
    this.service.getAllNotes().subscribe(result => {
      this.notes = result;
    });
  }

  onEdit(noteData : any){
    debugger;
    this.router.navigate(['/editnote', noteData.id, noteData.title, noteData.description]);
  }

  // Delete perticular Note
  onDelete(id: number){
    if(confirm('Are you want to Delete the Note?'))
    {
      this.service.deleteNote(id).subscribe(() => 
      this.getAllNotes());
    }
  }

  // Update perticular Note
  onUpdate(id: number){
    const newFormData = {id:id, title:'updated title', description: 'this is updated Description'};
      this.service.updateNote(id, newFormData).subscribe(() => {
        alert("Updated Successfully");
      });
  }

}
