<?php

echo'
<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="style.css">
    <meta charset="UTF-8">
    <title>Memory</title>
</head>
<body>
    <form>
    <input type="text" id="nbPlayer" placeholder="Nombre de joueur" pattern="^[0-9]{1,2}" autocomplete="off" maxlength="2" required>
    <input type="text" id="nbPair" placeholder="Nombre de paire de carte" pattern="^[0-9]{1,2}" autocomplete="off" maxlength="2" required>
    <input type="submit" value="Démarrer">
    </form>
</body>
</html>
';