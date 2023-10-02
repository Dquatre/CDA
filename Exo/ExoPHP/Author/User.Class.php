<?php
class User{

/********************Variable*******************/

    protected $_username;



/********************Accesseur*******************/

    public function getUsername()
    {
        return $this->_username;
    }

    public function setUsername($username)
    {
        $this->_username = $username;
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

    public function __ToString() : string {
        return $this->getUsername()." is ".(($this->IsReading())? "reading" : "not reading"); 
    }

    public function IsReading() : bool {
        return rand(0,1) == 1;
    }


}