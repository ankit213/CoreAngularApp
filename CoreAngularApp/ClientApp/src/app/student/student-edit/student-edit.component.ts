import { Component, OnInit, Input } from '@angular/core';
import { StudentService } from '../student.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'student-edit',
  templateUrl: 'student-edit.component.html'
})
export class StudentEditComponent implements OnInit {
  @Input() StudentId: string;
  editClick: boolean;
  constructor(private studentService: StudentService, private router: Router) {
    this.editClick = false;
  }
  studentForm: FormGroup;
  ngOnInit() {
    if (this.StudentId) {
      this.studentForm = new FormGroup({
        firstName: new FormControl(),
        lastName: new FormControl()
      })
      this.studentService.getStudentById(this.StudentId).then((result) => {
        if (result != null) {
          this.studentForm.get('firstName').setValue(result.FirstName);
          this.studentForm.get('lastName').setValue(result.LastName);
        }
      }).catch((reason) => {
        if (reason.status = 404)
          this.router.navigate(['login']);
      });;

    }
  }

  onSubmit(): void {
    this.editClick = true;
    if (this.studentForm.valid) {
      console.log(this.studentForm.value);
    }
  }

}
