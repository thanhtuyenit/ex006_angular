import { Classroom } from './classroom';

export class Student{
    id: number;
    name: string;
    address: string;
    dob: Date;
    classroomID: number;
    classroom: Classroom;
    /**
     *
     */
    constructor() {
        this.id = 0;
        this.name = '';
        this.dob = new Date();
        this.address = '';
        this.classroomID = 0;
        
    }
}