import { Component, Input } from '@angular/core';
import { FlashcardSet } from '../../components/flashcard/model/flashcard-set';
import { Test } from '../../components/test/model/test';

@Component({
  selector: 'app-subject-child-items',
  templateUrl: './subject-child-items.component.html',
  styleUrl: './subject-child-items.component.css'
})
export class SubjectChildItemsComponent {
  @Input() flashcardSets!: FlashcardSet[]; 
  @Input() tests!: Test[]; 
}
