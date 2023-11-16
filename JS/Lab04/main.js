"use strict";
document.addEventListener("DOMContentLoaded", () => {
//задание 1
	function ArgumentWork() {
		let outstr = "" ;

		if(arguments.length<4){
			for (let i = 0; i < arguments.length; i++) {
		 		outstr += arguments[i];
			}
			alert (outstr);
		}
		else if(arguments.length < 6){
			for (let i = 0; i < arguments.length; i++) {
				outstr += typeof(arguments[i]);
		   }
		   alert (outstr);
		}
		else if(arguments.length < 8){
			alert (arguments.length);
		}
		else if(arguments.length > 7){
			alert ("задано слишком много аргументов");
		}
		else{
			alert ("arguments out of range");
		}
	}
	  

//задание 2

//window.a;    //ничего т.к. а не определена
//alert (a);

//alert (a);   //ничего т.к. а не определена
//window.a;

//alert (a);   //ничего т.к. let после alert
//window.a;
//let a ;

//alert (a);   //undefined 
//window.a;
//var a ;

//alert (a);   //ничего т.к. алерт вызван до определения let 
//let a = 2;

//let a = 2;    // 2       2 т.к  виндоу не взаимодействует с let
//window.a = 3;
//alert (a);

//var a = 2;	//3		   3 т к теперь а - var
//window.a = 3;
//alert (a);





	while (true) {
		switch (+prompt("Введите номер задания")) {
			case 1:
				ArgumentWork("hello","everyone",2,4,1,1);
				break;
			case 3:
					//задание 3
				let s = 5;			//5
				function sum(){
					alert(s);
				}
				sum();
				break;
			case 4:
    
				function makeCounter(){
    
					let currentCount = 1;
				
					return function(){
				
						return currentCount++;
				
					}
				
				}

				let counter = makeCounter()
    
				alert(counter())
				alert(counter())
				alert(counter())
				
				let counter2 = makeCounter()
				alert(counter2())//1 2 3 1
				break;
				
					
			case 5:
//				let currentCount = 1;
//    
//				function makeCounter(){
//					
//					return function(){
//				
//						return currentCount++;
//				
//					}
//				
//				}
//				
//				let counter = makeCounter()
//				let counter2 = makeCounter()
//				
//				alert(counter())
//				alert(counter())
//				
//				alert(counter2())
//				alert(counter2())  // 1 2 3 4
//				break;
			
			case 6:

			alert(ArgumentWork.name);
			alert(makeCounter.name);
			break;

			case 7:
				function volume (l) {
					return (w) => {
						return (h) => {
							return l * w * h
						}
					}
				}

				alert(volume(2)(3)(5));

				let volume2 = volume(4)(2);

				alert(volume2(8));
				break;

			case 8:

				function* Move(){
    
					let x = 0;
					let y = 0;
					
					let counter = 0;
					
					
					while(counter<10){
					
						let mv = prompt("какой шаг сделать?")
					
						 switch(mv){
					
						case "left":
							x--
							break
						case "right":
							x++
							break
						case "up":
							y++
							break
						case "down":
							y--
							break
					
						}
					
					yield `{x:${x}; y:${y} }`
					counter++
					}
					   
					}
					
					let i = 0
					let Gen = Move()
					
					while(i<10)
					{
						alert(Gen.next().value)
						i++
					}

				break;

		}
					
	}

});
