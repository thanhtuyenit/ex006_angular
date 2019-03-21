import { Component, OnInit } from '@angular/core';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { StudentService } from 'src/app/services/student/student.service';
import { FormGroup , Validators, NgForm} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/models/student';
import { Classroom } from 'src/app/models/classroom';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit { 
  classroomList: Classroom[] = [];
  student: Student;
  constructor(
    private ClassroomService : ClassroomService,
    private StudentService: StudentService, 
    private Router: Router,
    private ActivatedRoute: ActivatedRoute,
    ) {
        this.student = new Student();
     }

  ngOnInit() {
    this.getClassrooms();
    this.getStudent(this.ActivatedRoute.snapshot.params['id']);
  }

  getClassrooms() {
    this.ClassroomService.getClassrooms().subscribe(
        value => {
            if (value['code'] === 200) {
              this.classroomList = value['data'];
            } else {
                alert(value['code']);
            }
        },
        error => console.log(error)
    )
  }

  getStudent(id : any) {
    this.StudentService.getStudentByID(id).subscribe(
      value => {
        if(value['code'] === 200){
          this.student = value['data'];
        }else{
          alert("error");
        }
    });
  }

  editStudent() {
    this.StudentService.updateStudent(this.student)
      .subscribe(res => {
        this.Router.navigate(['/students']);
        }, (err : any) => {
          console.log(err);        
        }
      );
  }
}
