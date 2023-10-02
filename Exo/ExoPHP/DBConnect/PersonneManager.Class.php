<?php

class PersonneManager{

    static public function add(Personne $perso){
        $db = DbConnect::getDb();
        $q = $db->prepare('INSERT INTO personnes(nom, pernom) VALUES(:nom, :prenom)');

        $q->bindValue(':nom', $perso->getNom());
        $q->bindValue(':prenom', $perso->getPrenom());

        $q->execute();
    }

    static public function delete(Personne $perso){
        $db = DbConnect::getDb();
        $q = $db->exec('DELETE FROM personnes WHERE id = '.$perso->getId());
    }

    static public function get($id) {
        $db = DbConnect::getDb();

        $id = (int) $id;

        $q = $db->query('SELECT id,nom,prenom FROM personnes WHERE id = '.$id);
        $donnees = $q->fetch(PDO::FETCH_ASSOC);

        return new Personne($donnees);
    }

}