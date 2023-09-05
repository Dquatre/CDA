
document.querySelector("#img").addEventListener('click', function() {
    if (document.querySelector("#img").src == "file:///U:/59011-82-07/Exo/ExoJS/Exo5/img/Kirby.png") {      
    document.querySelector("#img").src = "img/KirbyRetourne.png";  
    setTimeout(() => {
        document.querySelector("#img").src = "img/Kirby.png"; 
    }, "1000");
    }
});