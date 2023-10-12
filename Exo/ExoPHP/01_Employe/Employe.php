<?php
class Employe {

/********************Variable*******************/

    private $_nom;
    private $_prenom;
    private $_dateEmbauche;
    private $_poste;
    private $_salaire;
    private $_service;
    public static $_counter;
    private $_Agence;
    private $_ListAgeEnfant;

/********************Accesseur*******************/
    
    public function getNom()
    {
        return ucfirst($this->_nom);
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return ucfirst($this->_prenom);
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

    public static function getCounter()
    {
        return self::$_counter;
    }

    public function getAgence()
    {
        return $this->_Agence;
    }

    public function setAgence(Agence $Agence)
    {
        $this->_Agence = $Agence;
    }
    
    public function getListAgeEnfant()
    {
        return $this->_ListAgeEnfant;
    }

    public function setListAgeEnfant($ListAgeEnfant)
    {
        $this->_ListAgeEnfant = $ListAgeEnfant;
    }

/********************Construct*******************/


    public function __construct(array $options = []){
        if (!empty($options)) {
            $this->hydrate($options);
        }
        self::$_counter++;
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
    public static function compareTo($emp1,$emp2){
        return strcasecmp($emp1->getService() > $emp2->getService());
    }

    public function __toString(){
        return $this->getPrenom()." ".$this->getNom().", salaire : ".$this->getSalaire()."k par an, ".$this->getPoste()." au service ".$this->getService().", recrute le ".$this->getDateEmbauche()." dans l'agence ".$this->getAgence()->getNom().",".$this->getAgence()->getARestoration()."\n";
    }

    public function calculAnciennete(){
        $currentDate = time();
        $dateEmbauche = strtotime($this->_dateEmbauche) ;
        $diff = floor(($currentDate - $dateEmbauche)/(365*24*60*60));
        return $diff;
    }
    public function calculPrime(){
        return ($this->_salaire*1000*0.05+$this->calculAnciennete()*$this->_salaire*1000*0.02);
    }

    public function estEligibleChequeVacance(){
        if($this->calculAnciennete() > 1){
            return true;
        }
        return false;
    }

    public function calculChequeCadeau(){
        $cheque20 =0;
        $cheque30 =0;
        $cheque50 =0;
        if ($this->getListAgeEnfant() != null) {
            for ($i=0; $i < sizeof($this->getListAgeEnfant()); $i++) { 
                if ($this->getListAgeEnfant()[$i] > 0 && $this->getListAgeEnfant()[$i]  <= 10) {
                    $cheque20++;
                }elseif ($this->getListAgeEnfant()[$i]  <= 15) {
                    $cheque30++;
                }elseif ($this->getListAgeEnfant()[$i]  <= 18) {
                    $cheque50++;
                }
            }
            echo $this->getNom()." ".$this->getPrenom()." \n";
            if ($cheque20 > 0) {
                echo "  ".$cheque20." cheque de 20 euros\n";
            }
            if ($cheque30 > 0) {
                echo "  ".$cheque30." cheque de 30 euros\n";
            }
            if ($cheque50 > 0) {
                echo "  ".$cheque50." cheque de 50 euros\n";
            }
        }
        
    }




}