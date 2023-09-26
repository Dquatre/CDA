<?php
class Employe{

/********************Variable*******************/

    private $_nom;
    private $_prenom;
    private $_dateEmbauche;
    private $_poste;
    private $_salaire;
    private $_service;

/********************Accesseur*******************/
    
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

    public function getDateEmbauche()
    {
        return $this->_dateEmbauche;
    }

    public function setDateEmbauche($dateEmbauche)
    {
        $this->_dateEmbauche = $dateEmbauche;
    }

    public function getPoste()
    {
        return $this->_poste;
    }

    public function setPoste($poste)
    {
        $this->_poste = $poste;
    }

    public function getSalaire()
    {
        return $this->_salaire;
    }

    public function setSalaire($salaire)
    {
        $this->_salaire = $salaire;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = $service;
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

    public function calculAnciennete(){
        $currentDate = time();
        $dateEmbauche = strtotime($this->_dateEmbauche) ;
        $diff = floor(($currentDate - $dateEmbauche)/(365*24*60*60));
        return $diff;
    }
    public function calculPrime(){
        return ($this->_salaire*1000*0.05+$this->calculAnciennete()*$this->_salaire*1000*0.02);
    }
    public function __toString(){
        return $this->getPrenom()." ".$this->getNom()." salaire : ".$this->getSalaire()."k par an -";
    }
}