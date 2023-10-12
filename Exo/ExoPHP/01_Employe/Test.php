<?php
function ChargerClasse($classe)
{
    require $classe.".php";
}
spl_autoload_register("ChargerClasse");

    $cogip = new Agence(["nom"=>"cogip",
                        "addresse"=>"4 rue du 30 fevrier",
                        "codePostal"=>"59000",
                        "ville"=>"lille",
                        "aRestoration"=>false]);
    $jpr = new Agence(["nom"=>"cogip",
                        "addresse"=>"21 rue de la boustifaille",
                        "codePostal"=>"59008",
                        "ville"=>"Trousay",
                        "aRestoration"=>true]);

    $gontran = new Employe(["nom"=>"flantoin",
                            "prenom"=>"gontran",
                            "dateEmbauche"=>'2017-10-21',
                            "poste"=>'petroufileur',
                            "salaire"=>23,
                            "service"=>"comptabilite",
                            "agence"=>$jpr,
                            "listAgeEnfant"=>[7]]);
    $gonzag = new Employe( ["nom"=>"minette",
                            "prenom"=>"gonzag",
                            "dateEmbauche"=>'2021-03-01',
                            "poste"=>'manager',
                            "salaire"=>32,
                            "service"=>"commercial",
                            "agence"=>$cogip]);
    $theodule = new Employe( ["nom"=>"mucrulu",
                            "prenom"=>"theodule",
                            "dateEmbauche"=>'2012-03-01',
                            "poste"=>'technicien de surface',
                            "salaire"=>18,
                            "service"=>"menage",
                            "listAgeEnfant"=>[25,28]]);
    $ivette = new Employe( ["nom"=>"commas",
                            "prenom"=>"ivette",
                            "dateEmbauche"=>'2017-03-02',
                            "poste"=>'directice',
                            "salaire"=>250,
                            "service"=>"direction",
                            "listAgeEnfant"=>[10,15]]);
    $ambroise = new Employe( ["nom"=>"juport",
                            "prenom"=>"ambroise",
                            "dateEmbauche"=>'2022-05-02',
                            "poste"=>'comptable',
                            "salaire"=>25,
                            "service"=>"comptabilite",
                            "agence"=>$cogip,
                            "listAgeEnfant"=>[2,5,6,7,10,15,15,21]]);

    $employer = [$gontran ,$gonzag,$theodule,$ivette,$ambroise];

    for ($i=0; $i < sizeof($employer); $i++) { 
        $employer[$i]->calculChequeCadeau();
    }
    // // for ($i=0; $i < sizeof($employer); $i++) { 
    // //     echo ($employer[$i]->calculPrime())." euros ont était transferer sur le compte de ".$employer[$i]->getNom()." ".$employer[$i]->getPrenom()."\n";
    // // }

    // echo Employe::getCounter()."\n";
    // sort($employer);
    // for ($i=0; $i < sizeof($employer); $i++) { 
    //     echo $employer[$i];
    // }

    // usort($employer,["Employe","compareTo"]);

    // for ($i=0; $i < sizeof($employer); $i++) { 
    //     echo $employer[$i];
    // }

    // $massSalarial =0;
    // for ($i=0; $i < sizeof($employer); $i++) { 
    //     $massSalarial += ($employer[$i]->getSalaire()*1000 + $employer[$i]->calculPrime());
    // }
    // echo $massSalarial;




