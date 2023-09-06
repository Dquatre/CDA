const deplacement = document.querySelector("#perso");
var abscisse = 0;
var ordonnee = 0;
var isDown = false;

document.querySelector("#down").addEventListener('click', function() {
    ordonnee+=10;
    deplacement.style.top = ordonnee +"px" ;
});

document.querySelector("#up").addEventListener('click', function() {
    ordonnee-=10;
    deplacement.style.top = ordonnee +"px" ;
});

document.querySelector("#right").addEventListener('click', function() {
    abscisse+=10;
    deplacement.style.left = abscisse +"px" ;
});

document.querySelector("#left").addEventListener('click', function() {
    abscisse-=10;
    deplacement.style.left = abscisse +"px" ;
});

document.addEventListener('keydown',function (e) {
    if (e.key === "ArrowLeft") {
        abscisse-=10;
        deplacement.style.left = abscisse +"px" ;
    }
    if (e.key === "ArrowUp") {    
        ordonnee-=10;
        deplacement.style.top = ordonnee +"px" ;
    }
    if (e.key === "ArrowRight") {
        abscisse+=10;
        deplacement.style.left = abscisse +"px" ;
    }
    if (e.key === "ArrowDown") {
        ordonnee+=10;
        deplacement.style.top = ordonnee +"px" ;
    }
});

document.querySelector("#perso").addEventListener('mousedown',function (e) {
    isDown =true;
});
document.querySelector("#perso").addEventListener('mouseup',function () {
    isDown =false;
});

document.addEventListener("mousemove",function (e) {
    if (isDown) {
        abscisse = e.clientX;
        ordonnee = e.clientY;
        deplacement.style.left = abscisse+"px";
        deplacement.style.top = ordonnee+"px";
    }    
});