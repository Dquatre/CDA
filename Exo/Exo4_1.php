<?php
    
    $saisie = array();
    $i=0;
    $flag = true;
    do{
        $saisie[$i] = (int)readline('Entrer une valeur : ');
        $flag = preg_match("/^[0-9]*$/", $saisie[$i]);
        echo $flag;
    }while($flag);
