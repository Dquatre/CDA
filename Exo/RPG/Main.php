<?php
#region require
    function ChargerClasse($classe){
        require $classe.".php";
    }
    spl_autoload_register("ChargerClasse");
#endregion

LancerJeu(true);


function LancerJeu($debug)  {
    $player = new Joueur(["nom"=>"Kurts"]);
    $orc = new MonstreFacile();
    do {
        do {
            $player->attaque($orc,$debug);  
            if($orc->getEstVivant()){
                $orc->attaque($player,$debug);
            }else{
                $orc->setNbMonstre(MonstreFacile::getNbMonstre()+1);
            } 
        } while ($orc->getEstVivant());
        if($debug)echo "Le monstre est mort\n";

    } while ($player->estVivant());
    if($debug)echo "aaah il est mort\n";

}








