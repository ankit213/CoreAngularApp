import { NgModule } from '@angular/core';
import { StudentComponent } from './student.component';
import { studentRouting } from './student-routing.module';
import { StudentListComponent } from './student-list/student-list.component';
import { StudentService } from '../student/student.service';
import { StudentEditComponent } from './student-edit/student-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    StudentComponent,
    StudentListComponent,
    StudentEditComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    studentRouting,
    ReactiveFormsModule
  ],
  providers: [StudentService]
})
export class StudentModule { }
