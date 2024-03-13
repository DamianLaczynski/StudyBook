import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { SubjectOverviewComponent } from './subject/view/subject-overview/subject-overview.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { TestComponent } from './subject/components/test/view/test/test.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { EditSubjectComponent } from './subject/view/edit-subject/edit-subject.component';
import { CreateSubjectComponent } from './subject/view/create-subject/create-subject.component';
import { SubjectDetailsComponent } from './subject/view/subject-details/subject-details.component';
import { ListFlashcardSetComponent } from './subject/components/flashcard/view/list-flashcard-set/list-flashcard-set.component';
import { FlashcardComponent } from './subject/components/flashcard/view/flashcard/flashcard.component';
import { CreateFlashcardSetComponent } from './subject/components/flashcard/view/create-flashcard-set/create-flashcard-set.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'signIn', component: SignInComponent },
  { path: 'signUp', component: SignUpComponent },
  { path: 'subject', component: SubjectOverviewComponent },
  { path: 'subject/create', component: CreateSubjectComponent },
  { path: 'subject/:id', component: SubjectDetailsComponent, children:[
    { path: 'flashcard', component: ListFlashcardSetComponent },
    { path: 'tests', component: ListFlashcardSetComponent },
  ] },
  { path: 'subject/:id/edit', component: EditSubjectComponent },
  { path: 'subject/:id/flashcard/create', component: CreateFlashcardSetComponent },
  { path: 'subject/:subjectId/flashcard/:flashcardId', component: FlashcardComponent },
  { path: 'test/:id', component: TestComponent },
  { path: '**', component: NotFoundComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
