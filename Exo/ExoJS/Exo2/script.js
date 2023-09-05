
ligne = document.querySelectorAll(".l1");
ligne.forEach(element =>{
    element.addEventListener('change', calcul);
});

function calcul() {
    var quatite = document.querySelector("#q1").value ;
    var prixUnit = document.querySelector("#pu1").value;
    var total = quatite*prixUnit;
    document.querySelector("#p1").value = total;
};