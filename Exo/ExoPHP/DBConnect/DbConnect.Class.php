<?php

class DbConnect {
    private static $db;

    public static function getDb() {
        return DbConnect::$db;
    }

    public static function init() {
        $base = 'test';
        $utilisateur = 'root';
        $motDePasse ='';

        try {
            $db = new PDO('mysql:host=localhost;dbname='.$base.' ;charset=utf8', $utilisateur, $motDePasse);
            $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch (Exception $e) {
            echo 'Erreur : ' . $e->getMessage() . ' N° : '.$e->getCode();
            die('Fin du script');
        }
    }
}


