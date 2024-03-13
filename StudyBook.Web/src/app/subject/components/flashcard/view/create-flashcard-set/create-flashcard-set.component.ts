import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { FlashcardService } from '../../service/flashcard.service';
import { HttpResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FlashcardSet } from '../../model/flashcard-set';

@Component({
  selector: 'app-create-flashcard-set',
  templateUrl: './create-flashcard-set.component.html',
  styleUrl: './create-flashcard-set.component.css',
})
export class CreateFlashcardSetComponent {
  flashcardSetForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private _flashcardService: FlashcardService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.flashcardSetForm = this.formBuilder.group({
      id: [],
      name: ['', Validators.required],
      description: ['', Validators.required],
      flashcards: this.formBuilder.array([]),
    });
  }

  get flashcards(): FormArray {
    return this.flashcardSetForm.get('flashcards') as FormArray;
  }

  addFlashcard(): void {
    this.flashcards.push(
      this.formBuilder.group({
        id: [],
        question: ['', Validators.required],
        answer: ['', Validators.required],
      })
    );
  }

  removeFlashcard(index: number): void {
    this.flashcards.removeAt(index);
  }

  onSubmit(): void {
    const id = this.route.params.subscribe((params) => {
      const subjectId = params['id'];

      console.log(this.flashcardSetForm.value);
      this._flashcardService
        .createFlashcardSet(subjectId, this.flashcardSetForm.value)
        .subscribe(
          (response: HttpResponse<any>) => {
            console.log(response);
            this.router.navigate([`/subject/${subjectId}`]);
          },
          (error) => {
            window.alert("Error while creating flashcard set")
            console.log(error);
          }
        );
    });
  }
}
