<?php
    /**
     * Créer un tableau en demandant a utilisateur entrer des valeur
     * avec l'invite de saisie en paramétre et s'arret lorsque ulilisateur entre 0
     * 
     * @param string $invite
     * @return array
     */
    function creerTableau ($invite){
        do{
            $saisie = saisirEntier($invite);
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
    function creerTableauDeuxD ($invite,$row,$colunm){
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
    function saisirEntier(string $invite,bool $positif = false){
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
    function afficherTableau (array $tableau){
        echo implode("\t", $tableau)."\n";
    }

    function dessinerTre(int $taille){
        $tre = "";
        for($j=0;$j<= $taille;$j++){
            
            // $tre = $tre."----------------";
            $tre = $tre."----";
        }
        return $tre."-";
    }

    /**
     * Affiche un tableau multidimentionel sous forme de plateau de jeu
     * les entêtes de colonnes seront des lettres, chiffres pour les lignes
     * @param array $tableau
     * @return void
     */
    function afficherTableauDeuxD ($tableau){
        $tre = dessinerTre(sizeof($tableau[0]));
        
        echo "$tre\n|   | ";
        for($i=0;$i< sizeof($tableau[0]);$i++){
            echo chr(65+$i)." | ";
        }
        echo "\n$tre";
        
        for($i=0;$i< sizeof($tableau);$i++){
            echo"\n| ".($i+1)." | ";
            for($j=0;$j< sizeof($tableau[$i]);$j++){
                echo $tableau[$i][$j]." | ";
            }
            echo"\n$tre"; 
        }

        //version avec tabulation

        // echo "$tre\n|\t\t|\t";
        // for($i=0;$i< sizeof($tableau[0]);$i++){
        //     echo chr(65+$i)."\t|\t";
        // }
        // echo "\n$tre";
        
        // for($i=0;$i< sizeof($tableau);$i++){
        //     echo"\n|\t".($i+1)."\t|\t";
        //     for($j=0;$j< sizeof($tableau[$i]);$j++){
        //         echo $tableau[$i][$j]."\t|\t";
        //     }
        //     echo"\n$tre"; 
        // }
    }

    /**
     * rechercher si une valeur est dans le tableau
     *
     * @param [type] $valeur
     * @return bool
     */
    function rechercherValeur($valeur){

        for($i=0;$i< $row;$i++){
            for($j=0;$j< $colunm;$j++){
                if($tableau[$i][$j] == $valeur){
                    return true;
                }
            }
        }
        return false;
    }

    // $tableau = creerTableau("entrer une note");
    // sort($tableau);
    // afficherTableau($tableau);
    $row = saisirEntier("Entrer le nombre de ligne");
    $colunm = saisirEntier("Entrer le nombre de colone");
    $tableau = creerTableauDeuxD("entrer une note",$row,$colunm);
    afficherTableauDeuxD($tableau);




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

    