<?php
class MonstreFacile{

/********************Variable*******************/

    private $_isAlive;

/********************Accesseur*******************/
    
    public function getIsAlive()
    {
        return $this->_isAlive;
    }

    public function setIsAlive($isAlive)
    {
        $this->_isAlive = $isAlive;
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

    public function attack($player){
        
    }
    public function monsterDiceThrow() : int {
        return De::diceThrow();
    }


}