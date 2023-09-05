for (let index = 1; index < 7; index++) {
    ligne = document.querySelectorAll(".l"+index);
    ligne.forEach(element =>{
        element.addEventListener('change', function () {
            var quatite = document.querySelector("#q"+index).value ;
            var prixUnit = document.querySelector("#pu"+index).value;
            var total = quatite*prixUnit;
            document.querySelector("#p"+index).value = total;
            
        });
    });
}




