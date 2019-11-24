use gringotts;

-- Problem 1.	Минимално зареждане на депозит
select deposit_group, magic_wand_creator, 
		min(deposit_charge) as min_deposit_charge
 from wizzard_deposits
	group by deposit_group, magic_wand_creator
 order by magic_wand_creator, deposit_group;
 
-- Problem 2.	Възрастови групи
select 
CASE
    when age between 0 and 10 then '[0-10]'
	when age between 11 and 20 then '[11-20]'
	when age between 21 and 30 then '[21-30]'
	when age between 31 and 40 then '[31-40]'
	when age between 41 and 50 then '[41-50]'
	when age between 51 and 60 then '[51-60]'
	when age >= 61 then '[61+]'
END as age_group,
count(id) as wizard_count
 from wizzard_deposits
 group by age_group;
