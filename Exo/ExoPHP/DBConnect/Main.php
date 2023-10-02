<?php

#region require
    function ChargerClasse($classe){
        require $classe.".Class.php";
    }
    spl_autoload_register("ChargerClasse");
#endregion
DbConnect::init();
$moi = new Personne(['nom'=>'Didolla','prenom'=>'David']);
PersonneManager::add($moi);


