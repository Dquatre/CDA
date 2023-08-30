<?php

    /**
     * demande a l'utilisateur d'entrer un nombre entier superieur a 0
     * selon l'invite en parametre
     *
     * @param string $invite
     * @return int
     */
    function saisirEntierSupZero(string $invite){
        do{
            $nombre = readline("$invite ");
        }while(!preg_match("/^(-)?[\d]+$/", $nombre) || $nombre <= 0);   
        return $nombre ;
    }

    /**
     * demande a l'utilisateur d'entrer une lettre 
     * selon l'invite en parametre
     *
     * @param string $invite
     * @return string
     */
    function saisirLettre(string $invite){
        do{
            $lettre = readline("$invite ");
        }while(!preg_match("/^[a-zA-Z]$/", $lettre));   
        return $lettre ;
    }

    /**
     * Affiche un plateau avec des chiffre en entete
     *
     * @param [type] $tableau
     * @return void
     */
    function afficherPlateau ($tableau){
        $tre = "";
        for($j=0;$j<= $taille;$j++){
            
            // $tre = $tre."----------------";
            $tre = $tre."----";
        }
        return $tre."-";
        echo "$tre\n|     |";
        for($i=0;$i< sizeof($tableau[0]);$i++){
            echo str_pad($i+1, 3," ",STR_PAD_BOTH)."|";
        }
        echo "\n$tre";
        for($i=0;$i< sizeof($tableau);$i++){
            for($j=0;$j< sizeof($tableau[$i]);$j++){
                echo str_pad($tableau[$i][$j], 3," ",STR_PAD_BOTH)."|";
            }
            echo"\n$tre"; 
        }
    }

    function VerifieGagne($tableau){

    }

    /**
     * Demande les parametre de la partie et fait evolue le plateau jusqu a la victoire
     *
     * @return void
     */
    function jouerPartie(){
        $ligne = saisirEntierSupZero("Entrer le nombre de ligne : ");
        $colone = saisirEntierSupZero("Entrer le nombre de colone : ");
        $nbJoueur = saisirEntierSupZero("Entrer le nombre de joueur : ");
        $nbGagnan = saisirEntierSupZero("Entrer le nombre de piece a aligner pour gagner : ");
        for ($i=0; $i < $nbJoueur; $i++) { 
            $tableSymbol[$i] = strtoupper(saisirLettre("Entrer une lettre qui vous represente Joueur ".($i+1)));
        }
        $flagWin = true;
        do{

        }while (flagWin) ;
    }

    jouerPartie();
