<?php
require 'Pave.php';
class Pentahedre extends TriangleRectangle{

/********************Variable*******************/

    protected $_profondeur;

/********************Accesseur*******************/

    public function getProfondeur()
    {
        return $this->_profondeur;
    }

    public function setProfondeur($profondeur)
    {
        $this->_profondeur = $profondeur;
    }


/********************Construct*******************/


    public function __construct(array $options = []){
        if (!empty($options)) {
            $this->hydrate($options);
        }
    }



/********************Methode*******************/
    public function perimetre()  {
        return 2*(parent::perimetre())+3*$this->_profondeur;
    }
    public function aire()  {
        return 2*(parent::aire()+$this->_profondeur*$this->_longueur+$this->_profondeur*$this->_largeur);
    }
    public function volume()  {
        return parent::aire()*$this->_profondeur;
    }
    public function estCarre()  {

    }
    public function afficher()  {
        echo $this; 
    }
    public function __toString(){
        $retour = "Longueur : ".$this->_longueur."cm - Largeur : ".$this->_largeur."cm - Profondeur : ".$this->_profondeur."cm - Périmètre : ".round($this->perimetre(),2)."cm - Aire : ".round($this->aire(),2)."cm² - Volume : ".round($this->volume(),2)."cm³" ;

        return $retour."\n";
    }

}