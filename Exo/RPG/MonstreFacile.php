<?php
class MonstreFacile{

/********************Variable*******************/

    protected $_estVivant = true;
    private static $nbMonstre;
    const DEGATS = 50;

/********************Accesseur*******************/
    
    public function getEstVivant()
    {
        return $this->_estVivant;
    }

    public function setEstVivant($estVivant)
    {
        $this->_estVivant = $estVivant;
    }

    public static function getNbMonstre()
    {
        return self::$nbMonstre;
    }

    public function setNbMonstre($nbMonstre)
    {
        self::$nbMonstre = $nbMonstre;
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

    public function attaque($player,$debug){
        $attackMonster = $this->lanceLeDe();
        $attackPlayer = $player->lanceLeDe() ;
        if ($debug) {
            echo "Le monstre attaque a ".$attackMonster." contre ".$attackPlayer." pour ".$player->getNom()."\n"  ;
        }
        if ($attackMonster > $attackPlayer) {
            $player->subitDegats(MonstreFacile::DEGATS,$debug);
        }
    }
    public function lanceLeDe() : int {
        return De::lanceLeDe();
    }

    public function subitDegats(){
        $this->setEstVivant(false);
        
    }


}