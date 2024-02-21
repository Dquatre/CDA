db = connect('mongodb://127.0.0.1:27017/salles');


// utilisation du module fs pour la lecture du fichier contenant les informations Json
// plus d'informations sur fs : https://welovedevs.com/fr/articles/how-to-use-node-fs/
const fs = require('fs');

// __dirname correspond au dossier du module courant (soit le dossier dans lequel ce script démarre)
// buffer contient le contenu du fichier 
let buffer = fs.readFileSync(`${__dirname}/salles.salles.json`);
let buffer2 = fs.readFileSync(`${__dirname}/salles.styles.json`);

// on parse le buffer pour récupérer un contenu Json exploitable
// ce Json ne fait pas figurer l'instanciation des types complexes tels que ObjectId ou IsoDate
const rawData = JSON.parse(buffer);
const rawData2 = JSON.parse(buffer2);
// Utilisation de la désérialisation EJSON (extensible Json) pour récupérer les types complexe
const salles = EJSON.deserialize(rawData)
const styles = EJSON.deserialize(rawData2)
console.log("********************************************************************************")
db.salles.insertMany(salles);
console.log("********************************************************************************")
db.styles.insertMany(styles);
