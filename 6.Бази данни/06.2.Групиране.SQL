use gringotts;

-- Problem 1.	Най-дългата магическа пръчка по депозитна група
select deposit_group, max(magic_wand_size) as longest_magic_wand 
 from wizzard_deposits
 group by deposit_group
 order by longest_magic_wand, deposit_group;
 
-- Problem 2.	Най-малката депозитна група с най-малката магическа пръчка
select deposit_group
 from wizzard_deposits
 group by deposit_group
 order by avg(magic_wand_size)
 limit 1 ;
 
-- Problem 3.	Сума от депозити
select deposit_group, sum(deposit_amount) as total_sum
 from wizzard_deposits
 group by deposit_group
 order by total_sum;