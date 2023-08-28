<?php
    $message = '';
    $score = 0;
    $age = 26;
    $anneePermit = 2;
    $accident = 2;
    $anciente = 2;

    $couleur = ['rouge', 'orange', 'vert', 'bleu'];

    if($age > 25){
            $score++ ;
    }    
    if($anneePermit > 2){
        $score++ ;
    }

    $score -=  $accident;

    if($ancien > 0 && $score >= 0){
        $score = $score + $anciente;
    }

    if($score > 0){
        $message = 'tarif' . $couleur[$score];
    }else{
        $message = 'pas assurable';
    }
    echo $message;

    // 26 ans 2ans de permis 2 accident 1 an de fidelite=> tu repond rouge alors que c'est non assurable