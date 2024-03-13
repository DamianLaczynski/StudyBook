import { Component, OnInit } from '@angular/core';
import { Flashcard } from '../../model/flashcard';
import { FlashcardSet } from '../../model/flashcard-set';
import { FlashcardService } from '../../service/flashcard.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-flashcard',
  templateUrl: './flashcard.component.html',
  styleUrl: './flashcard.component.css'
})
export class FlashcardComponent implements OnInit{
  currentFlashcard: Flashcard | undefined;
  flashcardSet!: FlashcardSet;
  id: number = 1;
  iterator: number = 0;

  constructor(private _flashcardService: FlashcardService, private route: ActivatedRoute)
  {

  }

  ngOnInit(): void {
    const id = this.route.params.subscribe((params) => {
      const subjectId = params['subjectId'];
      const flashcardId = params['flashcardId'];


      this._flashcardService.getFlashcardSetById(subjectId, flashcardId).subscribe(
        (data) => 
        {
          console.log(data);
          this.flashcardSet = data;
          this.currentFlashcard = this.flashcardSet.flashcards.at(this.iterator);
        },
        (error) =>
        {
          console.log(error);
        }
      );
    });
    
  }

  previous()
  {
    if(this.iterator > 0)
    {
      this.iterator--;
    } 

    this.setCurrentFlashcard();
  }
  next()
  {
    if(this.iterator < this.flashcardSet.flashcards.length - 1 )
    {
      this.iterator++;
    }  
    
    this.setCurrentFlashcard();
  }

  flip()
  {
    console.log("flip");
  }

  private setCurrentFlashcard()
  {
    this.currentFlashcard = this.flashcardSet.flashcards.at(this.iterator);
  }
}
