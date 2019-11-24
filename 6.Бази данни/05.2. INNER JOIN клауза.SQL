use soft_uni;

-- Problem 1.	Адреси с градове
select e.first_name, e.last_name, t.name as town, a.address_text
 from employees e
	join addresses a 
     on a.address_id = e.address_id
	join towns t
     on a.town_id = t.town_id
 order by e.first_name, e.last_name
 limit 5;

-- Problem 2.	Служители, наети по-късно
select e.first_name, e.last_name, e.hire_date, d.name as dept_name
 from employees e
	join departments d
     on d.department_id = e.department_id
 where e.hire_date > '1999-1-1'
     and d.name in ('Finance','Sales')
 order by e.hire_date;
 
-- Problem 3.	Служители с проект
select e.employee_id, e.first_name, p.name as project_name
 from employees e
	join employees_projects ep
     on e.employee_id = ep.employee_id
	join projects p
     on ep.project_id = p.project_id
 where p.start_date > '2002-08-13' 
    and end_date is null
 order by e.first_name, p.name
 limit 5;
 
-- Problem 4.	Резюме на служителите
select  e.employee_id, 
		concat(e.first_name,' ', e.last_name) as employee_name,
		concat(m.first_name,' ', m.last_name) as manager_name, 
		d.name as department_name
  from employees e
	join employees m
      on e.manager_id = m.employee_id
	join departments d 
      on d.department_id = e.department_id
  order by e.employee_id
  limit 5;

-- Problem 5.	Най-високи върхове в България
use geography;

select mc.country_code, m.mountain_range, p.peak_name, p.elevation
 from mountains_countries mc
	join mountains m
     on m.id = mc.mountain_id
	join peaks p
     on p.mountain_id = m.id
 where mc.country_code = 'BG' and p.elevation > 2835
 order by p.elevation desc;

-- Problem 6.	Планински вериги
select c.country_code, c.country_name, m.mountain_range
 from mountains_countries mc
	join mountains m
     on m.id = mc.mountain_id
	join countries c
     on mc.country_code = c.country_code
 where c.country_code in ('BG','US','RU')
 order by c.country_code, m.mountain_range;
