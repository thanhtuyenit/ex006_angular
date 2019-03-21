import { Component, OnInit } from '@angular/core';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { Classroom } from 'src/app/models/classroom';
import { NgForm } from '@angular/forms';
import { StudentService } from 'src/app/services/student/student.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {

  classrooms: Classroom[] = [];
  
  constructor(
    private ClassroomService : ClassroomService,
    private StudentService: StudentService, 
    private Router: Router
    ) { }

  ngOnInit() {
    this.getClassrooms();
  }

  getClassrooms() {
    this.ClassroomService.getClassrooms().subscribe(
        value => {
            if (value['code'] === 200) {
              this.classrooms = value['data'];
            } else {
                alert(value['code']);
            }
        },
        error => console.log(error)
    )
  }

  addStudent(form : NgForm) {
    this.StudentService.addStudent(form)
      .subscribe(res => {
          this.Router.navigate(['/students']);
        }, (err) => {
          console.log(err);
        });
  }
}
