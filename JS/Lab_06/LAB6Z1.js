"use strict"

document.addEventListener("DOMContentLoaded", () => {
    function firstTask() {

        let defaultRect = {
            geomFigure: "Rectangle",
            width: 200,
            height: 200,
            color: "YELLOW",
            borderColor: "BLACK",
        }

        let customRect = {
            width: 100,
            height: 100,
        }

        customRect.__proto__ = defaultRect;

        let defaultCircle = {
            geomFigure: "Circle",
            width : 200,
            height : 200,
            color : "WHITE",
            borderColor: "BLACK"
        }

        let customCircle = {
            color : "GREEN",
        }

        customCircle.__proto__ = defaultCircle;

        let defaultTrian = {
            geomFigure: "Triangle",
            width: 200,
            height: 200,
            color: "WHITE",
            borderColor: "BLACK",
            numOfLines: 1
        }

        let customTrian = {
            numOfLines: 3
        }

        customTrian.__proto__ = defaultTrian;

        let CircleDiff = "Отличительные черты:\n";
        for(let key in customCircle) {
            if(customCircle[key] != defaultCircle[key]) CircleDiff += "Свойство: " + key + " со значением " + customCircle[key];
        }
        alert(CircleDiff);

        let trianIm = "Описывающие черты:\n";
        for(let key in customTrian) {
            trianIm += "Свойство: " + key + " значение " + customTrian[key] + "\n";
        }
        alert(trianIm);

        let colorInst = customRect.hasOwnProperty("color");
        colorInst? alert("Есть") : alert("Нету");
    }

    firstTask();

})