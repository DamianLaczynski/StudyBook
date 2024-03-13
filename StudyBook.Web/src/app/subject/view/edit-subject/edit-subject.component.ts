import { Component, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subject } from '../../model/subject';

@Component({
  selector: 'app-edit-subject',
  templateUrl: './edit-subject.component.html',
  styleUrl: './edit-subject.component.css'
})
export class EditSubjectComponent {
  @Input() subject!: Subject;

  updateSubjectForm = new FormGroup({
    name: new FormControl(''),
    description: new FormControl('')
  });

  update()
  {

  }
}
