<?php
require 'Employe.php';

    $gontran = new Employe(["nom"=>"flantoin",
                            "prenom"=>"gontran",
                            "dateEmbauche"=>'2017-10-21',
                            "poste"=>'Petroufileur',
                            "salaire"=>23,
                            "service"=>"comptabilite"]);
    $gonzag = new Employe( ["nom"=>"minette",
                            "prenom"=>"gonzag",
                            "dateEmbauche"=>'2021-03-01',
                            "poste"=>'manager',
                            "salaire"=>32,
                            "service"=>"commercial"]);
    $theodule = new Employe( ["nom"=>"mucrulu",
                            "prenom"=>"theodule",
                            "dateEmbauche"=>'2012-03-01',
                            "poste"=>'technicien de surface',
                            "salaire"=>18,
                            "service"=>"menage"]);
    $ivette = new Employe( ["nom"=>"commas",
                            "prenom"=>"ivette",
                            "dateEmbauche"=>'2017-03-02',
                            "poste"=>'directice',
                            "salaire"=>250,
                            "service"=>"direction"]);
    $ambroise = new Employe( ["nom"=>"juport",
                            "prenom"=>"ambroise",
                            "dateEmbauche"=>'2022-05-02',
                            "poste"=>'comptable',
                            "salaire"=>25,
                            "service"=>"comptabilite"]);

    $employer = [$gontran ,$gonzag,$theodule,$ivette,$ambroise];

    
    // for ($i=0; $i < sizeof($employer); $i++) { 
    //     echo ($employer[$i]->calculPrime())." euros ont était transferer sur le compte de ".$employer[$i]->getNom()." ".$employer[$i]->getPrenom()."\n";
    // }

    echo sizeof($employer)."\n";
    sort($employer);
    for ($i=0; $i < sizeof($employer); $i++) { 
        echo $employer[$i]->getNom()." ".$employer[$i]->getPrenom()."\n";
    }
    uasort($employer);


