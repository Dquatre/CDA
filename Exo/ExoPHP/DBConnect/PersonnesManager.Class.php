<?php

class PersonnesManager{

    static public function select(?array $colonnes=null,?array $conditions=null,?array $orderBy=null,?string $limit="" ,?bool $debug=false) {
        return DAO::select("personnes",$colonnes,$conditions,$orderBy,$limit,$debug);
    }

    static public function findById($id,?bool $debug=false) {
        return DAO::select("personnes",null,["id"=>$id],null,null,$debug);
    }

    public static function add(Personnes $perso,?bool $debug=false){
        DAO::add($perso);
    }

    public static function update(Personnes $perso,?bool $debug=false){
        DAO::update($perso);
    }

    static public function delete(Personnes $perso,?bool $debug=false){
        DAO::delete($perso);
    }
    
}