<?php
const HPDEFAULT = 50;
class Joueur{

/********************Variable*******************/

    
    private $name;//nom du joueur
    private $_hp ; //point de vie du joueur
    private $_vp = 0; //point de victoire accumuler en tuant des monstre
    private $_damageRecived = 0; //point de domage subit par le joueur

/********************Accesseur*******************/

    public function getHp()
    {
        return $this->_hp;
    }

    public function setHp($hp)
    {
        $this->_hp = $hp;
    }

    public function getVp()
    {
        return $this->_vp;
    }

    public function setVp($vp)
    {
        $this->_vp = $vp;
    }
    public function getName()
    {
        return $this->name;
    }

    public function setName($name)
    {
        $this->name = $name;
    }

    public function getDamageRecived()
    {
        return $this->_damageRecived;
    }

    public function setDamageRecived($damageRecived)
    {
        $this->_damageRecived = $damageRecived;
    }
 

/********************Construct*******************/

    public function __construct(array $options = []){
        if (!empty($options)) {
            $this->hydrate($options);
        }
        $this->_hp = HPDEFAULT; //constuit un joueur avec les point de vie par defaut 
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

    public function isAlive() : bool {
        return ($this->getHp > 0) ? true : false;
    }

    public function attack(MonstreFacile $monster){
        $attackPlayer = $this->playerDiceThrow() ;
        $attackMonster = $monster->MonsterDiceThrow();
        if ($attackPlayer < $attackMonster) {
            $monster->setIsAlive(false);
        }
        return $this->getName()." attaque a ".$attackPlayer." contre ".$attackMonster." pour l'orc'\n"  ;
    }
    public function reciveDamage($damage){
        $this->setDamageRecived($this->getDamageRecived()+$damage);
    }
    public function calculHealthLeft()  {
        return $this->getHp()-$this->getDamageRecived();
    }

    public function playerDiceThrow() : int {
        return De::diceThrow();
    }
}