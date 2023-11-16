function Z1(){

    let res = ""
        
    if(arguments.length<=3){
    
        for(let i = +0; i<arguments.length; i++ ){
    
            res += arguments[i] + " "
    
        }
    
    console.log('Меньше 3-x аргументов: ' + res)
    
    }
    
    if(arguments.length > 3 && arguments.length <= 5){
    
        for(let i = +0; i<arguments.length; i++ ){
    
            res += typeof(arguments[i]) + " "
    
        }
        
    console.log('Больше 3-x аргументов, меньше 5: ' + res)
    
    }
    
    if(arguments.length > 5 && arguments.length <= 7){
        
    console.log('Больше 5-ти аргументов, меньше 7: ' + arguments.length)
    
    }
    
    if(arguments.length > 7){
        
        console.log('Количество аргумнтов силшком велико - Больше 7')
        
    }
               
    
    }
    
    Z1('Аргумент1', 'Аргумент2')
    Z1(true, 1, "1", 4)
    Z1(1,1,1,1,1,1)
    Z1(1,1,1,1,1,1,1,1,1,1,1)
    
    /*window.a
    alert(a) Ошибка  a is not defined*/
    
    /*alert(a)
    window.a = 2 Ошибка  a is not defined*/
    
    /*alert(a)
    window.a = 2 
    let a
    a ne opredeleno*/
    
    /*alert(a)
    window.a = 2 
    var a
    undefined*/
    
    /*alert(a)
    let a
    Ошибка  a is not defined*/
    
    /*
    let a = 2 
    window.a = 3
    alert(a)
    2*/
    
    /*
    var a = 2 
    window.a = 3
    alert(a)
    3
    */
    
    
    function makeCounter(){
    
        let currentCount = 1;
    
        return function(){
    
            return currentCount++;
    
        }
    
    }
    
    let counter = makeCounter()
    
    console.log(counter())
    console.log(counter())
    console.log(counter())
    
    let counter2 = makeCounter()
    console.log(counter2())//1 2 3 1
    
    /*
    let currentCount = 1;
    
    function makeCounter(){
        
        return function(){
    
            return currentCount++;
    
        }
    
    }
    
    let counter = makeCounter()
    let counter2 = makeCounter()
    
    console.log(counter())
    console.log(counter())
    
    console.log(counter2())
    console.log(counter2())
    1
    2
    3
    4
    */
    
    
    
    
    
    
    
    
    
    
    
    
    console.log(Z1.name)
    console.log(makeCounter.name)
    
    function carry(func){
    
        return function(a){
            return function(b){
                return function(c){
                    return func(a, b, c)    
                }
            }
        }
            
    
    }
    
    function Z6(a, b, c){
    
        console.log("Объем параллелепипеда: " + a*b*c)
    
    }
    
    let cZ6 = carry(Z6)
    
    cZ6(1)(2)(3)
    
    
    
    
    
    //Z7
    function* Move(){
    
    let x = 0
    let y = 0
    
    let i = 0
    
    
    while(i<10){
    
        let mv = prompt("Что будете делать?")
    
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
    i++
    }
       
    }
    
    let i = 0
    let Gen = Move()
    
    while(i<10)
    {
        alert(Gen.next().value)
        i++
    }
    