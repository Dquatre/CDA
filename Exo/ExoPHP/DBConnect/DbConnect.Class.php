<?php

class DbConnect {
    private static $db;

    public static function getDb() {
        return self::$db;
    }

    public static function init() {
        try {
            $db = new PDO('mysql:host=localhost;dbname=test;charset=utf8', 'root', '');
        } catch (Exception $e) {
            die('Erreur : ' . $e->getMessage());
        }
    }
}


