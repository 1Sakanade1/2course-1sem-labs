const dart = document.querySelector('.dart');
const wrapper = document.querySelector('.game-block');
let startX = 1;
let startY = 1;
let x = startX;
let y = startY;
let wasClicked = false;


function animate(x, y, startX, startY) {
    console.log(x + " "+ y +" "+ startX +" "+ startY)
    dart.style.backgroundColor = `#009900`;
    let dx = (startX - x);
    let dy = (startY - y);
    let tg = dy / dx;
    startX = dx < 0 ? startX - 3 * Math.abs(dx) : startX + 3 * Math.abs(dx);
    startY = dy < 0 ? startY - 3 * Math.abs(tg* dx) : startY + 3 * Math.abs(tg* dx);
    dart.style.left = `${startX}px`;
    dart.style.top = `${startY}px`;
}


dart.onmousedown = function(event) {
    if (wasClicked) {
        document.body.onmousemove = null; 
        document.body.onclick = () => animate(x, y, startX, startY);
        return;
    }
    dart.style.zIndex = '1000';
    wasClicked = wasClicked ? false : true;
    document.body.onmousemove = function(event) {
        if (startX === 1 && startY === 1) {

            startX = event.clientX;
            console.log(startX);
            dart.style.left = `${startX}px`;
            startY = event.clientY;
            console.log(startY);
            dart.style.top = `${startY}px`;
            document.body.append(dart);
        }
        if (Math.abs(startX - event.clientX) < 1100) {
            x = event.clientX -15 ;
        }
        if (Math.abs(startY - event.clientY) < 1150) {
            y = event.clientY -15 ;
        }

        dart.style.left = `${x}px`;
        dart.style.top = `${y}px`;
    };
};
