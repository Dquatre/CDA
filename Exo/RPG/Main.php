<?php
#region require
    function ChargerClasse($classe){
        require $classe.".php";
    }
    spl_autoload_register("ChargerClasse");
#endregion

$player = new Joueur(["name"=>"Kurts"]);
$orc = new MonstreFacile();
echo $player->attack($orc);
// do {

// } while ($player->isAlive());







