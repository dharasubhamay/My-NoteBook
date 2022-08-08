import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNoteComponent } from './add-note/add-note.component';
import { AllNotesComponent } from './all-notes/all-notes.component';

const routes: Routes = [
  {path: '', component: AllNotesComponent},
  {path: 'addnote', component: AddNoteComponent},
  {path: 'editnote/:id/:title/:description', component: AddNoteComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
