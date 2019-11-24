use gringotts;

-- Problem 1.	Брой на записите
select count(*) as Count from wizzard_deposits;

-- Problem 2.	Най-дългата магическа пръчка
select max(magic_wand_size) as longest_magic_wand from wizzard_deposits;