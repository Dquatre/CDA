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

    $nombre = readline('Entrer en nombre : ');

    echo factorielle($nombre);
    
    