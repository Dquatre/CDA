<?php
class Agence{

/********************Variable*******************/

    private $_nom;
    private $_addresse;
    private $_codePostal;
    private $_ville;
    private $_aRestoration;

/********************Accesseur*******************/

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getAddresse()
    {
        return $this->_addresse;
    }

    public function setAddresse($addresse)
    {
        $this->_addresse = $addresse;
    }

    public function getCodePostal()
    {
        return $this->_codePostal;
    }

    public function setCodePostal($codePostal)
    {
        $this->_codePostal = $codePostal;
    }

    public function getVille()
    {
        return $this->_ville;
    }

    public function setVille($ville)
    {
        $this->_ville = $ville;
    }

    public function getARestoration()
    {
        if($this->_aRestoration){
            return " mange au restorant de l'entreprise";
        }
        return " beneficie de tickets restauts";
    }

    public function setARestoration($aRestoration)
    {
        $this->_aRestoration = $aRestoration;
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