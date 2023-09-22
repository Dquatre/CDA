<?php

init();

function createSelect($valStart,$valEnd,$id){
    $return = '<select';
};

function init(){
    echo '<!DOCTYPE html>
    <html>
    <head>
        <link rel="stylesheet" href="style.css">
        <meta charset="UTF-8">
        <title>Memory</title>
    </head>
    <body>
        <form>
        <input type="text" list="nbPlayer" placeholder="Nombre de joueur" >
        <datalist id="nbPlayer">
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
            <option>5</option>
            <option>6</option>
            <option>7</option>
            <option>8</option>
            <option>9</option>
            <option>10</option>
        </datalist>
        <input type="text" id="nbPair" list="nbPairs" placeholder="Nombre de paire de carte">
        <datalist id="nbPairs">
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
            <option>5</option>
            <option>6</option>
            <option>7</option>
            <option>8</option>
            <option>9</option>
        </datalist>
        <input type="button" value="Démarrer">
        </form>
        <div id="cards"></div>
    
        <template>
            <img src="img/verso.png" data-image="DATATMAGE"></img>
        </template>
        <script src="./script.js"></script>
    </body>
    </html>';
};


