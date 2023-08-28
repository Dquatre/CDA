<?php

    $row = 0;
    $colunm = 0;
    $i = 0;
    $j = 0;
    $tableau = array(array());
    do{
        $taille = readline("Entrer le nombre de ligne : ");
    }while(!preg_match("/^[\d]+$/", $row) || $row < 0); 
    do{
        $taille = readline("Entrer le nombre de colone : ");
    }while(!preg_match("/^[\d]+$/", $colunm) || $colunm < 0); 
    
    do{
        do{
            do{
                $saisie = readline("Entrer valeur : ");
            }while(!preg_match("/^[\d]+$/", $saisie));   
            if($saisie != 0){
                $tableau[$i][$j] = $saisie;  
            }   
        }while($j != $colunm && $saisie != 0);
        $i++;
    }while($i != $row && $saisie != 0);   

    for($i=0;$i< $row;$i++){
        echo"\n";
        for($j=0;$j< $colunm;$j++){
            echo $tableau[$i][$j];
        }
    }




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

    