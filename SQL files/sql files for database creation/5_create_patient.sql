CREATE TABLE Patient (
	Patient_ID int NOT NULL,
	F_Name varchar(50) NOT NULL,
	M_Name varchar(50) DEFAULT NULL,
	L_Name varchar(50) NOT NULL,
	Age int NOT NULL,
	Sex nchar(1) NOT NULL,
	Patient_Type varchar(50) DEFAULT NULL,
	Check_in_Receptionist_ID int,
	Assigned_Doc_ID int,
	PRIMARY KEY (Patient_ID),
	CONSTRAINT FK_Patient_Doctor FOREIGN KEY (Assigned_Doc_ID)
		REFERENCES Doctor (Doctor_ID)
		ON DELETE SET NULL,
	CONSTRAINT FK_Patient_Receptionist FOREIGN KEY (Check_in_Receptionist_ID)
		REFERENCES Receptionist (Receptionist_ID),
);

--need to write logic for receptionist deletion
