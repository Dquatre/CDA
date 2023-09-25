<?php
abstract class Polygone{

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
 
    }
    public function aire()  {
    }
    public function estCarre()  {
        
    }

    public function __toString(){
    }
}