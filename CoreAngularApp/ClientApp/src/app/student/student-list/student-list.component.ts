import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';
import { StudentModel } from '../student.model';
import { Router } from '@angular/router';

@Component({
  selector: 'student-list',
  templateUrl: 'student-list.component.html'
})
export class StudentListComponent implements OnInit {
  studentList: Array<StudentModel>;
  studentId: string;

  constructor(private studentService: StudentService, private router: Router) {
    this.studentList = new Array<StudentModel>();
    this.studentId = "";
  }

  ngOnInit() {
    this.studentService.getStudents().then((result) => {
      this.studentList = result;
    }).catch((reason) => {
      if (reason.status = 404)
        this.router.navigate(['login']);
    });
  }

  editStudent(studentId) {
    this.studentId = studentId;
  }
}
