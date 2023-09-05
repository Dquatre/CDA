
document.querySelector("#down").addEventListener('click', function() {
    var deplacement = document.querySelector("#perso");
    var marge = deplacement.style.marginTop+10;
    deplacement.style.marginTop = parseInt(marge) + 10 +"px" ;
});

document.querySelector("#up").addEventListener('click', function() {
    var deplacement = document.querySelector("#perso");
    var marge = deplacement.style.marginTop+10;
    deplacement.style.marginTop = parseInt(marge) - 10 +"px" ;
});

document.querySelector("#right").addEventListener('click', function() {
    var deplacement = document.querySelector("#perso");
    var marge = deplacement.style.marginLeft+10;
    deplacement.style.marginLeft = parseInt(marge) + 10 +"px" ;
});

document.querySelector("#left").addEventListener('click', function() {
    var deplacement = document.querySelector("#perso");
    var marge = deplacement.style.marginLeft+10;
    deplacement.style.marginLeft = parseInt(marge) - 10 +"px" ;
});

document.addEventListener('keydown',function (e) {
    if (e.key === "ArrowLeft") {
        var deplacement = document.querySelector("#perso");
        var marge = deplacement.style.marginLeft+10;
        deplacement.style.marginLeft = parseInt(marge) - 10 +"px" ;
    }
    if (e.key === "ArrowUp") {
        var deplacement = document.querySelector("#perso");
        var marge = deplacement.style.marginTop+10;
        deplacement.style.marginTop = parseInt(marge) - 10 +"px" ;
    }
    if (e.key === "ArrowRight") {
        var deplacement = document.querySelector("#perso");
        var marge = deplacement.style.marginLeft+10;
        deplacement.style.marginLeft = parseInt(marge) + 10 +"px" ;
    }
    if (e.key === "ArrowDown") {
        var deplacement = document.querySelector("#perso");
        var marge = deplacement.style.marginTop+10;
        deplacement.style.marginTop = parseInt(marge) + 10 +"px" ;
    }
})

document.querySelector("#perso").addEventListener('mousedown',function () {
    
})

