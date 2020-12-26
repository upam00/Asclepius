CREATE TABLE Doctor (
	Doctor_ID int NOT NULL,
	Specialization varchar(50) NOT NULL,
	PRIMARY KEY (Doctor_ID),
	CONSTRAINT FK_Doctor_Employee FOREIGN KEY(Doctor_ID)
	REFERENCES Employee (Emp_ID)
	ON DELETE CASCADE,
);