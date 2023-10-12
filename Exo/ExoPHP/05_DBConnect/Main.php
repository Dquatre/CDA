<?php

#region require
    function ChargerClasse($classe){
        require $classe.".Class.php";
    }
    spl_autoload_register("ChargerClasse");
#endregion

DbConnect::init();
$db = DbConnect::getDb();

// $moi = new Personnes(["nom"=>"Bapouze","prenom"=>"Rono"]);
// PersonnesManager::add($moi);
// $moi = new Personnes(["idPersonne"=>"11","nom"=>"Bapouze","prenom"=>"Reunault"]);
// PersonnesManager::update($moi);
// PersonnesManager::delete($moi);

$ret = PersonnesManager::select();
var_dump($ret);
