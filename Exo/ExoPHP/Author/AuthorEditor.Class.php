<?php
class AuthorEditor extends User implements Author,Editor{

/********************Variable*******************/

    private $_authorPrivilegesArray ;
    private $_editorPrivilegesArray ;

/********************Accesseur*******************/
public function getAuthorPrivileges()
{
    $ret="";
    foreach ($this->_authorPrivilegesArray  as $value) {
        $ret = $ret.$value.", ";
    }
    return $ret;
}

public function setAuthorPrivileges($authorPrivilegesArray)
{
    $this->_authorPrivilegesArray = $authorPrivilegesArray;
}

public function getEditorPrivileges()
{
    $ret="";
    foreach ($this->_editorPrivilegesArray  as $value) {
        $ret = $ret.$value.", ";
    }
    return $ret;
}

public function setEditorPrivileges($editorPrivilegesArray)
{
    $this->_editorPrivilegesArray = $editorPrivilegesArray;
}


/********************Construct*******************/


    public function __construct(array $options = []){
        if (!empty($options)) {
            $this->hydrate($options);
        }
    }



/********************Methode*******************/

public function __ToString() : string {
    return parent::__ToString().", ".$this->getUsername()." has the following privileges: ".$this->getAuthorPrivileges().$this->getEditorPrivileges() ;
}




}