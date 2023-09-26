<?php
require 'Employe.php';

    $gontran = new Employe(["nom"=>"flantoin","prenom"=>"gontran","_dateEmbauche"=>'2021-10-21']);
    echo $gontran->calculAnciennete();
