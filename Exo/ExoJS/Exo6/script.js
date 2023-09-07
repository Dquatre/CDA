const deplacement = document.querySelector("#perso");
const sprite = document.querySelector("#link");
var isDown = false;
var noclip = false;

function deplace(dx, dy) {
    var deplacement_ok = true;
    var stylePerso = window.getComputedStyle(deplacement, null);
    var t = parseInt(stylePerso.top);
    var l = parseInt(stylePerso.left);
    var w = parseInt(stylePerso.width);
    var h = parseInt(stylePerso.height);
    var listeObs = document.querySelectorAll('.mur');
    listeObs.forEach(function (elt) {
        var styleObst = window.getComputedStyle(elt, null);
        var tob = parseInt(styleObst.top);
        var lob = parseInt(styleObst.left);
        var wob = parseInt(styleObst.width);
        var hob = parseInt(styleObst.height);
        deplacement_ok = deplacement_ok && depl_ok(tob, lob, wob, hob, t + dy, l + dx, w, h);
    });

    if (deplacement_ok||noclip) {
        deplacement.style.top = t + dy + 'px';
        deplacement.style.left = l + dx + 'px';
    }
}

function depl_ok(tob, lob, wob, hob, t, l, w, h) {
    // formule de détection des collisions
   if (l < lob + wob && l + w > lob && t < tob + hob && t + h > tob) {
        return false
    }
    return true;
}

document.querySelector("#down").addEventListener('click', function() {
    sprite.src = "img/linkBas.png";
    deplace(0, 10); 
});

document.querySelector("#up").addEventListener('click', function() {
    sprite.src = "img/linkHaut.png";
    deplace(0, -10);  
});

document.querySelector("#right").addEventListener('click', function() {
    sprite.src = "img/linkGauche.png";
    sprite.style.transform = "scaleX(-1)";
    deplace(10, 0); 
});

document.querySelector("#left").addEventListener('click', function() {
    sprite.src = "img/linkGauche.png";
    deplace(-10, 0);
});

document.addEventListener('keydown',function (e) {
    if (e.key === "ArrowLeft") {
        sprite.src = "img/linkGauche.png";
        sprite.style.transform = "scaleX(1)";
        deplace(-10, 0);
    }
    if (e.key === "ArrowUp") { 
        sprite.src = "img/linkHaut.png"; 
        deplace(0, -10);     
    }
    if (e.key === "ArrowRight") {
        sprite.src = "img/linkGauche.png";
        sprite.style.transform = "scaleX(-1)";
        deplace(10, 0); 
    }
    if (e.key === "ArrowDown") {
        sprite.src = "img/linkBas.png";
        deplace(0, 10); 
    }
    if (e.key === "c") {
        noclip = !noclip;
    }
});

document.querySelector("#perso").addEventListener('mousedown',function (e) {
    isDown =true;
    decalageX = e.clientX - deplacement.style.left.substring(0,deplacement.style.left.length-2);
    decalageY = e.clientY - deplacement.style.top.substring(0,deplacement.style.top.length-2);
});
document.querySelector("#perso").addEventListener('mouseup',function () {
    isDown =false;
});

document.addEventListener("mousemove",function (e) {
    if (isDown) {
        abscisse = e.clientX;
        ordonnee = e.clientY;
        deplacement.style.left = (abscisse - decalageX)+"px";
        deplacement.style.top = (ordonnee - decalageY)+"px";
    }    
});