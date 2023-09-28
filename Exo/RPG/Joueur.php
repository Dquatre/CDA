<?php

class Joueur{

/********************Variable*******************/

    const HPDEFAULT = 50;
    private $_nom;//nom du joueur
    private $_pointsDeVie ; //point de vie du joueur

/********************Accesseur*******************/

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPointsDeVie()
    {
        return $this->_pointsDeVie;
    }

    private function setPointsDeVie($pointsDeVie)
    {
        $this->_pointsDeVie = $pointsDeVie;
    }



/********************Construct*******************/

    public function __construct(array $options = []){
        if (!empty($options)) {
            $this->hydrate($options);
        }
        $this->setPointsDeVie(Joueur::HPDEFAULT)  ; //constuit un joueur avec les point de vie par defaut 
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

    public function estVivant() : bool {
        return ($this->getPointsDeVie() > $this->getDegatsRecus()) ? true : false;
    }

    public function attaque(MonstreFacile $monstre,$debug){
        $attackPlayer = $this->lanceLeDe() ;
        $attackMonster = $monstre->lanceLeDe();
        if ($debug) {
            echo $this->getNom()." attaque a ".$attackPlayer." contre ".$attackMonster." pour le monstre.\n"  ;
        }
        if ($attackPlayer >= $attackMonster) {

            $monstre->subitDegats();
        }
    }

    public function bouclierFonctionne($debug){
        $jet = $this->lanceLeDe();
        if($debug)echo "jet de bouclier : ".$jet."\n";
        return ($jet<3) ? true : false;
    }

    public function subitDegats($degats,$debug){
        if($this->bouclierFonctionne($debug)){
            $degats = 0;
        }else{
           $this->setDegatsRecus($this->getDegatsRecus()+$degats); 
        }
        if($debug)echo $this->getNom()." subit ".$degats." points de degats il lui reste ".$this->pointDeVieRestant()." points de vie.\n";
        
    }

    public function lanceLeDe() : int {
        return De::lanceLeDe();
    }

    public function pointDeVieRestant() {
        return $this->getPointsDeVie()-$this->getDegatsRecus();
    }

}