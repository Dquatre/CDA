<?php

#region require
    function ChargerClasse($classe){
        require $classe.".Class.php";
    }
    spl_autoload_register("ChargerClasse");

#endregion

$user1 = new AuthorEditor(["username"=>"Balthazar"]);
$user1->setAuthorPrivileges(["write text","add punctuation"]);
$user1->setEditorPrivileges(["edit text","edit punctuation"]);
echo $user1;