import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student/student.service';
import { Student } from 'src/app/models/student';
import { Classroom } from 'src/app/models/classroom';
import { Router } from '@angular/router';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  title = 'Student App';
  students: Student[] = [];
  classrooms: Classroom[] = [];

  constructor(
    private studentService: StudentService,
    private router: Router) {
  }
  ngOnInit(): void {
    this.getStudents();
  }

  getStudents() {
    this.studentService.getStudents().subscribe(
        value => {
            if (value['code'] === 200) {
              this.students = value['data'];
            } else {
                alert(value['code']);
            }
        },
        error => console.log(error)
    )
  }

  viewAddStudent(){
    this.router.navigate(['/add-student']);
  }

  deleteStudent(id : any) {
    if (confirm('Are you sure to delete this record?')){
      this.studentService.deleteStudent(id)
      .subscribe(res => {
          this.getStudents();
        }, (err) => {
          console.log(err);
        }
      );
    }   
  }
}
