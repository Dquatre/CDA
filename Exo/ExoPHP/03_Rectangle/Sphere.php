<?php
require 'Cercle.php';
class Sphere extends Cercle{

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
    }
    public function aire()  {
        return 4*pi()*pow($this->_diametre/2,2);
    }

    public function volume()  {
        return (3/4)*pi()*pow($this->_diametre/2,3);
    }

    public function afficher()  {
        echo $this; 
    }
    public function __toString(){
        $retour = "Diametre : ".$this->_diametre."cm - Périmètre : ".round($this->perimetre(),2)."cm - Aire : ".round($this->aire(),2)."cm² - Volume : ".round($this->volume(),2)."cm³" ;
        return $retour."\n";
    }

}