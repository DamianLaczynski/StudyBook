import { Component, Input } from '@angular/core';
import { FlashcardSet } from '../../model/flashcard-set';

@Component({
  selector: 'app-list-flashcard-set',
  templateUrl: './list-flashcard-set.component.html',
  styleUrl: './list-flashcard-set.component.css'
})
export class ListFlashcardSetComponent {
  @Input() flashcardSets!: FlashcardSet[];
}
