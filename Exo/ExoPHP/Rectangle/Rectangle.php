<?php
require('Polygone.php');
class Rectangle extends Polygone{

/********************Variable*******************/


/********************Accesseur*******************/


/********************Construct*******************/



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
    public function afficherTriangle()  {
        echo $this; 
    }
    public function __toString(){
        $retour = "Longueur : ".$this->_longueur."- Largeur : ".$this->_largeur." - Périmètre : ".$this->perimetre()." - Aire : ".$this->aire() ;
        if ($this->estCarre()) {
            $retour = $retour." Il s’agit d’un carré ";
        }else{
            $retour = $retour." Il ne s’agit pas d’un carré ";
        }
        return $retour;
    }
}