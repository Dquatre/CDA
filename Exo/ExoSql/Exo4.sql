SELECT nomdep FROM departement;
SELECT nodep,nomdep FROM departement;
SELECT noemp,nomemb,fonction,noresp,datemp,sala,comm,nodep FROM employe;
SELECT fonction FROM employe;
SELECT DISTINCT fonction FROM employe;
SELECT nomemp,datemb,DATE_ADD(datemb , INTERVAL 1 day) FROM employe;

SELECT noemp,nomemp FROM employe WHERE nodep = 30;
SELECT noemp,nomemp,nodep FROM employe WHERE  fonction = "ouvrier" OR fonction = "Ouvrier";
SELECT nodep,nomdep FROM departement WHERE nodep > 30; 
SELECT nomemp,sala,comm FROM employe WHERE sala < comm;
SELECT nomemp,sala FROM employe WHERE fonction = "vendeur" AND nodep = 30 AND sala > 1500;
SELECT nomemp,fonction,sala FROM employe WHERE fonction = "Président" OR fonction = "directeur" ;
SELECT nomemp,fonction,sala FROM employe WHERE fonction = "directeur" OR sala > 2500;
SELECT nomemp,fonction,nodep FROM employe WHERE (fonction = "directeur" OR fonction = "ouvrier")AND nodep = 10 ;
SELECT nomemp,fonction,nodep FROM employe WHERE !(fonction = "directeur" OR fonction = "ouvrier")AND nodep = 10 ;
SELECT nomemp,fonction,sala FROM employe WHERE fonction = "directeur" AND nodep != 30 ;
SELECT nomemp,fonction,sala FROM employe WHERE sala >= 1200 AND sala <=1300 ;
SELECT nomemp,fonction,nodep FROM employe WHERE fonction = "vendeur" OR fonction = "ouvrier" OR fonction = "analyste";
SELECT noemp,nomemb,fonction,noresp,datemb,sala,comm,nodep FROM employe WHERE fonction != "vendeur" ;
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep  FROM employe WHERE nomemp LIKE "C%" ;
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep  FROM employe WHERE comm IS NULL;
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep  FROM employe WHERE comm IS NOT NULL AND (nodep = 30 OR nodep = 20);

SELECT nomemp,fonction,sala FROM employe WHERE nodep = 30 ORDER BY sala;
SELECT nomemp,fonction,sala FROM employe WHERE nodep = 30 ORDER BY sala DESC;
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep FROM employe ORDER BY fonction,sala DESC;
SELECT nomemp,comm,sala FROM employe WHERE nodep = 30 ORDER BY comm;
SELECT nomemp,comm,sala FROM employe WHERE nodep = 30 ORDER BY comm DESC;

SELECT d.ville FROM employe e JOIN departement d ON e.nodep = d.nodep WHERE e.nomemp = "costanza";
SELECT e.nomemp,e.fonction,d.nomdep FROM employe e JOIN departement d ON e.nodep = d.nodep WHERE e.nodep = 30 OR e.nodep = 40 ;
SELECT e.nomemp,e.fonction,g.nograde FROM `employe` e, grade g WHERE e.sala >= g.salmin AND e.sala <= g.salmax
SELECT e.nomemp FROM employe e JOIN employe em ON e.noresp = em.noemp WHERE e.sala > em.sala; 
SELECT nomemp,fonction,sala FROM employe WHERE sala > (SELECT e.sala FROM employe e WHERE nomemp = "Perou");

SELECT nomemp,sala,comm,sala+comm AS revenus FROM employe WHERE fonction = "vendeur" ;
SELECT nomemp,sala,comm FROM employe WHERE comm > sala*0.25 ;
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep  FROM employe WHERE fonction = "vendeur" ORDER BY comm/sala DESC;
SELECT noemp,nomemp,fonction,(sala+comm)*12 AS revenuAnnuel  FROM employe
SELECT noemp,nomemp,fonction,sala/30 AS salaireJournalier FROM employe;
SELECT AVG(sala) AS MoySalaire FROM employe WHERE fonction = "ouvrier";
SELECT SUM(sala+comm) AS totalSalaire FROM employe WHERE fonction = "vendeur";
SELECT AVG(sala*12) AS moyAnnuel FROM employe WHERE fonction = "vendeur";
SELECT MAX(sala),MIN(sala),MAX(sala)-MIN(sala) AS INTERVALMinMax FROM employe;
SELECT COUNT(noemp) FROM employe WHERE nodep = 30;

SELECT AVG(sala),nodep FROM employe GROUP BY nodep;
SELECT AVG(sala*12),nodep FROM employe WHERE fonction != "président" AND fonction != "directeur" GROUP BY nodep;
SELECT AVG(sala*12)AS salaireAnnuel,COUNT(noemp)AS nombreEmp,nodep,fonction FROM employe GROUP BY nodep,fonction;
SELECT sala*12 AS salaireAnnuel,COUNT(noemp) AS nombreEmp ,fonction FROM employe GROUP BY fonction HAVING COUNT(noemp) > 2;
SELECT nodep,COUNT(noemp) AS nombreEmp FROM employe GROUP BY nodep,fonction HAVING fonction = "ouvrier" AND COUNT(noemp) > 2;
SELECT fonction,AVG(sala) AS moySalaire FROM employe GROUP BY fonction HAVING fonction = "président" OR fonction = "directeur" OR fonction = "responsable";

SELECT noemp,nomemp,fonction FROM employe WHERE (sala+IFNULL(comm, 0 )) > (SELECT sala+IFNULL(comm, 0 ) FROM employe WHERE nomemp = "Bibaut")
SELECT fonction, AVG(sala) AS moySalaire FROM `employe` GROUP BY fonction HAVING AVG(sala) > (SELECT AVG(sala) FROM employe WHERE fonction = "vendeur")
SELECT DISTINCT d.nomdep FROM departement d JOIN `employe` e  on e.nodep = d.nodep WHERE sala > 2700
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep FROM employe WHERE datemb = (SELECT MIN(datemb) FROM employe);
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep FROM employe WHERE datemb = (SELECT MAX(datemb) FROM employe);
SELECT noemp,nomemp,fonction,noresp,datemb,sala,comm,nodep FROM employe WHERE noemp in (SELECT noresp FROM employe);






