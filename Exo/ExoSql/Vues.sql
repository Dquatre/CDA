DROP VIEW IF EXISTS etudiants_epreuves;
CREATE VIEW etudiants_epreuves AS
SELECT
    e.idEtudiant,
    e.nomEtudiant,
    e.prenomEtudiant,
    e.adresseEtudiant,
    e.villeEtudiant,
    e.codePostalEtudiant,
    e.telephoneEtudiant,
    e.dateEntreeEtudiant,
    e.anneeEtudiant,
    e.remarqueEtudiant,
    e.sexeEtudiant,
    e.dateNaissanceEtudiant,
    e.hobby,
    ep.idEpreuve,
    ep.libelleEpreuve,
    ep.idEnseignantEpreuve,
    ep.idMatiereEpreuve,
    ep.dateEpreuve,
    ep.CoefficientEpreuve,
    ep.anneeEpreuve,
    a.idAvoirNote,
    a.note
FROM
    avoir_note a
INNER JOIN etudiants e ON
    a.idEtudiant = e.idEtudiant
INNER JOIN epreuves ep ON
    a.idEpreuve = ep.idEpreuve