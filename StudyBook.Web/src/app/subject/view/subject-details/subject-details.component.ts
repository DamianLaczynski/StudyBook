import { Component, OnInit } from '@angular/core';
import { Subject } from '../../model/subject';
import { SubjectService } from '../../service/subject.service';
import { FlashcardSet } from '../../components/flashcard/model/flashcard-set';
import { Test } from '../../components/test/model/test';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-subject-details',
  templateUrl: './subject-details.component.html',
  styleUrl: './subject-details.component.css'
})
export class SubjectDetailsComponent implements OnInit {
  subject!: Subject;
  flashcardSets!: FlashcardSet[];
  tests!: Test[];

  constructor(private _subjectService: SubjectService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];

      this._subjectService.getSubjectById(id).subscribe(
        (data) => {
          this.subject = data;
          this.flashcardSets = this.subject.flashcardSets;
          this.tests = this.subject.tests;
        },
        (error) =>
        {
          console.log(error);
        } 
      );
    });
    
  }



}
