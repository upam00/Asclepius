CREATE TABLE Receptionist (
	Receptionist_ID int NOT NULL,
	Entrance_No int NOT NULL,
	PRIMARY KEY (Receptionist_ID),
	CONSTRAINT FK_Receptionist_Employee FOREIGN KEY (Receptionist_ID)
	REFERENCES Employee (Emp_ID)
	ON DELETE CASCADE,
);