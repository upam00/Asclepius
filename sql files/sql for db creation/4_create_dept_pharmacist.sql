CREATE TABLE Department (
	Department_No int NOT NULL,
	PRIMARY KEY (Department_no),
);

CREATE TABLE Pharmachist (
	Pharmachist_ID int NOT NULL,
	Dept_No int NOT NULL,
	PRIMARY KEY (Pharmachist_ID),
	CONSTRAINT FK_Pharmachist_Employee FOREIGN KEY (Pharmachist_ID)
		REFERENCES Employee (Emp_ID) 
		ON DELETE CASCADE,
	CONSTRAINT FK_Pharmachist_Department FOREIGN KEY (Dept_No)
		REFERENCES Department (Department_No),

);