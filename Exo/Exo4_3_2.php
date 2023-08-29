<?php

    /**
     * Epele la chaine de caractere passe en parametre
     *
     * @param string $mot
     * @return void
     */
    function epele(string $mot) {
        if($mot != ""){
            echo $mot[0]." ";
            epele(substr($mot,1));
        }
    }
    
    function ecrireUnMot(){
        do{
            $mot = readline('Entrer un mot : ');
        }while(!preg_match("/^[a-zA-Z]+$/", $mot));
        return $mot;
    }

    $mot = ecrireUnMot();
    epele($mot);
    
    // $mot = readline('Entrer en mot : ');
    
    // for($i=0;$i<strlen($mot);$i++){
    //     echo $mot[$i]."\n";
    // }
        

