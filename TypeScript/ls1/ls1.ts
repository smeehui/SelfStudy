// // let number : number = 1;
// // let str: string = '123';
// // let a: string = str.split("", 3).toString();
// // console.log(a);
//
// // let person:{name: string,age:number} = {name : "quan",age: 10};
//
// // let arr: [string, string, boolean?] = ["123","123"];
// // console.log(arr);
//
// enum Numeric {
//     ONE=1,
//     TWO ,
//     THREE
// }
//
// enum Letter {
//     A = "a",
//     B = "b",
//     C = "c",
// }
//
// enum Word {
//     ABC="ABC"
//     // function getValue (){};
// }
//
// // console.log(Word.ABC==true);
//
// console.log("a"===Letter.A)
// // console.log(Numeric.ONE);
// //
// // function getNum (number: Numeric):void {
// //     console.log(number);
// //     return;
// // }
// function getLetter (letter: Letter):void {
//     console.log(letter);
//     return;
// }
//
// // getLetter();
//
// // getNum(4);
//
// let a:{name: string, age: number}  = {name: "huy", age: 10};
//
// function sum (...args: number[]):number {
//     return args.reduce((initV: number, total: number) => initV + total);
// }
// function multiple (...args: number[]):number {
//     return args.reduce((initV: number, total: number) => initV * total);
// }
//
// function sum1 (a:number, b:number):number;
// function sum1 (a:string, b:string):string;
//
//
// function sum1(a: any, b: any): number | string {
//     return a + b;
// }
//
//
// console.log(multiple(1,2,3,10));