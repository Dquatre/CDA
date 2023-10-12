<?php

class DbConnect {
    private static $_db;

    public static function getDb() {
        return self::$_db;
    }

    public static function init() {
        Parameter::init();
        try {
            self::$_db = new PDO("mysql:host=".Parameter::getHost().";port=".Parameter::getPort().";dbname=".Parameter::getDbname().";charset=".Parameter::getCharset(), Parameter::getUser(), Parameter::getPassword());
        } catch (Exception $e) {
            die('Erreur : ' . $e->getMessage());
        }
    }
}


