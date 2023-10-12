<?php

class Personnes{

/********************Variable*******************/

    private $_idPersonne;
    private $_nom;
    private $_prenom;
    private static $_properties = ["idPersonne","nom","prenom"];

/********************Accesseur*******************/

    public function getIdPersonne()
    {
        return $this->_idPersonne;
    }

    public function setIdPersonne($_idPersonne)
    {
        $this->_idPersonne = $_idPersonne;
    }

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
    }
    public function getProperties()
    {
        return self::$_properties;
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



}