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















