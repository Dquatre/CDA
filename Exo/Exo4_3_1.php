<?php

    /**
     * calcul la factorielle du nombre en parametre
     *
     * @param int $nombre
     * @return int
     */
    function factorielle($nombre) {
        if($nombre == 0){
            return 1;
        }else{
            return $nombre*factorielle($nombre-1);
        }    
    }
        /**
     * saisir une valeur et verifie que c'est bien un entier
     *
     * @param string $invite
     * @return void
     */
    function SaisirEntier(string $invite,bool $positif = false){
        do{
            $nombre = readline("$invite ");
        }while(!preg_match("/^(-)?[\d]+$/", $nombre) || ($positif && $nombre < 0));   
        return $nombre ;
    }

    $nombre = SaisirEntier('Entrer en nombre : ',true);
    echo factorielle($nombre);
    
    