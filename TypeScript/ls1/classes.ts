
import Student from "./Student";
import Person, {Teacher} from "./Person";

let huy = new Person("huy", 12);
let smee = new Teacher("huy", 12, true);

let huyNguyen = new Student("Huy nguyen", 12, "5A");
console.log(huyNguyen.getInfo());