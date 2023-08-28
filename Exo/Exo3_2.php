<?php
    $nombreArticle = 0;
    $somme = 0;
    $flag = true;
    $aRendre = 0;
    do{ 
        do{
            $prix = readline("Entrer le prix de l'article : ");
        }while($prix < 0);    
        if($prix == 0){
            $flag = false;
        }else{
            $somme += $prix;
            $nombreArticle++;
        }
    }while($flag);
    echo 'nombre d\'article : '.$nombreArticle.'    Somme due : '.$somme;
    do{
        $aRendre  = readline('Entrer la somme paye : ');  
    }while($aRendre < $somme);
    $aRendre -= $somme ;
    while($aRendre > 9){
        $aRendre -= 10;
        echo '10 Euros' ;   
    }
    if($aRendre > 4){
        $aRendre -= 5;
        echo '5 Euros';
    }
    while($aRendre > 0){
        $aRendre -= 1;
        echo '1 Euro ';
    }
    