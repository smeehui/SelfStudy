class Person {
    private readonly name: string;
    private readonly age: number;
    protected gender: boolean;

    constructor(name:string,age:number) {
        this.name = name;
        this.age = age;
    }
    getName():string{
        return this.name;
    }

    getAge(): number {
        return this.age;
    }

    getInfo(): string {
        return `${this.name}, ${this.age}`;
    }

}

export class Teacher extends Person {
    constructor(name: string, age: number, gender: boolean) {
        super(name, age);
        this.gender = gender;
    }
    getInfo(): string {
        return super.getInfo() +`, ${this.gender}`;
    }
}

export default Person;