import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NotesService } from '../notes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  public noteForm: FormGroup;

  showAdd = true;

  noteData: any;

  constructor(private formBuilder: FormBuilder, private service: NotesService, private route: ActivatedRoute, private router: Router, private location: Location) {
    router.getCurrentNavigation()?.extras.state;
  }

  ngOnInit(): void {
    this.init();
  }

  public addNote(): void {
    this.service.addNewNote(this.noteForm.value).subscribe(result =>
      this.router.navigateByUrl(''));
  }

  public saveNote(): void {
    this.service.updateNote(this.noteForm.value.id, this.noteForm.value).subscribe(() =>
      this.router.navigateByUrl(''));
  }

  private init(): void {
    debugger;
    if (this.route.snapshot.paramMap.get('id') !== null) {
      this.showAdd = false;
      this.noteForm = this.formBuilder.group({
        id: this.route.snapshot.paramMap.get('id'),
        title: this.route.snapshot.paramMap.get('title'),
        description: this.route.snapshot.paramMap.get('description')
      });
    }
    else {
      this.noteForm = this.formBuilder.group({
        title: [],
        description: []
      });
    }
  }

  backClicked() {
    this.location.back();
  }
}
