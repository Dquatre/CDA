<?php
    /**
     * Créer un tableau en demandant a utilisateur entrer des valeur
     * avec l'invite de saisie en paramétre et s'arret lorsque ulilisateur entre 0
     * 
     * @param string $invite
     * @return array
     */
    function CreerTableau ($invite){
        do{
            $saisie = SaisirEntier($invite);
                $tableau[] = $saisie; 
        }while($saisie != 0);
        array_pop($tableau);
        return $tableau;
    }

    /**
     * Créer un tableau
     *
     * @param string $invite
     * @param int $row
     * @param int $colunm
     * @return array
     */
    function CreerTableauDeuxD ($invite,$row,$colunm){
        for($i=0;$i< $row;$i++){
            for($j=0;$j< $colunm;$j++){
                $tableau[$i][$j] = SaisirEntier($invite);  
            }
        }
        return $tableau;
    }

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
     * Affiche un tableau
     *
     * @param array $tableau
     * @return void
     */
    function AfficherTableau ($tableau){
        echo "| ";
        foreach($tableau as $val){
            echo $val." | ";
        }
    }
    /**
     * Affiche un tableau multidimentionel sous forme de plateau de jeu
     * les entêtes de colonnes seront des lettres, chiffres pour les lignes
     * @param array $tableau
     * @return void
     */
    function AfficherTableauDeuxD ($tableau){
        for($j=0;$j<= sizeof($tableau[0]);$j++){
            echo"----";
        }
        echo "\n|   | ";
        for($i=0;$i< sizeof($tableau[0]);$i++){
            echo chr(65+$i)." | ";
        }
        echo "\n";
        for($j=0;$j<= sizeof($tableau[0]);$j++){
            echo"----";
        }
        for($i=0;$i< sizeof($tableau);$i++){
            echo"\n| ".($i+1)." | ";
            for($j=0;$j< sizeof($tableau[$i]);$j++){
                echo $tableau[$i][$j]." | ";
            }
            echo"\n";
            for($j=0;$j<= sizeof($tableau[0]);$j++){
                echo"----";
            }
        }
    }


    $tableau = CreerTableau("entrer une note");
    sort($tableau);
    AfficherTableau($tableau);
    // $row = SaisirEntier("Entrer le nombre de ligne");
    // $colunm = SaisirEntier("Entrer le nombre de colone");
    // $tableau = CreerTableauDeuxD("entrer une note",$row,$colunm);
    // AfficherTableauDeuxD($tableau);




    // $row = 0;
    // $colunm = 0;
   
    // $tableau = array(array());
    // do{
    //     $row = readline("Entrer le nombre de ligne : ");
    // }while(!preg_match("/^[\d]+$/", $row) || $row < 0); 
    // do{
    //     $colunm = readline("Entrer le nombre de colone : ");
    // }while(!preg_match("/^[\d]+$/", $colunm) || $colunm < 0); 
              
       
    // for($i=0;$i< $row;$i++){
    //     for($j=0;$j< $colunm;$j++){
    //          do{
    //             $saisie = readline("Entrer une valeur : ");
    //         }while(!preg_match("/^[\d]+$/", $saisie));   
    //         if($saisie != 0){
    //             $tableau[$i][$j] = $saisie;  
    //         }
    //     }
    // }

    // for($i=0;$i< $row;$i++){
    //     echo"\n";
    //     for($j=0;$j< $colunm;$j++){
    //         echo $tableau[$i][$j];
    //     }
    // }




    // foreach($tableau as $val){
    //     echo $val."  ";
    // }

    // $taille = 0;
    // $i = 0;
    // $tableau = array();
    // do{
    //     $taille = readline("Entrer taille du tableau : ");
    // }while(!preg_match("/^[\d]+$/", $taille));    
    // do{
    //     do{
    //         $saisie = readline("Entrer valeur : ");
    //     }while(!preg_match("/^[\d]+$/", $saisie));   
    //     if($saisie != 0){
    //         $tableau[$i] = $saisie;  
    //     }   
    //     $i++;
    // }while($i != $taille && $saisie != 0);   

    // foreach($tableau as $val){
    //     echo $val."  ";
    // }

    // echo "\n";
    // sort($tableau);

    // foreach($tableau as $val){
    //     echo $val."  ";
    // }

    