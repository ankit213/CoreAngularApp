import { Injectable } from "@angular/core";
import { Http, Headers } from "@angular/http";
import { StudentModel } from "../student/student.model";
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';


@Injectable()
export class StudentService {
  private studentUrl = 'api/Student';
  private headers = new Headers({ 'Content-Type': 'application/json' });
  constructor(private http: Http) {

  }

  getStudents(): Promise<StudentModel[]> {
    return this.http.get(this.studentUrl).map(res => res.json()).toPromise();
  }

  getStudentById(studentId: string) {
    return this.http.get(this.studentUrl + '/' + studentId).map(res => res.json()).toPromise();
  }
}
