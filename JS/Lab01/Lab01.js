//task 1
function pow(x, n) {
    let result = 1;
  
    for (let i = 0; i < n; i++) {
      result *= x;
    }
  
    return result;
  }
  
  let x = prompt("x?", "");
  let n = prompt("n?", "");
  
  if (n < 0) {
    alert(`Степень ${n} не поддерживается,
      введите целую степень, большую 0`);
  } else {
    alert( pow(x, n) );
  }

//task 2

let username = "Sviatoslav"
let City = "Minsk"
let BirthYear = 2004
let ColorRed = "#F00" 
let answer = да 
let variable = Infinity 
let number = 532
let qperimeter = 120
let usermessage = "Введенные данные неверны"

//task 3

let a = 5;            //number
let name = "Name";    //string
let i = 0;            //number
let double = 0.23     //number
let result = 1 / 0;   //number
let answer2 = true;   //bool
let no = null;        //nullable

alert( typeof(no) );
alert( typeof(result) );

//task 4

let side1 = 45;
let side2 = 21 ;
let Aarea = side1*side2; 

//task 5 
function countsquares(side1, side2, squareside) {
  let squarearea = pow(squareside, 2);
  let qarea = side1 * side2;
  let  amountofsquares = qarea / squarearea;

  return Math.trunc(amountofsquares);
  }

alert( countsquares(side1, side2, 5) );

//task 6 

i = 2;    
 a = ++i;
let b = i++;

function compare(a, b) {  
  if(a > b) {
    return `${a} > ${b}`;
  }  
  if(a < b) {
    return `${a} < ${b}`;
  }  
  if(a == b) {
    return `${a} = ${b}`;
  } else {
    return "Не удалось сравнить эти два значения.";
  }
  }

alert( compare(a, b) );

//task 7 

let str1 = "Привет";
let str2 = "привет";
let str3 = "Пока";
let int1 = 45;
let str4 = "53";
let bool1 = false;
let int2 = 3;
let bool2 = true;
let str5 = "3";
let str6 = "5мм";
let null1 = null;
let undef1 = undefined;

alert( compare(str1, str2) );
alert( compare(str1, str3) );
alert( compare(int1, str4) );
alert( compare(bool1, int2) );
alert( compare(bool2, str5) ); 
alert( compare(int2, str6) );
alert( compare(null1, undef1) );

//task 8

let errormsg = ("Введённые пользователем данные неверные.");

alert(errormsg);
//task 9 

let ans = prompt("Какой сейчас год?");

if(ans == 2022) {
  alert("Верно.");
} else {
  alert (errormsg);
}

//task 10

let log  = prompt("Enter login(zxc)");       
let pass = prompt("Enter password(qwe)");    

if(log == "zxc" && pass == "qwe") {
  alert("Логин и пароль введены верно.");
} else {
  alert(errormsg);   
}

//task11
let math = confirm("Математика сдана?"); 
let rus = confirm("Русский сдан?");
let eng = confirm("Английский сдан?");


function StudentDestiny (math, rus, eng) {
  if(math == true && rus == true && eng == true) {
    return "Перевод на следующий курс";
  }

  if(math == false && rus == false && eng == false) {
    return "Отчисление";
  } 
  
  else {
    return "Пересдача";
  }
}

alert ( StudentDestiny(math, rus, eng) );

//task12
a = Number( prompt ("Введите a") );
b = Number( prompt ("Введите b") );

function summ (a,b) {
  let s = a+b;
  return s;
}

alert( "сумма a и b = " + summ(a, b) );

//task 13 
true + true; //2
0 + "5";     //05
5 + "мм";    //5мм
8/Infinity;  //0
9 * "\n9";   //81
null - 1;    //-1
"5" - 2;     //3
"5px" - 3;   //NaN
true - 3;    //-2 
7 || 0;      //7

alert(7 || 0);

//task 14
 
for (i = 1; i <= 10; i++){
  if( (i % 2) == 0) {
    alert (i+2);   
  } else {
    alert(`${i}мм`);
  }
}

//task 15

while(true){
  let chislo = prompt("Введите число");
  if(chislo > 100) break;
}



//task 16

var days = [
    'Пн', 'Вт', 'Ср',
    'Чт', 'Птн', 'Сб',
    'Вс'
];

let daynumber = prompt("Введите номер дня недели.");

if(daynumber > 7) {
  alert("День недели не может быть больше седьмого.");
} else
  alert (days[daynumber-1]);