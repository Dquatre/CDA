
--
-- 1.
--

SELECT
    ville_id,
    ville_departement,
    ville_slug,
    ville_nom,
    ville_nom_simple,
    ville_nom_reel,
    ville_nom_soundex,
    ville_nom_metaphone,
    ville_code_postal,
    ville_commune,
    ville_code_commune,
    ville_arrondissement,
    ville_canton,
    ville_amdi,
    ville_population_2010,
    ville_population_1999,
    ville_population_2012,
    ville_densite_2010,
    ville_surface,
    ville_longitude_deg,
    ville_latitude_deg,
    ville_longitude_grd,
    ville_latitude_grd,
    ville_longitude_dms,
    ville_latitude_dms,
    ville_zmin,
    ville_zmax
FROM
    villes_france
WHERE
    ville_nom LIKE "40[_]%"

--
-- 2.
--


SELECT
    departement_id,
    departement_code,
    departement_nom,
    departement_nom_uppercase,
    departement_slug,
    departement_nom_soundex,
    departement_regionId
FROM
    departements
WHERE
    departement_code LIKE "97%"

--
-- 3.
--

SELECT
    departement_id,
    departement_code,
    departement_nom,
    departement_nom_uppercase,
    departement_slug,
    departement_nom_soundex,
    departement_regionId
FROM
    departements
WHERE
    departement_regionId = 7
ORDER BY
    departement_nom

--
-- 4.
--

SELECT
    vf.ville_id,
    vf.ville_nom,
    d.departement_nom
FROM
    villes_france vf
JOIN departements d ON
    vf.ville_departement = d.departement_code
ORDER BY
    ville_population_2012
DESC
    
--
-- 5.
--

SELECT
    d.departement_nom,
    d.departement_code,
    COUNT(vf.ville_id) AS nombre_de_commune
FROM
    villes_france vf
JOIN departements d ON
    vf.ville_departement = d.departement_code
GROUP BY d.departement_nom
ORDER BY
    COUNT(vf.ville_id)
DESC

--
-- 6.
--

SELECT
    d.departement_id,
    d.departement_code,
    d.departement_nom,
    d.departement_nom_uppercase,
    d.departement_slug,
    d.departement_nom_soundex,
    d.departement_regionId,
    SUM(vf.ville_surface) AS superficie
FROM
    villes_france vf
JOIN departements d ON
    vf.ville_departement = d.departement_code
GROUP BY
    d.departement_nom
ORDER BY
    SUM(vf.ville_surface)
DESC
    
--
-- 7.
--

SELECT
    COUNT(ville_id) AS nombre_de_commune
FROM
    villes_france
WHERE
    ville_nom LIKE "SAINT%";

--si on exclu sainte

SELECT
    COUNT(ville_id) AS nombre_de_commune
FROM
    villes_france
WHERE
    ville_nom_simple LIKE "saint %";

--
-- 8.
--

SELECT
    ville_nom,
    COUNT(ville_id)
FROM
    villes_france
GROUP BY
    ville_nom
HAVING
    COUNT(ville_id) > 1
ORDER BY
    COUNT(ville_id)
DESC
    
--
-- 9.
--

SELECT
    ville_id,
    ville_nom,
    ville_surface,
--
    ville_departement,
    ville_slug,
    ville_nom_simple,
    ville_nom_reel,
    ville_nom_soundex,
    ville_nom_metaphone,
    ville_code_postal,
    ville_commune,
    ville_code_commune,
    ville_arrondissement,
    ville_canton,
    ville_amdi,
    ville_population_2010,
    ville_population_1999,
    ville_population_2012,
    ville_densite_2010,
    ville_longitude_deg,
    ville_latitude_deg,
    ville_longitude_grd,
    ville_latitude_grd,
    ville_longitude_dms,
    ville_latitude_dms,
    ville_zmin,
    ville_zmax
--
FROM
    villes_france
WHERE
    ville_surface >(
    SELECT
        AVG(ville_surface)
    FROM
        villes_france
)

--
-- 10.
--

SELECT
    d.departement_id,
    d.departement_code,
    d.departement_nom,
    d.departement_nom_uppercase,
    d.departement_slug,
    d.departement_nom_soundex,
    d.departement_regionId,
    SUM(vf.ville_population_2012) AS superficie
FROM
    villes_france vf
JOIN departements d ON
    vf.ville_departement = d.departement_code
GROUP BY
    d.departement_nom
HAVING SUM(vf.ville_population_2012) > 1500000

--
-- 11.
--

UPDATE
    villes_france
SET
    ville_nom =
REPLACE
    (ville_nom, '-', ' ')
WHERE
    ville_nom LIKE "SAINT-%";


--
-- 12.
--

SELECT
    ville_nom,
    ville_surface,
--
  	ville_id,
    ville_departement,
    ville_slug,
    ville_nom_simple,
    ville_nom_reel,
    ville_nom_soundex,
    ville_nom_metaphone,
    ville_code_postal,
    ville_commune,
    ville_code_commune,
    ville_arrondissement,
    ville_canton,
    ville_amdi,
    ville_population_2010,
    ville_population_1999,
    ville_population_2012,
    ville_densite_2010,
    ville_longitude_deg,
    ville_latitude_deg,
    ville_longitude_grd,
    ville_latitude_grd,
    ville_longitude_dms,
    ville_latitude_dms,
    ville_zmin,
    ville_zmax
--
FROM
    villes_france
ORDER BY ville_surface
LIMIT 50

--
-- 13.
--

ALTER TABLE regions ADD COLUMN region_nbDepartement int

--
-- 14.
--


UPDATE regions SET region_nbDepartement= (SELECT COUNT(departement_id) FROM departements WHERE departement_regionId = region_id);

DELIMITER $$
CREATE PROCEDURE Update_nb_dep()
UPDATE regions SET region_nbDepartement= (SELECT COUNT(departement_id) FROM departements WHERE departement_regionId = region_id)$$
DELIMITER ;

--
-- 15.
--

CREATE VIEW ville_departement_region AS
SELECT
    vf.ville_id,
    vf.ville_slug,
    vf.ville_nom,
    vf.ville_nom_simple,
    vf.ville_nom_reel,
    vf.ville_nom_soundex,
    vf.ville_nom_metaphone,
    vf.ville_code_postal,
    vf.ville_commune,
    vf.ville_code_commune,
    vf.ville_arrondissement,
    vf.ville_canton,
    vf.ville_amdi,
    vf.ville_population_2010,
    vf.ville_population_1999,
    vf.ville_population_2012,
    vf.ville_densite_2010,
    vf.ville_surface,
    vf.ville_longitude_deg,
    vf.ville_latitude_deg,
    vf.ville_longitude_grd,
    vf.ville_latitude_grd,
    vf.ville_longitude_dms,
    vf.ville_latitude_dms,
    vf.ville_zmin,
    vf.ville_zmax,
    vf.ville_departement,
    d.departement_id,
    d.departement_nom,
    d.departement_nom_uppercase,
    d.departement_slug,
    d.departement_nom_soundex,
    d.departement_regionId,
    region_nom,
    region_nbDepartement
FROM
    villes_france vf
JOIN departements d ON
    vf.ville_departement = d.departement_code
JOIN regions r ON
    d.departement_regionId = r.region_id


--
-- facultatif
--
ALTER TABLE villes_france ADD FOREIGN KEY FK_ville_departement (ville_departement) ;










