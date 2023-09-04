<?php
    $nombre = readline("Entrer un nombre : ");
    $resultat = 0;
    $calcul ="1";

    for($i=1;$i<$nombre;$i++){
        $resultat += $i;
        echo $i . "+";
    }
    $resultat += $nombre;

    echo $nombre." = ".$resultat;

