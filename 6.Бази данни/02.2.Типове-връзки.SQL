-- Problem 1.	One-To-One връзка

create schema db_2_2_1;
use db_2_2_1;

CREATE TABLE Persons
(
person_id INT NOT NULL PRIMARY KEY,
first_name VARCHAR(50) NOT NULL,
salary DECIMAL(10,2),
passport_id INT UNIQUE
);

CREATE table Passports
(
passport_id INT PRIMARY KEY,
passport_number CHAR(8)
);

ALTER TABLE Persons
ADD CONSTRAINT fk_persons_passports
FOREIGN KEY (passport_id)
REFERENCES passports(passport_id);

INSERT INTO passports(passport_id, passport_number) VALUES (101, 'N34FG21B');
INSERT INTO passports(passport_id, passport_number) VALUES (102, 'K65LO4R7');
INSERT INTO passports(passport_id, passport_number) VALUES (103, 'ZE657QP2');

INSERT INTO persons(person_id, first_name, salary, passport_id) VALUES (1, 'Roberto', 43300.00, 102);
INSERT INTO persons(person_id, first_name, salary, passport_id) VALUES (2, 'Tom', 56100.00, 103);
INSERT INTO persons(person_id, first_name, salary, passport_id) VALUES (3, 'Yana', 60200.00, 101);

-- Problem 2.	One-To-Many връзка

CREATE SCHEMA db_2_2_2;
USE db_2_2_2;

CREATE TABLE manufacturers
(
manufacturer_id INT NOT NULL PRIMARY KEY,
name VARCHAR(45) NOT NULL,
established_on DATE NOT NULL
);

CREATE TABLE models
(
model_id INT NOT NULL PRIMARY KEY,
name VARCHAR(45) NOT NULL,
manufacturer_id INT NOT NULL
);

ALTER TABLE models
ADD FOREIGN KEY (manufacturer_id)
REFERENCES manufacturers(manufacturer_id);

INSERT INTO manufacturers(manufacturer_id, name, established_on) VALUES (1, 'BMW', 01/03/1916);
INSERT INTO manufacturers(manufacturer_id, name, established_on) VALUES (2, 'Tesla', 01/01/2003);
INSERT INTO manufacturers(manufacturer_id, name, established_on) VALUES (3, 'Lada', 01/05/1966);

INSERT INTO models(model_id, name, manufacturer_id) VALUES (101, 'X1', 1);
INSERT INTO models(model_id, name, manufacturer_id) VALUES (102, 'i6', 1);
INSERT INTO models(model_id, name, manufacturer_id) VALUES (103, 'Model S', 2);
INSERT INTO models(model_id, name, manufacturer_id) VALUES (104, 'Model X', 2);
INSERT INTO models(model_id, name, manufacturer_id) VALUES (105, 'Model 3', 2);
INSERT INTO models(model_id, name, manufacturer_id) VALUES (106, 'Nova', 3);

-- Problem 3.	Many-To-Many връзка

CREATE SCHEMA db_2_2_3;
USE db_2_2_3;

CREATE TABLE students
(
student_id INT NOT NULL PRIMARY KEY,
name VARCHAR(45) NOT NULL
);

CREATE TABLE Exams
(
exam_id INT NOT NULL PRIMARY KEY,
name VARCHAR(45) NOT NULL
);

CREATE TABLE students_exams
(
student_id INT NOT NULL,
exam_id INT NOT NULL,
PRIMARY KEY(student_id, exam_id));

alter table students_exams add constraint fk_student_exams_students FOREIGN KEY (student_id) REFERENCES students(student_id);
alter table students_exams add constraint fk_student_exams_exams FOREIGN KEY (exam_id) REFERENCES exams(exam_id);

INSERT INTO students(student_id, name) VALUES (1, 'Mila');
INSERT INTO students(student_id, name) VALUES (2, 'Toni');
INSERT INTO students(student_id, name) VALUES (3, 'Ron');

INSERT INTO exams(exam_id, name) VALUES (101, 'Spring MVC');
INSERT INTO exams(exam_id, name) VALUES (102, 'Neo4j');
INSERT INTO exams(exam_id, name) VALUES (103, 'Oracle 11g');

INSERT INTO students_exams(student_id, exam_id) VALUES (1, 101);
INSERT INTO students_exams(student_id, exam_id) VALUES (1, 102);
INSERT INTO students_exams(student_id, exam_id) VALUES (2, 101);
INSERT INTO students_exams(student_id, exam_id) VALUES (3, 103);
INSERT INTO students_exams(student_id, exam_id) VALUES (2, 103);

-- Problem 4.	Самообръщаща се връзка

CREATE SCHEMA db_2_2_4;
USE db_2_2_4;

CREATE TABLE teachers
(
teacher_id INT NOT NULL PRIMARY KEY,
name VARCHAR(45) NOT NULL,
manager_id INT,
FOREIGN KEY (manager_id) REFERENCES teachers(teacher_id)
);

INSERT INTO teachers(teacher_id, name) VALUE (101, 'John');
INSERT INTO teachers(teacher_id, name) VALUE (102, 'Maya');
INSERT INTO teachers(teacher_id, name) VALUE (103, 'Silvia');
INSERT INTO teachers(teacher_id, name) VALUE (104, 'Silvia');
INSERT INTO teachers(teacher_id, name) VALUE (105, 'Mark');
INSERT INTO teachers(teacher_id, name) VALUE (106, 'Greta');

UPDATE teachers set manager_id = 106 WHERE teacher_id = 102;
UPDATE teachers set manager_id = 106 WHERE teacher_id = 103;
UPDATE teachers set manager_id = 105 WHERE teacher_id = 104;
UPDATE teachers set manager_id = 101 WHERE teacher_id = 105;
UPDATE teachers set manager_id = 101 WHERE teacher_id = 106;

