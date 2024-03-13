import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { SubjectOverviewComponent } from './subject/view/subject-overview/subject-overview.component';
import { FlashcardComponent } from './subject/components/flashcard/view/flashcard/flashcard.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { TestComponent } from './subject/components/test/view/test/test.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { EditSubjectComponent } from './subject/view/edit-subject/edit-subject.component';
import { CreateSubjectComponent } from './subject/view/create-subject/create-subject.component';
import { SubjectDetailsComponent } from './subject/view/subject-details/subject-details.component';
import { ListFlashcardSetComponent } from './subject/components/flashcard/view/list-flashcard-set/list-flashcard-set.component';
import { ListTestComponent } from './subject/components/test/view/list-test/list-test.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateFlashcardSetComponent } from './subject/components/flashcard/view/create-flashcard-set/create-flashcard-set.component';
import { SubjectChildItemsComponent } from './subject/view/subject-child-items/subject-child-items.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    SubjectOverviewComponent,
    FlashcardComponent,
    HomeComponent,
    AboutComponent,
    NotFoundComponent,
    TestComponent,
    SignInComponent,
    SignUpComponent,
    CreateSubjectComponent,
    EditSubjectComponent,
    SubjectDetailsComponent,
    ListFlashcardSetComponent,
    ListTestComponent,
    CreateFlashcardSetComponent,
    SubjectChildItemsComponent

  ],
  imports: [
    BrowserModule, 
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
