

document.querySelector("#add").addEventListener('click', function() {
    saisie = window.prompt("votre dersert préférer ?");
    if (saisie != "") {
       var puce = document.createElement("li");
       var contenu = document.createTextNode(saisie);
       puce.appendChild(contenu);
       var list = document.querySelector("#list");
       list.appendChild(puce);
       puce.addEventListener('click', suppr);
    }
});

ligne = document.querySelectorAll("li");
ligne.forEach(element =>{
    element.addEventListener('click', suppr);
});

function suppr(event) { 
    textClique = event.target;
    textClique.remove();
};