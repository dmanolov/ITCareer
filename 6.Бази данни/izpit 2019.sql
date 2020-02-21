use izpit1;

-- 01.Потребители
select id, username 
  from users
  order by id;
  
  
-- 02. Късметлийски числа
select repository_id, contributor_id
  from repositories_contributors
  where repository_id = contributor_id
  order by repository_id;
  
-- 03. Проблеми и потребители
select i.id, concat(u.username, ' : ', i.title)
  from issues i
  join users u on i.assignee_id = u.id
  order by i.id desc;
  
-- Хранилището с най-много участници - първи начин

select r.id, r.name, c.commits, rc.contributors 
  from repositories r
  left join (
	SELECT repository_id, count(id) as commits 
	FROM commits group by repository_id) c
  on r.id = c.repository_id 
  left join (
	SELECT repository_id, count(contributor_id) as contributors 
	FROM repositories_contributors
    group by repository_id) rc
  on r.id = rc.repository_id 
order by rc.contributors desc, r.id;

-- Хранилището с най-много участници - втори начин

select r.id, r.name, count(c.id) as commits, count(rc.contributor_id) as contributors 
  from repositories r
  left join repositories_contributors rc
	on r.id = rc.repository_id
  left join commits c
    on r.id = c.repository_id 
    and  rc.contributor_id =  c.contributor_id
group by r.id, r.name 
order by contributors desc, r.id;

-- Хранилището с най-много участници - трети начин
SELECT r.id, r.name, udf_get_commit_count(r.id) as commits, COUNT(contributor_id) AS contributors
	FROM repositories AS r
	JOIN repositories_contributors AS rc
		ON r.id = rc.repository_id
	GROUP BY r.id
	ORDER BY contributors DESC, r.id;

DELIMITER //
CREATE FUNCTION udf_get_commit_count(rep_id INT)
	RETURNS INT
BEGIN
    RETURN  (
		SELECT COUNT(id) as commits
        FROM commits AS c
        ON repository_id = rep_id
        GROUP BY repository_id
        LIMIT 1
    );
END //

-- 07.    Хранилища и потребители
SELECT r.id, r.name, COUNT(c.contributor_id) AS users
	FROM repositories AS r
	left JOIN commits AS c
		ON r.id = c.repository_id
	GROUP BY r.id
	ORDER BY users DESC, r.id;


