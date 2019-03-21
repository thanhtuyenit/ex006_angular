import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AddStudentComponent } from './components/student/add-student/add-student.component';
import { HttpModule } from '@angular/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { StudentService } from './services/student/student.service';
import { ClassroomService } from './services/classroom/classroom.service';
import { StudentsComponent } from './components/student/students/students.component';
import { EditStudentComponent } from './components/student/edit-student/edit-student.component';

@NgModule({
  declarations: [
    AppComponent,
    AddStudentComponent,
    StudentsComponent,
    EditStudentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
         path: 'add-student',
         component: AddStudentComponent
      },
      {
        path: 'students',
        component: StudentsComponent
     },
     {
      path: 'edit-student/:id',
      component: EditStudentComponent
    },
    {
      path: 'delete-student/:id',
      component: EditStudentComponent
   },
      
   ]),
   HttpModule
  ],
  providers: [StudentService, ClassroomService],
  bootstrap: [AppComponent]
})
export class AppModule { }
