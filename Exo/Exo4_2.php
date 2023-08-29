<?php

    /**
     * saisir une valeur et verifie que c'est bien un entier
     *
     * @param string $invite
     * @return void
     */
    function SaisirEntier(string $invite,bool $positif = false){
        do{
            $nombre = readline("$invite ");
        }while(!preg_match("/^(-)?[\d]+$/", $nombre) || ($positif && $nombre < 0));   
        return $nombre ;
    }

    /**
     * Créer un tableau en demandant a utilisateur entrer des valeur
     * avec l'invite de saisie en paramétre et s'arret lorsque ulilisateur entre 0
     * 
     * @param string $invite
     * @return array
     */
    function CreerTableauAssociatif(int $taille){
        for($i=0;$i<$taille;$i++){
            $saisieKey = SaisirEntier("Entrer le nombre ");
            $saisieVal = readline("Entrer le nombre en lettre ");
                $tableau[$saisieKey] = $saisieVal ; 
        }
        return $tableau;
    }
    /**
     * Affiche un tableau
     *
     * @param array $tableau
     * @return void
     */
    function AfficherTableau ($tableau){
        foreach($tableau as $key => $val){
            echo $key." ".$val."\n";
        }
    }
    // $tableau = CreerTableauAssociatif(5);
    $tableau = array(1=>"un", 2=>"deux", 3=>"trois", 4=>"quatre", 5=>"cinq");
    AfficherTableau($tableau);


    