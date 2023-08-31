<?php
    /*  
        ______
        |/  |
        |   o
        |  /|\
        |  / \
    ____|_______`
    */

    /**
     * demande de saisir un mot 
     *
     * @return string $mot
     */
    function enterWord(){
        return $mot;
    }

    /**
     * demande de saisir un chiffre entre 1,2 ou 3
     * raport a la difficulté du jeu
     *
     * @return int $niveau
     */
    function chooseLevel(){
        return $level;
    }

    /**
     * Undocumented function
     *
     * @return void
     */
    function enterNbPlayer(){
        return $nbPlayer;
    }

    /**
     * Undocumented function
     *
     * @param string $solution
     * @return array $secretWord
     */
    function wordBuider(string $solution,int $level): array{
        return $secretWord;
    }

    /**
     * Undocumented function
     *
     * @param string $secretWord
     * @param integer $level
     * @param array $proposition
     * @param integer $failedAttempt
     * @return void
     */
    function diplay(array $secretWord,int $level,array $proposition,int $failedAttempt){

    }

    /**
     * Undocumented function
     *
     * @param array $motCacher
     * @return void
     */
    function diplaySecretWord(array $secretWord){

    }

    /**
     * Undocumented function
     *
     * @param array $lettrePropose
     * @return void
     */
    function displayProposition(array $proposition){

    }

    /**
     * Undocumented function
     *
     * @return void
     */
    function drawHangMan(){

    }

    /**
     * Undocumented function
     *
     * @return void
     */
    function enterLetter(int $idPlayer){
        return $letter;
    }

    /**
     * Undocumented function
     *
     * @param string $letter
     * @param array $secretword
     * @param array $proposition
     * @return boolean
     */
    function check(string $letter, array $secretword, array $proposition): bool{

    }

    /**
     * Undocumented function
     *
     * @param string $letter
     * @param string $solution
     * @param array $secretword
     * @param array $proposition
     * @param integer $failedAttempt
     * @return void
     */
    function update(string $letter,string $solution,array $secretword, array $proposition, int $failedAttempt){

    }

    /**
     * Undocumented function
     *
     * @return void
     */
    function main(){
        
    }