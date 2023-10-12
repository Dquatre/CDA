<?php
// require 'Pave.php';
require 'Sphere.php';
// require 'Pentahedre.php';
// function ChargerClasse($classe)
// {
//     require $classe.".Class.php";
// }
// spl_autoload_register("ChargerClasse");
    // $cercle = new Cercle(["diametre"=> 3]);
    // $cercle->afficher();
    // $rect = new Rectangle(["longueur"=> 4,"largeur"=> 5]);
    // $rect->afficher();
    // $tri = new TriangleRectangle(["longueur"=> 4,"largeur"=> 5]);
    // $tri->afficher();
    // $pave = new PaveDroit(["longueur"=> 4,"largeur"=> 5,"profondeur"=>3]);
    // $pave->afficher();
    // $penta = new Pentahedre(["longueur"=> 4,"largeur"=> 5,"profondeur"=>3]);
    // $penta ->afficher();
    $sph = new Sphere(["diametre"=> 3]);
    $sph ->afficher();