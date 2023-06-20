import Person from "./Person";

class Student extends Person {
    private readonly grade: string;
    constructor(name: string, age: number, grade: string) {
        super(name, age);
        this.grade = grade;
    }
    getGrade(): string {
        return this.grade;
    }

    getInfo(): string {
        return super.getInfo() + `, ${this.grade}`;
    }
}

export default Student;