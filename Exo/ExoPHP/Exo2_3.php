<?php
    $age = readline("votre age : ");
    $sexe = readline("votre sexe (f ou h) : ");
    $message = '';

    if($sexe == 'f' && $age > 17 && $age < 36 || $sexe == 'h' && $age > 19){
        $message = 'PAYE TES IMPOT';
    }else{
        $message = 'Vous n\'est pas inposable';
    }
    echo $message;
