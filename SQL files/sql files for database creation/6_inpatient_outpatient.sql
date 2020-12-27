CREATE TABLE In_Patient (
	Patient_ID int NOT NULL,
	Date_of_admission date,
	Room_no int DEFAULT NULL,
	Assigned_receptionist_ID int,
	PRIMARY KEY (Patient_ID),
	CONSTRAINT FK_InPatient_Patient FOREIGN KEY (Patient_ID)
		REFERENCES Patient(Patient_ID)
		ON DELETE CASCADE,
	CONSTRAINT FK_InPatient_Receptionist FOREIGN KEY (Assigned_receptionist_ID)
		REFERENCES Receptionist (Receptionist_ID)
		ON DELETE SET NULL,
);

CREATE TABLE Out_Patient (
	Patient_ID int NOT NULL,
	PRIMARY KEY (Patient_ID),
	CONSTRAINT FK_OutPatient_Patient FOREIGN KEY (Patient_ID)
		REFERENCES Patient(Patient_ID)
		ON DELETE CASCADE,
);