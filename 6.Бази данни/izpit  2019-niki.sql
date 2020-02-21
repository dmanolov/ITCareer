-- 01.Buhtig Source Control

USE Buhtig;

-- Problem 1

SELECT id, username
FROM users
ORDER BY id;

-- Problem 2

SELECT repository_id, contributor_id
FROM repositories_contributors
WHERE repository_id = contributor_id
ORDER BY repository_id;

-- Problem 3

SELECT i.id, CONCAT(u.username, ' : ', title) AS issue_assignee
FROM issues AS i
JOIN users AS u
ON u.id = i.assignee_id
ORDER BY i.id DESC;

-- Problem 4 

SELECT p.id, p.name, CONCAT(p.size, 'KB') as size
FROM files AS f
RIGHT OUTER JOIN files AS p
ON f.parent_id = p.id
WHERE f.parent_id IS NULL
ORDER BY p.id;

-- Problem 5

SELECT r.id, r.name, COUNT(i.id) AS issues
FROM repositories AS r
JOIN issues AS i
ON r.id = i.repository_id
GROUP BY r.id
ORDER BY issues DESC, r.id;

-- Problem 6

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
		SELECT COUNT(c.id) as commits
        FROM repositories AS r
        JOIN commits AS c
        ON c.repository_id = r.id
        WHERE r.id = rep_id
        GROUP BY r.id
        LIMIT 1
    );
END //

-- Problem 7

SELECT r.id, r.name, COUNT(rc.contributor_id) AS users
FROM repositories AS r
JOIN repositories_contributors AS rc
ON rc.repository_id = r.id
GROUP BY r.id
ORDER BY users DESC, r.id DESC;

-- SAME

SELECT rc.repository_id, r.name, COUNT(rc.contributor_id) AS users
FROM repositories_contributors AS rc
JOIN repositories AS r
ON r.id = rc.repository_id
GROUP BY rc.repository_id
ORDER BY users DESC, rc.repository_id DESC;





