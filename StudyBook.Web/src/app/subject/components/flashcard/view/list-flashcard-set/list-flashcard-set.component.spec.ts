import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListFlashcardSetComponent } from './list-flashcard-set.component';

describe('ListFlashcardSetComponent', () => {
  let component: ListFlashcardSetComponent;
  let fixture: ComponentFixture<ListFlashcardSetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListFlashcardSetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListFlashcardSetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
