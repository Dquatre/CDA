<?php
require('Polygone.php');
class Triangle extends Polygone{

/********************Variable*******************/




/********************Accesseur*******************/




/********************Construct*******************/



/********************Methode*******************/
public function perimetre()  {
    return $this->_largeur+$this->_longueur+sqrt(pow($this->_largeur,2) + pow($this->_longueur,2));
}
public function aire()  {
    return $this->_largeur*$this->_longueur/2;
}


public function afficherRectangle()  {
    echo $this; 
}
public function __toString(){
    $retour = "Longueur : ".$this->_longueur."- Largeur : ".$this->_largeur." - Périmètre : ".$this->perimetre()." - Aire : ".$this->aire() ;
    return $retour;
}

}