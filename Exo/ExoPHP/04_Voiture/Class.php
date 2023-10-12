<?php
class Voiture{

/********************Variable*******************/
    private $_couleur;
    private $_marque;
    private $_modele;
    private $_nbKilometre;
    private $_motorisation;

/********************Accesseur*******************/

    public function getCouleur()
    {
    return $this->_couleur;
    }

    public function setCouleur($couleur)
    {
    $this->_couleur = $couleur;
    }

    public function getMarque()
    {
    return $this->_marque;
    }

    public function setMarque($marque)
    {
    $this->_marque = $marque;
    }

    public function getModele()
    {
    return $this->_modele;
    }

    public function setModele($modele)
    {
    $this->_modele = $modele;
    }

    public function getNbKilometre()
    {
    return $this->_nbKilometre;
    }

    public function setNbKilometre($nbKilometre)
    {
    $this->_nbKilometre = $nbKilometre;
    }

    public function getMotorisation()
    {
    return $this->_motorisation;
    }

    public function setMotorisation($motorisation)
    {
    $this->_motorisation = $motorisation;
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
                $this->$methode(value);
            }
        }
    }

/********************Methode*******************/


    public function __toString() {
        return "Cette voiture est un modèle de la marque ".$this->_marque.", de couleur ".$this->_couleur.", de motorisation ".$this->_modele.", avec ".$this->_nbKilometre." kilomètres au compteur\n";
    }

    public function rouler($kmParcouru){
        $this->_nbKilometre += $kmParcouru;
    }
}

