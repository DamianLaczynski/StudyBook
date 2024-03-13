import { Component } from '@angular/core';
import { SubjectService } from '../../service/subject.service';
import { Subject } from '../../model/subject';
import { FormGroup, FormControl } from '@angular/forms';
import { CreateSubjectRequest } from '../../model/create-subject-request';
import { Router } from '@angular/router';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-create-subject',
  templateUrl: './create-subject.component.html',
  styleUrl: './create-subject.component.css'
})
export class CreateSubjectComponent {
  subject: CreateSubjectRequest = {name: '', description: ''};
  constructor(private _subjectService: SubjectService, private router: Router) { }

  subjectForm = new FormGroup({
    name: new FormControl(''),
    description: new FormControl('')
  });

  create()
  {
      this.subject.name = this.subjectForm.controls.name.value;
      this.subject.description = this.subjectForm.controls.description.value;
    this._subjectService.createSubject(this.subject).subscribe(
      (response: HttpResponse<unknown>) => {
          //TODO navigate to subject details
          this.router.navigate(['/subject']);
        },
      (error) => { 
        console.log(error); 
      }
    );
  }
}
