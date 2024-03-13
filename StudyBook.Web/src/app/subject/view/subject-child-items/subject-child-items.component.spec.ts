import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjectChildItemsComponent } from './subject-child-items.component';

describe('SubjectChildItemsComponent', () => {
  let component: SubjectChildItemsComponent;
  let fixture: ComponentFixture<SubjectChildItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubjectChildItemsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SubjectChildItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
