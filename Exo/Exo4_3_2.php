<?php

    // function epele($mot) {
    //     echo $mot[0];
        
    //     epele($mot);
    // }
    
    $mot = readline('Entrer en mot : ');
    
    for($i=0;$i<strlen($mot);$i++){
        echo $mot[$i]."\n";
    }
