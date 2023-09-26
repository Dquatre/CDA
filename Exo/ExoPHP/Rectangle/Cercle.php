<?php
class Cercle{

/********************Variable*******************/
private $_diametre;

/********************Accesseur*******************/
public function getDiametre()
{
return $this->_diametre;
}

public function setDiametre($diametre)
{
$this->_diametre = $diametre;
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
        return $this->_diametre*pi();
    }
    public function aire()  {
        return pi()*pow($this->_diametre/2,2);
    }
 
    public function afficher()  {
        echo $this; 
    }
    public function __toString(){
        $retour = "Diametre : ".$this->_diametre."cm - Périmètre : ".round($this->perimetre(),2)."cm - Aire : ".round($this->aire(),2)."cm²" ;
        return $retour."\n";
    }
}