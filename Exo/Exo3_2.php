<?php
    $nombreArticle = 0;
    $somme = 0;
    $flag = true;
    $aRendre = 0;
    do{ 
        do{
            $prix = readline("Entrer le prix de l'article : ");
        }while(!preg_match("/^[\d]+$/", $prix) || $prix < 0);    
        if($prix == 0){
            $flag = false;
        }else{
            $somme += $prix;
            $nombreArticle++;
        }
    }while($flag);
    echo 'nombre d\'article : '.$nombreArticle.'    Somme due : '.$somme . "\n";
    do{
        $aRendre  = readline('Entrer la somme paye : ');  
    }while(!preg_match("/^[\d]+$/", $prix) || $aRendre < $somme);
    $aRendre -= $somme ;
    while($aRendre >= 10){
        $aRendre -= 10;
        echo "10 Euros \n" ;   
    }
    if($aRendre >= 5){
        $aRendre -= 5;
        echo "5 Euros \n" ;
    }
    while($aRendre > 0){
        $aRendre -= 1;
        echo "1 Euros \n" ;
    }
    