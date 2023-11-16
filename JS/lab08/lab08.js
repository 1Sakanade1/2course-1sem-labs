$(document).ready(function(){
    // табы на js
    document.querySelector('#surname').addEventListener('blur', function(){
        if (!/^[A-Za-z]+$/.test(this.value)){
            console.log("Некорректная фамилия");
            document.getElementById(document.querySelector('#surname').id).style.textDecoration = "underline solid red";
        }
    })
    document.querySelector('#surname').addEventListener('blur', function(){
        if (/^[A-Za-z]+$/.test(this.value)){
            document.getElementById(document.querySelector('#surname').id).style.textDecoration = "none";
        }
    })
    document.querySelector('#name').addEventListener('blur', function(){
        if (!/^[A-Za-z]+$/.test(this.value)){
            console.log("Некорректное имя");
            document.getElementById(document.querySelector('#name').id).style.textDecoration = "underline solid red";
        }
    })
    document.querySelector('#name').addEventListener('blur', function(){
        if (/^[A-Za-z]+$/.test(this.value)){
            document.getElementById(document.querySelector('#name').id).style.textDecoration = "none";
        }
    })
    document.querySelector('#birthdate').addEventListener('blur', function(){
        if (!/[0-9]+$/.test(this.value)&&this.value.length!=6){
            console.log("Некорректная дата рождения");
            document.getElementById(document.querySelector('#birthdate').id).style.textDecoration = "underline solid red";
        }
    })
    document.querySelector('#birthdate').addEventListener('blur', function(){
        if (/[0-9]+$/.test(this.value)){
            document.getElementById(document.querySelector('#birthdate').id).style.textDecoration = "none";
        }
    })
    document.querySelector('#register').onclick = function(){

        var chbox = document.getElementById(document.querySelector('#ckbox').id);

        if($(chbox).is(":checked"))
        {
            alert("форма отправлена!"); 
        }
        else
        {
            alert("Отметьте чекбокс!");
        }
    
    }


    $(".dws-form").on("click",".tab",function(){
        
        //удаление класса active
        $(".dws-form ").find(".active").removeClass("active");
        
        //добавляем active
        $(this).addClass("active");
        
        //выборка элемента по индексу 
        $(".tab-form").eq($(this).index()).addClass("active");
    })
});

