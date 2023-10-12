<?php

class TriangleRectangle  {


/********************Variable*******************/
protected $_longueur;
protected $_largeur;

/********************Accesseur*******************/

public function getLongueur()
{
return $this->_longueur;
}

public function setLongueur($longueur)
{
$this->_longueur = $longueur;
}

public function getLargeur()
{
return $this->_largeur;
}

public function setLargeur($largeur)
{
$this->_largeur = $largeur;
}


/********************Construct*******************/


public function __construct(array $options = []){
    if (!empty($options)) {
        $this->hydrate($options);
    }
}
public function hydrate($data){
    foreach ($data as $key => $value) {
        $methode = 'set' . ucfirst($key);
        if (is_callable([$this, $methode])) { 
            $this->$methode($value);
        }
    }
}

/********************Methode*******************/
public function perimetre()  {
    return $this->_largeur+$this->_longueur+sqrt(pow($this->_largeur,2) + pow($this->_longueur,2));
}
public function aire()  {
    return $this->_largeur*$this->_longueur/2;
}

public function afficher()  {
    echo $this; 
}
public function __toString(){
    $retour = "Longueur : ".$this->_longueur."cm - Largeur : ".$this->_largeur."cm  - Périmètre : ".round($this->perimetre(),2)."cm - Aire : ".round($this->aire(),2)."cm²" ;
    return $retour."\n";
}

}