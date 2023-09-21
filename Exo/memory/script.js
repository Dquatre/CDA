demarrage = document.querySelector("input[type='button']");
listCard = Array();
nbPair = 0;
flip = 0; 
val1 = 0;
score = 0;

demarrage.addEventListener("click",function() {
    initGame()
});

/**
 * initialise la partie selon les parametre
 * @param {*} nbPair 
 * @param {*} nbPlayer 
 */
function initGame() {
    resultNbPair = document.querySelector("#nbPair");
    nbPair = resultNbPair.value*1;
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
        grille.innerHTML = grille.innerHTML.replaceAll("imageHere","<img src='img/verso.png' id='"+i+"'>");
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
    if (flip == 0) {
        val1=e.target;
        val1.src = "./img/recto"+listCard[val1.id*1]+".png";
        flip = 1;
    }else{
        val2 =  e.target;
        if (val2.id*1 != val1.id*1) {
            val2.src = "./img/recto"+listCard[val2.id*1]+".png";
            if (checkPair()) {
                score++;
            }else{
                setTimeout(setCard, 1000);
            }
            flip = 0 ;
        } 
        if (triggerWin()) {
            allCard = document.querySelectorAll(".cardgen");
            allCard.forEach(element => {
                element.classList.add("noDisplay");
            });

        }
    }
}

function setCard(e) {
    val1.src = "./img/verso.png";
    val2.src = "./img/verso.png";
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
    let flag = false;
    if (listCard[val1.id*1] == listCard[val2.id*1]) {
        flag = true;
    }
    return flag;
}

/**
 * 
 */
function triggerWin() {
    let flag = false;
    if (score == nbPair) {
        flag = true;
    }
    return flag;
}