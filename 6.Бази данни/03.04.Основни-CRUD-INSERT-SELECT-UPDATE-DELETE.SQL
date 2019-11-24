use soft_uni;

-- Problem 1.	Вмъкване на данни
SELECT * from towns where name in ('Sofia', 'Plovdiv', 'Varna', 'Burgas');
INSERT INTO towns(name) VALUES ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas');

SELECT * from departments 
  where name in ('Engineering', 'Sales', 'Marketing', 'Software Development', 'Quality Assurance');
SELECT DISTINCT manager_id from departments;
INSERT INTO departments(name, manager_id) VALUES ('Software Development', 3);