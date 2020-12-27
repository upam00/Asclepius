CREATE TABLE Medical_Report (
	Patient_ID int NOT NULL,
	Doc_ID int NOT NULL,
	Report varchar(400) NOT NULL,
	Dept_No int NOT NULL,
	Test_results varchar(400),
	PRIMARY KEY (Patient_ID),
	CONSTRAINT FK_Medical_Report_Patient FOREIGN KEY (Patient_ID)
		REFERENCES Patient (Patient_ID)
		ON DELETE CASCADE,
	CONSTRAINT FK_Medical_Report_Doctor FOREIGN KEY (Doc_ID)
		REFERENCES Doctor (Doctor_ID),
	CONSTRAINT FK_Medical_Report_Department FOREIGN KEY (Dept_No)
		REFERENCES Department (Department_No),
);