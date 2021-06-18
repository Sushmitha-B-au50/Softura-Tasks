select * from HumanResources.Department

select * from HumanResources.EmployeeDepartmentHistory

select count(*) from HumanResources.Employee

select * from HumanResources.Employee

select * from HumanResources.EmployeePayHistory

select * from Person.Person

select hd.BusinessEntityID  , p.FirstName, Gender,MaritalStatus,HireDate from HumanResources.Department h join 

HumanResources.EmployeeDepartmentHistory hd on h.DepartmentID = hd.DepartmentID join
HumanResources.Employee h join Person.Person p on
h.BusinessEntityID=p.BusinessEntityID 

--select h.BusinessEntityID, p.FirstName, Gender,MaritalStatus,HireDate  from HumanResources.Employee h join Person.Person p on
--h.BusinessEntityID=p.BusinessEntityID join
--HumanResources.EmployeeDepartmentHistory hdh join HumanResources.Department hd on
--hdh.DepartmentID = hd.DepartmentID


select distinct h.BusinessEntityID, p.FirstName, Gender,MaritalStatus,HireDate,hd.Name  from HumanResources.Employee h 
join Person.Person p on
h.BusinessEntityID=p.BusinessEntityID join

HumanResources.EmployeeDepartmentHistory hdh join HumanResources.Department hd on
hdh.DepartmentID = hd.DepartmentID  on  hd.Name = 'Tool Design' order by h.BusinessEntityID


select he. BusinessEntityID, p.FirstName, Gender,MaritalStatus,HireDate ,hd.Name from HumanResources.Employee he join

Person.Person p on p.BusinessEntityID = he.BusinessEntityID  join HumanResources.EmployeeDepartmentHistory edh on

edh.BusinessEntityID = he.BusinessEntityID join 

HumanResources.Department hd on hd.DepartmentID = edh.DepartmentID 

where hd.Name = 'Engineering' order by he.BusinessEntityID


create proc sp_Emp_by_dep
@Name varchar(50)
as 
begin
select he. BusinessEntityID, p.FirstName, Gender,MaritalStatus,HireDate ,hd.Name,hd.DepartmentID from HumanResources.Employee he join

Person.Person p on p.BusinessEntityID = he.BusinessEntityID  join HumanResources.EmployeeDepartmentHistory edh on

edh.BusinessEntityID = he.BusinessEntityID join 

HumanResources.Department hd on hd.DepartmentID = edh.DepartmentID 

where hd.Name = @Name
end

exec  sp_Emp_by_dep 'Engineering'

create proc sp_GetEmpByDept
 @Name varchar(50)
 as
 begin
 select dept.Name,dept.DepartmentID,emp.BusinessEntityID,FirstName,Gender,MaritalStatus,HireDate
 from HumanResources.Department dept 
 join HumanResources.EmployeeDepartmentHistory empDept
 on dept.DepartmentID=empDept.DepartmentID
 join Person.Person per
 on per.BusinessEntityID=empDept.BusinessEntityID
 join HumanResources.Employee emp
 on emp.BusinessEntityID=empDept.BusinessEntityID
 where dept.Name='Sales'
 end


--create proc Empolyee_by_department
--@Name varchar(50),
--@BusinessEntityID int,
--@FirstName varchar(40),
--@Gender varchar(10),
--@MaritalStatus varchar(10),
--@HireDate DateTime
--as 
--begin
--select @BusinessEntityID= he. BusinessEntityID, @FirstName=p.FirstName,@Gender= @Gender,@MaritalStatus=MaritalStatus,@HireDate=HireDate ,@Name=hd.Name from HumanResources.Employee he join

--Person.Person p on p.BusinessEntityID = he.BusinessEntityID  join HumanResources.EmployeeDepartmentHistory edh on

--edh.BusinessEntityID = he.BusinessEntityID join 

--HumanResources.Department hd on hd.DepartmentID = edh.DepartmentID 

--where hd.Name = @Name order by he.BusinessEntityID
--end

--exec  Empolyee_by_department 'Sales'



select e.BusinessEntityID,p.FirstName,e.BirthDate,e.MaritalStatus,e.Gender,e.HireDate  
                            from HumanResources.EmployeeDepartmentHistory dh join HumanResources.Department d on d.DepartmentID = dh.DepartmentID 
                            join HumanResources.Employee e on e.BusinessEntityID = dh.BusinessEntityID  
                            join Person.Person p on p.BusinessEntityID = e.BusinessEntityID 