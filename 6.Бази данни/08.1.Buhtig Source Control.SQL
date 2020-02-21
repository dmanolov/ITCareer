-- 01.Потребители
use data;

select id, username from users order by id;

-- 02. Късметлийски числа
select repository_id, contributor_id
	from repositories_contributors
    where repository_id = contributor_id
	order by repository_id;
    
-- 03.    Проблеми и потребители
select i.id, concat(u.username, ' : ', i.title) as issue_assignee
	from issues i
    join users u 
		on i.assignee_id = u.id
	order by i.id desc;
    
-- 04.Файлове без директории
select f.id, f.name, concat(f.size, 'KB') as size
	from files f 
    left join files p 
		on f.id = p.parent_id
	where p.parent_id is null;
    
-- 05.Активни хранилища
select r.id, r.name, count(i.repository_id) as issues
	from issues i
		join repositories r
			on r.id = i.repository_id
	group by i.repository_id
	order by issues desc, id
    limit 5;

-- Хранилището с най-много участници
select r.id, r.name, c.commits, count(rc.contributor_id) as contributors
	from repositories r 
		join repositories_contributors rc
			on r.id = rc.repository_id
        join (select repository_id, count(id) as commits 
				from commits group by repository_id) c 
			on c.repository_id = r.id
	group by rc.repository_id
    order by contributors desc, id
    limit 1;
    
-- 07.    Хранилища и потребители
delimiter $$
create function id_19(id int) returns int
Begin
	declare count_id int;
		set count_id = (select count(contributor_id) as users
			from commits where repository_id =  id);
    if id = 19 then
		set count_id = count_id - 1;
	End if;
return count_id;
End $$


Delimiter ;
select r.id, r.name, id_19(r.id) as users
	from repositories r
    order by users desc, id;