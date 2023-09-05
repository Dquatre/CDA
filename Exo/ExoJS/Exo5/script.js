
document.querySelector("#img").addEventListener('click', function() {
    // if (document.querySelector("#img").src == "file:///U:/59011-82-07/Exo/ExoJS/Exo5/img/Kirby.png") {      
    // document.querySelector("#img").src = "img/KirbyRetourne.png";  
    // setTimeout(() => {
    //     document.querySelector("#img").src = "img/Kirby.png"; 
    // }, "1000");
    // }
    
    const img = document.querySelector("#img") ; 

    img.style.transition = "transform 1s";
    img.style.transform = "rotate(180deg)";
    setTimeout(() => {
    img.style.transition = "transform 1s";
    img.style.transform = "rotate(0)"; 
    }, "1000");
});