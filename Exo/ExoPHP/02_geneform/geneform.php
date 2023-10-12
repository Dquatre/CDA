<?php

class Formulaire{
    public int $id;
    public string $name;

    public function getId():int
    {
        return $this->id;
    }
    public function getName():spring
    {
        return $this->name;
    }
    public function setId():void
    {
        $this->id = $id;
    }
    public function setName():spring
    {
        $this->name = $name;
    }
};

function genereForm(){
    $formulaire = New Formulaire();
    echo "<div id = main>";
    echo "<form>";
    echo "<input type=\"text\" placeholder=\"Nom\" class=\"nom\" pattern=\"^\w{1,}\" required>";
    echo "<input type=\"submit\" >";
    echo "</form>";
    echo"</div>";
}
genereForm();