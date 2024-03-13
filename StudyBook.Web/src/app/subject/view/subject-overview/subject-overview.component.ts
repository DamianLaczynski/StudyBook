import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from '../../model/subject';
import { SubjectService } from '../../service/subject.service';
import { HttpResponse, HttpStatusCode } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-subject-overview',
  templateUrl: './subject-overview.component.html',
  styleUrl: './subject-overview.component.css'
})
export class SubjectOverviewComponent implements OnInit, OnDestroy {
  subjectEntries: Subject[] = [];
  subjectEntriesSub = new Subscription();

  selectedSubject!: Subject;

  constructor(private _subjectService: SubjectService) { }

  ngOnInit(): void {
    this._subjectService.getAllSubjects().subscribe(
      (data) => {
        this.subjectEntries = data;
      },
      (error) => {
        console.log(error);
      }
      );
  }
  ngOnDestroy(): void {
    this.subjectEntriesSub.unsubscribe();
  }

  addSubject(subject: Subject)
  {
    this.selectedSubject = subject;
  }

  deleteSubject(subject: Subject)
  {
    this._subjectService.deleteSubjectById(subject.id).subscribe(
      (response: HttpResponse<unknown>) => {

        if(response.status == HttpStatusCode.NoContent)
        {
          window.alert("DELETED");

          //remove from local container
          let indexOfSubject = this.subjectEntries.indexOf(subject);
          this.subjectEntries.splice(indexOfSubject, 1);
        }
        
      },
      (error) => { console.log(error); }
    );
  }

}
