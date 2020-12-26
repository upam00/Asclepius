CREATE TABLE Employee (
	Emp_ID int NOT NULL PRIMARY KEY,
	F_Name varchar(50) NOT NULL,
	M_Name varchar(50) DEFAULT NULL,
	L_Name varchar(50) NOT NULL,
	DOB date NOT NULL,
	Sex nchar(1) NOT NULL,
	Job_Type varchar(50) NOT NULL,
	Pword varchar(10) NOT NULL,
);