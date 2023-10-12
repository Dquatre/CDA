<?php
    require 'Class.php';
    $cquatre = new Voiture();
    $cquatre->setMarque("Citroën C4");
    $cquatre->setNbKilometre(10000);
    $renaultK = new Voiture();
    $renaultK->setMarque("Renault Kadjar ");
    $renaultK->setCouleur("rouge");

    echo $cquatre;
    echo $renaultK;
    $cquatre->rouler(100);
    echo $cquatre;
