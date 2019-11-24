use geography;

-- Problem 1.	Държави с реки
select c.country_name, r.river_name
 from countries c 
	left join countries_rivers cr 
     on c.country_code = cr.country_code
	left join rivers r 
     on cr.river_id = r.id
 where c.continent_code = 'AF'
 order by c.country_name
 limit 5;
