use colonial_journey_management_system_db;

-- 3.    Вмъкване на данни
INSERT INTO travel_cards (card_number, job_during_journey,journey_id,colonist_id)
SELECT 
	CASE
		WHEN birth_date > '1980-01-01' THEN concat(year(birth_date), day(birth_date), left(ucn,4))
		ELSE concat(year(birth_date), day(birth_date), right(ucn,4))
	END, 
	CASE
		WHEN id % 2 = 0 THEN "Pilot"
		WHEN id % 3 = 0 THEN "Cook"
		ELSE "Engineer"
	END,
		left(ucn,1), id
FROM colonists
WHERE id BETWEEN 96 AND 100;

-- ALTER TABLE travel_cards AUTO_INCREMENT = 96;

-- 4.    Обновяване на данни 
SET SQL_SAFE_UPDATES=0;
UPDATE journeys set purpose = 
	CASE
        WHEN id % 2 = 0 THEN "Medical"
        WHEN id % 3 = 0 THEN "Technical"
        WHEN id % 5 = 0 THEN "Educational"
        WHEN id % 7 = 0 THEN "Military"
        ELSE purpose
	END;
SET SQL_SAFE_UPDATES=1;

-- 5.    Изтриване на данни
SET SQL_SAFE_UPDATES=0;
DELETE c FROM colonists c
	left join travel_cards t
		on c.id = t.colonist_id
 WHERE t.colonist_id is null;
 SET SQL_SAFE_UPDATES=1;

-- 05. Извлечете всички карти за пътуване
SELECT card_number, job_during_journey FROM travel_cards ORDER BY card_number;

-- 06. Извлечете всички колонисти
SELECT id, concat(first_name, ' ', last_name) AS full_name, ucn FROM colonists
ORDER BY first_name, last_name, id;
    
-- 07. Извлечете всички военни пътувания
SELECT id, journey_start, journey_end from journeys
WHERE purpose = "Military"
ORDER BY journey_start;
    
-- 08. Извлечете всички пилоти
SELECT c.id, concat(c.first_name, ' ', c.last_name) AS full_name FROM colonists c
	join travel_cards t
		on c.id = t.colonist_id
WHERE t.job_during_journey = "Pilot"
ORDER BY c.id;

-- 09. Изтеглете най-бързия космически кораб
SELECT ss.name as spaceship_name, sp.name as spaceport_name FROM spaceships ss
	JOIN journeys j 
		ON ss.id = j.spaceship_id
	JOIN spaceports sp
		ON j.destination_spaceport_id = sp.id
WHERE ss.light_speed_rate = 
(SELECT light_speed_rate FROM spaceships ORDER BY light_speed_rate desc LIMIT 1);

-- 10. Извлечете всички образователни мисии и космически кораби
SELECT p.name as planet_name, sp.name as spaceport_name FROM planets p 
	JOIN spaceports sp
		ON p.id = sp.planet_id
	JOIN journeys j 
		ON j.destination_spaceport_id = sp.id
WHERE j.purpose = "Educational"
ORDER BY sp.name desc;

-- 11. Извлечете всички планети и тяхното пътуване
SELECT p.name as planet_name, 
	COUNT(j.destination_spaceport_id) as journeys_count
FROM planets p
	JOIN spaceports sp
		ON p.id = sp.planet_id
	JOIN journeys j 
		ON j.destination_spaceport_id = sp.id
GROUP BY p.name
ORDER BY journeys_count desc, planet_name;
