
// document.getElementById("ampAll").style.display = "none";
// document.getElementById( "ampEt" ).addEventListener( 'click', function() {
//     document.getElementById("ampEt").style.display = "none";
//     document.getElementById("ampAll").style.display = "block";
// });
// document.getElementById( "ampAll" ).addEventListener( 'click', function() {
//     document.getElementById("ampAll").style.display = "none";
//     document.getElementById("ampEt").style.display = "block";
// });



document.querySelector("#amp").addEventListener('click', function() {
    if (document.querySelector("#amp").src == "file:///U:/59011-82-07/Exo/ExoJS/Exo1/IMG/ampoule%20eteinte.PNG") {
        document.querySelector("#amp").src = "IMG/ampoule allumee.png";
    }else{
        document.querySelector("#amp").src = "IMG/ampoule eteinte.PNG";
    } 
});
