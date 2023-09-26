<?php
require 'TriangleRectangle.php';
class Rectangle extends TriangleRectangle{

/********************Variable*******************/

/********************Accesseur*******************/

/********************Construct*******************/


    public function __construct(array $options = []){
        if (!empty($options)) {
            $this->hydrate($options);
        }
    }


/********************Methode*******************/

    public function perimetre()  {
        return 2*($this->_largeur+$this->_longueur);
    }
    public function aire()  {
        return $this->_largeur*$this->_longueur;
    }
    public function estCarre()  {
        if ($this->_largeur == $this->_longueur) {
            return true ;
        }   
    }
    public function afficher()  {
        echo $this; 
    }
    public function __toString(){
        $retour = "Longueur : ".$this->_longueur."cm - Largeur : ".$this->_largeur."cm - Périmètre : ".round($this->perimetre(),2)."cm - Aire : ".round($this->aire(),2)."cm² -" ;
        if ($this->estCarre()) {
            $retour = $retour." Il s’agit d’un carré ";
        }else{
            $retour = $retour." Il ne s’agit pas d’un carré ";
        }
        return $retour."\n";
    }
}