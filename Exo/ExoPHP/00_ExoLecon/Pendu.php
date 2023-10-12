<?php
/**
 * initialise les paramètres du jeu
 *
 * @return array Tableau associatif qui retourne toute les variables d'initialisation
 */
function init(){
    $parametreDeJeu = array("difficulte" => 0,"nbJoueur" => 0,"nbVie" => 0,"mot" => "");
    $parametreDeJeu["difficulte"] = saisirDifficulte();
    $parametreDeJeu["nbJoueur"] = saisirNbJoueur();
    $parametreDeJeu["nbVie"] = saisirNbVie();
    $parametreDeJeu["mot"] = determinerMotAChercher();
    return $parametreDeJeu;
}

/**
 * Demande le niveau de difficulté à l'utilisateur
 *
 * @return int niveau de difficulte
 */
function saisirDifficulte(){
    do{
        $difficulte = readline("Entrer la difficulte de 1 à 3 : ");
    }while(!preg_match("/^[1-3]$/", $difficulte));   
    return $difficulte;
}

/**
 * Demande le nombre de joueur
 *
 * @return int nombre de joueurs
 */
function saisirNbJoueur(){
    do{
        $nbJoueur = readline("Entrer le nombre de joueur : ");
    }while(!preg_match("/^[\d]+$/", $nbJoueur) || $nbJoueur < 0);
    return $nbJoueur;
}

/**
 * Demande le nombre de vie aux joueurs
 *
 * @return int nombre de vie
 */
function saisirNbVie(){
    do{
        $nbVie = readline("Entrer le nombre de vie : ");
    }while(!preg_match("/^[\d]+$/", $nbVie) || $nbVie < 0);
    return $nbVie;
}

/**
 * Choisi au hasard un mot dans une liste
 *
 * @return string mot qui doit être trouvé par les joueurs
 */
function determinerMotAChercher(){
    $dictionnaire = array("JAZZ","MAISON","BEURRE","VOITURE");
    $mot = $dictionnaire[rand(0,(sizeof($dictionnaire)-1))];
    return $mot;
}

function jeu($mot,$difficulte,$nbJoueur,$nbVie){
    $motCode = coderMot($mot,$difficulte);
    $joueurEnCours = 1;
    $propositions = "";
    do {
        affichageGlobal($nbVie,$motCode,$joueurEnCours,$propositions);
        $lettre = saisirLettre($joueurEnCours);
        if (estCorrecte($lettre,$motCode,$mot)) {
            $motCode = ajouterLettre($lettre, $motCode, $mot, $difficulte);
        }else{
            $nbVie--;
            $joueurEnCours = joueurSuivant($nbJoueur,$joueurEnCours);
            $propositions = $propositions." ".$lettre;

        }
        $flag = estGagne($motCode,$nbVie,$joueurEnCours);
    } while ($flag == 0);
    return $flag;
}

/**
 * Construit un tableau du mot en fonction de la difficulté
 *
 * @param string $mot Mot à chercher
 * @param integer $difficulte Difficulté de la partie indiquée
 * @return array Le tableau du mot
 */
function coderMot(string $mot, int $difficulte){
    for ($i=0; $i < strlen($mot); $i++) { 
        $motCode[$i]= "_";
    }
    if ($difficulte < 3) {
        $motCode[0]= $mot[0];
    }

    if ($difficulte < 2) {
        $motCode[sizeof($motCode)-1]= $mot[strlen($mot)-1];
    } 
    return $motCode;   
}


/**
 * Affiche le mot codé
 *
 * @param array $motCode Tableau du mot codé
 * @return void
 */
function afficherMotCode(array $motCode){ 
    foreach ($motCode as $value) {
        echo $value." ";
    }
    echo "\n";
}


/**
 * Permet de décider qui va jouer
 *
 * @param integer $nbJoueur Le nombre de joueur
 * @param integer $joueurEnCours Le joueur qui vient de jouer
 * @return int
 */
function joueurSuivant(int $nbJoueur, int $joueurEnCours){
    if ($joueurEnCours == $nbJoueur){
        $joueurEnCours = 1;
    }else{
        $joueurEnCours++;
    }
    return $joueurEnCours;
}

/**
 * Permet au joueur en cours de proposer une lettre
 *
 * @param integer $joueurEnCours Celui qui doit jouer
 * @return string La lettre ayant été proposée
 */
function saisirLettre(int $joueurEnCours){
    do{
        $lettre = readline("Joueur ".$joueurEnCours.", Veuiller entrer une lettre : ");
    }while(!preg_match("/^[a-zA-Z]$/", $lettre));   
    return strtoupper($lettre) ;
}

/**
 * Vérifie si la lettre fait partie du mot ou pas
 *
 * @param string $lettre La lettre entrée par le joueur
 * @param array $motCode La partie du mot que le joueur connait
 * @param string $mot Le mot que le joueur doit trouvé
 * @param int $difficulte La difficulte de la partie
 * @param string $propositions Les lettre déjà proposées
 * @return void
 */
function verifierLettre(string $lettre, array $motCode, string $mot, int $difficulte, string $propositions){

}

/**
 * Vérifie si la lettre est correcte et pas encore ajoutée
 *
 * @param string $lettre
 * @param array $motcode
 * @param string $mot
 * @return bool
 */
function estCorrecte(string $lettre, array $motCode, string $mot){
    $flag = false;
    for ($i=0; $i < strlen($mot); $i++) { 
        if ($lettre == $mot[$i]) {
            $flag = true;
        }
    }
    for ($i=0; $i < sizeof($motCode); $i++) { 
        if ($lettre == $motCode[$i]) {
            $flag = false;
        }
    }
    return $flag;
}

/**
 * Ajoute la lettre au mot codé en fonction du niveau de difficulté
 *
 * @param string $lettre
 * @param array $motcode
 * @param string $mot
 * @param integer $difficulte
 * @return array Le mot codé
 */
function ajouterLettre(string $lettre, array $motCode, string $mot, int $difficulte){
    $i=0;
    while($i < strlen($mot)){
        if ($lettre == $mot[$i]) {
            $motCode[$i] = $lettre;
            if($difficulte > 2){
                $i = strlen($mot);
            }
        }
        $i++;
    }
    return $motCode;
}

/**
 * Clear la console et réaffiche le jeu dans l'état actuel
 *
 * @param integer $nbVie
 * @param array $motCode
 * @param integer $joueurEnCours
 * @param string $propositions
 * @return void
 */
function affichageGlobal(int $nbVie, array $motCode, int $joueurEnCours, string $propositions){
    affichageVie($nbVie);
    afficherMotCode($motCode);
    afficherProposition($propositions);
}

function afficherProposition(string $propositions){
    echo $propositions."\n";
}

/**
 * Affiche le nombre de vie restante + pendu ?
 *
 * @param integer $nbVie
 * @return void
 */
function affichageVie(int $nbVie){
    for ($i=0; $i < $nbVie; $i++) { 
        echo "♥";
    }
    echo "\n";
}

/**
 * Undocumented function
 *
 * @param array $motCode
 * @return int Etat de la partie (0 -1 1)
 * 0 = en cours
 * -1 = perdu
 * 1 = gagne
 * */
function estGagne(array $motCode,int $nbVie,int $nbJoueur){
    if ($nbVie == 0) {
        $flag = -1;
    }elseif (in_array("_",$motCode)) {
        $flag = 0;
    } else {
        $flag = $nbJoueur;
    }
    return $flag;
}

/**
 * Conclu le jeu Gagné ou Perdu
 *
 * @param boolean $resultat
 * @return void
 */
function conclusion($resultat){
    if($resultat > 0 ){
        echo "Bravo Joueur ". $resultat;
    }else {
        echo "perdu";
    }
}

$parametreDeJeu = init();
$resultat = jeu($parametreDeJeu["mot"],$parametreDeJeu["difficulte"],$parametreDeJeu["nbJoueur"],$parametreDeJeu["nbVie"]);
conclusion($resultat);