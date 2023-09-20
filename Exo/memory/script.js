demarrage = document.querySelector("input[type='button']");
listCard = Array();
var side = 0; 

demarrage.addEventListener("click",function() {
    initGame(4,4)
});

/**
 * initialise la partie selon les parametre
 * @param {*} nbPair 
 * @param {*} nbPlayer 
 */
function initGame(nbPair,nbPlayer) {
    form = document.querySelector("form");
    form.classList.add("noDisplay");
    generateCards(nbPair);
}

/**
 * affiche le nombre de paire de carte 
 * @param {*} nbPair 
 */
function generateCards(nbPair) {
    flag =true;
    j = 0 ;
    grille = document.getElementById("cards"); // on récupère la grille pour ajouter une ligne
    temp = document.querySelector("template"); // on récupère le template
    for (let i = 0; i < nbPair*2; i++) {
        const element = temp.content.cloneNode(true); // on clone le template
        grille.appendChild(element);    // on ajoute la ligne à la grille
        grille.innerHTML = grille.innerHTML.replaceAll("VALEUR", i);
        if (flag) {
            listCard[i] = j;
            flag = false;
        }else{
            listCard[i] = j;
            j++;
            flag =true;
        }
    }

    listCard = listCard.sort(() => Math.random() - 0.5);
    images = document.querySelectorAll(".cardgen");
    images.forEach(element => {
        element.addEventListener("click",flipCard);
    });
}

/**
 * affiche le recto de la carte cliquée
 */
function flipCard(e) {
    if (side == 0) {
        e.target.innerHTML = "<img src='images/recto"+e.target.value+".png' alt=''>";
        side = 1;

        // appelle turnBack au bout de 3sec
    }
    else {
        e.target.innerHTML = "<img src='images/verso.png' alt=''>";
        side = 0;
    }
}


/**
 * affiche le score lors d'un changement dans le tableau des score
 */
function displayUpdatedScore() {
    
}

/**
 * 
 * 
 */
function displayNextPlayer() {
    
}


/**
 * 
 * @returns bool
 */
function checkPair() {
    
}

/**
 * 
 */
function triggerWin() {
    
}