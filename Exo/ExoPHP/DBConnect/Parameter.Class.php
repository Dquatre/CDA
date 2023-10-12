<?php

class Parameter{

/**************************Properties*******************************/

    private static $_host;
    private static $_port;
    private static $_dbname;
    private static $_charset;
    private static $_user;
    private static $_password;

/**************************Getters_Setters**************************/

  
    public static function getHost()
    {
        return self::$_host;
    }

    public static function setHost($host)
    {
        self::$_host = $host;
    }

    public static function getPort()
    {
        return self::$_port;
    }

    public static function setPort($port)
    {
        self::$_port = $port;
    }

    public static function getDbname()
    {
        return self::$_dbname;
    }

    public static function setDbname($dbname)
    {
        self::$_dbname = $dbname;
    }

    public static function getCharset()
    {
        return self::$_charset;
    }

    public static function setCharset($charset)
    {
        self::$_charset = $charset;
    }

    public static function getUser()
    {
        return self::$_user;
    }

    public static function setUser($user)
    {
        self::$_user = $user;
    }

    public static function getPassword()
    {
        return self::$_password;
    }

    public static function setPassword($password)
    {
        self::$_password = $password;
    }

/**************************Construct********************************/

    public static function init(){
        $text = fopen("config.json", "r");
        $param = fgets($text,4096);
        $obj = json_decode($param);
        self::setHost($obj->host);
        self::setPort($obj->port);
        self::setDbname($obj->dbname);
        self::setCharset($obj->charset);
        self::setUser($obj->user);
        self::setPassword($obj->password);
    }

/**************************Methods***********************************/











 


}