"use strict";

document.addEventListener("DOMContentLoaded", () => {
	//task 1
	function CircleData() {
		let radius = prompt("Введите радиус");
		function getDiam(radius) {
			return radius * 2;
		}
		let getCirLen = function(radius) {
			return 2 * radius * Math.PI;
		};
		let getSquare = () => radius ** 2 * 2 ;
		
		return `Диаметр: ${getDiam(radius)} \n Длина окружности: ${getCirLen(
			radius  
		)} \n Площадь: ${getSquare(radius)}`;
	}

	//task 2
	function ThreeParameters(
		par1 = "по умолчанию",
		par2,
		par3 = "Введите значение par3"


	) {
		return "Параметры функции: " + par1 + " " + par2 + " " + par3;
	}

	//task 3
	let StudentList = ["Student1","Student2","Student3","Student4","Student5","Student6"
	];
	function checkStudents(
		currentStud = prompt(
			"Введите имена присутствующих студентов, разделяя их пробелом"
		)
	) {
		let studentsinclass = currentStud.split(" ");
		let count = 0;

		for (let student of studentsinclass) {
			for (let i = 0; i < StudentList.length; i++) {
				if (student == StudentList[i]) {
					count++;
				}
			}
		}

		return "Кол-во присутствующих студентов: " + count;
	}

	//task 4
	function getPass() {
		let abc = [
			"a","b","c","d","e",
			"f","g","h","i","j",
			"k","l","m","n","o",
			"p","q","r","s","t",
			"u","v","w","x","y",
			"z",
		];

		let numbers = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "0"];
		
		let TimeToGetPass = 0; 
		for (let symbol1 of abc)
			for (let symbol2 of abc)
				for (let symbol3 of abc)
					for (let symbol4 of abc)
						for (let symbol5 of abc)
							for (let symbol6 of numbers)
								for (let symbol7 of numbers)
									for (let symbol18 of numbers) {
										TimeToGetPass++;
									}
		TimeToGetPass *= 3;
		let years = Math.floor(TimeToGetPass / 31556952);
		TimeToGetPass %= 31556952;
		let months = Math.floor(TimeToGetPass / 2592000);
		TimeToGetPass %= 2592000;
		let days = Math.floor(TimeToGetPass / 86400,3);
		TimeToGetPass %= 86400;
		let hours = Math.floor(TimeToGetPass / 3600);
		TimeToGetPass %= 3600;
		let minutes = Math.floor(TimeToGetPass / 60);
		return `Чтобы подобрать пароль понадобится ${years} лет ${months} месяцев ${days} дней ${hours} часов ${minutes} минут.`;
	}

	//task 5
	function handlingInputs(userInput = prompt("Введите данные")) {
		if (userInput % 1 == 0) {
			return `Целое число, переведённое в 16-систему: ${Number(
				userInput
			).toString(16)}`;
		}

		if (+userInput == userInput && +userInput % 1 != 0) {
			let up = Math.ceil(userInput);
			let down = Math.floor(userInput);
			let near = Math.round(userInput);
			return `Дробное число, округлённое вверх: ${up}\n вниз: ${down}\n до ближайшего целого: ${near}`;
		}
		return `Строка\n в верхнем регистре: ${usersTxt.toUpperCase()}\n в нижнем регистре ${usersTxt.toLowerCase()}`;
	}

	//task 6
	function checkDictionary(
		DictionaryWord = prompt("Введите слово для задания: ").toLowerCase(),
		userInput = prompt("Введите словарное слово: ").toLowerCase()
	) {
		if (DictionaryWord.length != userInput.length) {
			return "Неверное количество введённых символов";
		}

		let faultArr = [];
		let flag = true;
		for (let symbInd in userInput ) {
			if (!(DictionaryWord[symbInd] == userInput[symbInd])) {
				faultArr.push(symbInd);
				flag = false;
			}
		}

		if (flag) {
			return "Слово введено правильно";
		} else {
			let stringOfMiss = "";
			for (let index of faultArr) {
				stringOfMiss +=
					'вместо "' +
					usersWord[index] +
					'" должна быть "' +
					DictionaryWord[index] +
					'", ';
			}
			return DictionaryWord + "\n" + usersWord + "\n" + stringOfMiss;
		}
	}

	//task 7
	function TriangleData(
		frstKat = prompt("Введите первый катет: "),
		scndKat = prompt("Введите второй катет: ")
	) {
		let hypot = Math.sqrt(frstKat ** 2 + scndKat** 2);
		let square = (frstKat * scndKat) / 2;
		let perim = hypot + +frstKat + +scndKat;
		let height = (frstKat * scndKat) / hypot;

		let frstSin = scndKat / hypot;
		let frstCos = frstKat / hypot;
		let frstTg = scndKat / frstKat;
		let frstCtg = frstKat / scndKat;
		return `Катеты ${frstKat} и ${scndKat}\n
	            Площадь: ${square}\n
	            Периметр: ${perim.toFixed(2)}\n
	            Высота: ${height.toFixed(2)}\n
	            Параметры для угла у первого катета\n
	            Синус: ${frstSin.toFixed(2)}\n
	            Косинус: ${frstCos.toFixed(2)}\n
	            Тангенс: ${frstTg}\n
	            Котангенс ${frstCtg}\n`;

	}

	while (true) {
		switch (+prompt("Введите номер задания")) {
			case 1:
				alert(CircleData());
				break;
			case 2:
				alert(ThreeParameters("SomeData"));
				break;
			case 3:
				alert(checkStudents());
				break;
			case 4:
				alert(getPass());
				break;
			case 5:
				alert(handlingInputs());
				break;
			case 6:
				alert(checkDictionary());
				break;
			case 7:
				alert(TriangleData());
				break;
			default:
				alert("Выход");
				return false;
		}
	}
});
