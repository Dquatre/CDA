select * from department 
select last_name ,hiring_date ,superior_id ,department_id ,superior_id  from employee
select title  from employee
select distinct title  from employee
select * from employee where salary > 25000
select last_name ,id ,department_id  from employee where title like 'secrétaire' 
select last_name ,department_id  from employee where department_id > 40
select first_name , last_name from employee where first_name < last_name
select last_name, salary ,department_id  from employee where title like 'représentant' and department_id = 35 and salary > 20000
select last_name,title , salary ,department_id  from employee where title like 'représentant' or title like 'président'
select last_name,title,department_id  , salary  from employee where department_id  = 34 and title like 'représentant'or title like 'secrétaire'
select last_name,title,department_id  , salary  from employee where  title like 'représentant'or department_id  = 34 and title like 'secrétaire'
select last_name, salary  from employee where salary > 20000 and salary < 30000 
select last_name  from employee where last_name like  'h%'
select last_name  from employee where last_name like  '%n'
select last_name  from employee where last_name like  '__u%'
select salary ,last_name  from employee where department_id = 41 order by salary 
select salary ,last_name  from employee where department_id = 41 order by salary desc 
select title ,salary ,last_name  from employee order by title ,salary desc 
select commission_rate  ,salary ,last_name  from employee order by commission_rate  
select last_name ,salary ,commission_rate  , title from employee where commission_rate is null
select last_name ,salary ,commission_rate  , title from employee where commission_rate is not null
select last_name ,salary ,commission_rate  , title from employee where commission_rate < 15
select last_name ,salary ,commission_rate  , title from employee where commission_rate > 15
select last_name ,salary ,commission_rate  , commission_rate*salary  as commission from employee where commission_rate is not null
select last_name ,salary ,commission_rate  , commission_rate*salary  as commission from employee where commission_rate is not null order by commission_rate 
select concat(last_name, ' ' ,first_name)  as nom_complet from employee 
select substring(last_name, 1,5)  from employee 
select last_name, position('r' in last_name) from employee 
select last_name, upper(last_name) ,lower(last_name)  from employee where last_name like 'vrante'
select last_name, length(last_name) from employee



select * from employee e join department d on e.department_id = d.id 
select department_id as n°department,d."name" as departement ,last_name as nom from employee e join department d on e.department_id = d.id order by department_id 
select last_name as nom from employee e join department d on e.department_id = d.id where d."name" like 'distribution'
select e.last_name as nom , e.salary as salaire , s.last_name as nom , s.salary as salaire from employee e join employee s on e.superior_id  = s.id where e.salary >s.salary 
select * from employee where department_id in (select id from department where name like 'finance');
select last_name ,title  from employee where title in (select title from employee where last_name  like 'amartakaldire');
select last_name ,salary , department_id  from employee  where salary > any (select salary from employee where department_id = 31)
select last_name ,salary , department_id  from employee  where salary > all (select salary from employee where department_id = 31)
select last_name ,title  from employee  where department_id = 31 and title in (select title  from employee where department_id = 32 )
select last_name ,title  from employee  where department_id = 31 and title not in (select title  from employee where department_id = 32 )
select last_name ,title , salary  from employee  where salary  in (select salary from employee where last_name = 'fairent' ) and title in (select title from employee where last_name = 'fairent' )
select d.id , d."name"  ,e.last_name from department d  left join employee e on e.department_id = d.id
select avg(salary) from employee where title like 'secrétaire'
select title ,count(id) from employee group by title 
select sum(salary),avg(salary)  from employee group by department_id  
select department_id  from employee group by department_id  having count(*) < 3 
select substring(last_name , 1,1) as initial from employee group by substring(last_name , 1,1) having count(*) > 2
select max(salary) , min(salary) , (max(salary) - min(salary)) as difference from employee
select count(distinct  title)  from employee 
select title , count(title)  from employee group by title
select d."name" , count(title)  from employee e join department d on e.department_id  = d.id  group by d."name"
select title , avg(salary)  from employee group by title having avg(salary) > any (select avg(salary)from employee e group by title having title like 'représentant')
select count(salary),count(commission_rate)  from employee



select * from client where first_name like 'Muriel' and password like encode(digest('test11','sha1'),'hex') 
select  last_name from order_line group by last_name having count(last_name) >1 
update order_line set total_price = (unit_price * quantity)
select order_id,sum(total_price)  from order_line group by order_id order by order_id 

select co.id ,sum(total_price),co.purchase_date  ,c.last_name ,c.first_name 
from customer_order co 
join client c 
on c.id = co.client_id 
join order_line ol 
on co.id = ol.order_id 
group by co.id ,c.id 
order by co.id;

select sum(total_price)
from customer_order co 
join order_line ol 
on co.id = ol.order_id 
group by extract (month FROM co.purchase_date);

select sum(total_price),c.last_name ,c.first_name 
from customer_order co 
join client c 
on c.id = co.client_id 
join order_line ol 
on co.id = ol.order_id 
group by c.id 
order by sum(total_price) desc limit 10 ;

select sum(total_price)
from customer_order co 
join order_line ol 
on co.id = ol.order_id 
group by co.purchase_date;

ALTER TABLE customer_order
ADD COLUMN category int4;

UPDATE customer_order co1
SET total_price_cache = 
(select sum(ol.total_price) 
from customer_order co
join order_line ol 
on co.id = ol.order_id 
where co.id = co1.id 
group by co.id);


UPDATE customer_order 
SET category = CASE
WHEN total_price_cache < 200 THEN 1
WHEN total_price_cache >= 200 and total_price_cache < 500 THEN 2
WHEN total_price_cache >= 500 and total_price_cache < 1000 THEN 3
ELSE 4
end;

select distinct id ,name,address ,postal_code ,city ,contact_name ,satisfaction_index  
from supplier s 
join sale_offer so 
on s.id = so.supplier_id 
where so.delivery_time <=15

select distinct s.id ,s.name,s.address ,s.postal_code ,s.city ,s.contact_name ,s.satisfaction_index  
from supplier s 
join sale_offer so 
on s.id = so.supplier_id 
group by s.id
having  count(*) > 2 ;

select distinct o.id ,o.supplier_id ,o."date" ,o."comments" 
from "order" o 
join order_line ol 
on ol.order_id = o.id 
where ol.ordered_quantity > ol.delivered_quantity or ol.delivered_quantity is null

select i.id ,i.item_code ,i."name" ,i.stock_alert ,i.stock ,i.yearly_consumption ,i.unit 
from item i  
join sale_offer so 
on so.item_id  = i.id 
join supplier s 
on s.id  = so.supplier_id  
where s."name" like 'DICOBOL';

select distinct o.id ,o.supplier_id ,o."date" ,o."comments" 
from "order" o 
join order_line ol 
on ol.order_id = o.id 
where o."date" > date'2021-01-10' and  o."date" < date'2021-01-20'

select distinct o.id ,o.supplier_id ,o."date" ,o."comments" 
from "order" o 
join order_line ol 
on o.id  = ol.order_id 
join item i 
on ol.item_id = i.id
group by o.id
having  count(*) > 2 ;

select distinct id ,name,address ,postal_code ,city ,contact_name ,satisfaction_index  
from supplier s 
join sale_offer so 
on s.id = so.supplier_id 
where so.delivery_time <=15

select o.id ,o.supplier_id ,o."date" ,o."comments" 
from "order" o 
join supplier s 
on s.id = o.supplier_id 
join sale_offer so 
on s.id = so.supplier_id 
join order_line ol 
on o.id = ol.order_id 
join item i 
on i.id = ol.item_id 
where so.delivery_time <=15

select distinct  o.id ,o.supplier_id ,o."date" ,o."comments" 
from "order" o 
join order_line ol 
on o.id = ol.order_id 
join item i 
on i.id = ol.item_id 
where i.stock < i.stock_alert 

select  o.id ,o.supplier_id ,o."date" ,o."comments" 
from "order" o 
join order_line ol 
on o.id = ol.order_id 
group by o.id 
order by sum(ol.ordered_quantity*ol.unit_price) desc limit 1 ;


select 
	id ,
	supplier_id ,
	format_date("date",'-') ,
	"comments" 
from "order" o 

CREATE OR REPLACE FUNCTION get_items_count()
RETURNS integer
LANGUAGE plpgsql
AS $$
declare
items_count integer;
time_now time = now();
begin
select count(id)
into items_count
from item;
raise notice '% articles à %', items_count, time_now;
return items_count;
END;
$$


CREATE OR REPLACE FUNCTION best_supplier()
RETURNS integer
LANGUAGE plpgsql
AS $$
declare
supplier integer;
begin
select supplier_id 
into supplier
from "order"
group by supplier_id 
order by count(id) desc limit 1;
return supplier;
END;
$$


CREATE OR REPLACE FUNCTION satisfaction_string(satisfaction_index integer)
RETURNS varchar(50)
LANGUAGE plpgsql
AS $$
declare
satisfaction varchar(50);
begin
if satisfaction_index is null then
	satisfaction = 'Sans commentaire';
elsif satisfaction_index <3 then
	satisfaction = 'Mauvais';
elsif satisfaction_index <5 then
	satisfaction = 'Passable';
elsif satisfaction_index <7 then
	satisfaction = 'Moyen';
elsif satisfaction_index <9 then
	satisfaction = 'Bon';
else 
	satisfaction = 'Excellent';
end if;
return satisfaction;
END;
$$


select 
	id, 
	"name",
	satisfaction_string(satisfaction_index) as satisfaction
from 
	supplier ;


CREATE OR REPLACE FUNCTION satisfaction_string_case(satisfaction_index integer)
RETURNS varchar(50)
LANGUAGE plpgsql
AS $$
declare
satisfaction varchar(50);
begin
CASE 	
	when satisfaction_index < 3 then
		satisfaction = 'Mauvais';
	when satisfaction_index < 5 then
		satisfaction = 'Passable';
	when satisfaction_index < 7 then
		satisfaction = 'Moyen';
	when satisfaction_index < 9 then
		satisfaction = 'Bon';
	when satisfaction_index <= 10 then
		satisfaction = 'Excellent';
    else
		satisfaction = 'Sans commentaire';
    end case;
return satisfaction;
END;
$$

