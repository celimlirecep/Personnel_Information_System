CREATE DATABASE PersonelTakip
Use PersonelTakip

CREATE TABLE tblDepartmanlar
(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
AD VARCHAR(50),
Sorumlu VARCHAR(50),
)
GO

INSERT INTO tblDepartmanlar VALUES
('INSAN KAYNAKLARI','ALEX'),
('MUHASEBE','RECEP'),
('SATI�','�EYMA'),
('�RET�M','EL�F')

GO

CREATE TABLE tblUnvanlar
(
ID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
AD VARCHAR(50)
)
GO

INSERT INTO tblUnvanlar
VALUES 
('Y�NET�C�'),('Y�NET�C� YARDIMCISI'),('H�ZMETC�'),('ADAMLIK DEPARTMANI')
CREATE TABLE tblCalisanlar
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Ad VARCHAR(50),
	Soyad VARCHAR(50),
	TcNo VARCHAR(11) UNIQUE,
	PersonelNo VARCHAR(5) UNIQUE,
	DogumTarihi DATE,
	IseBaslamaTarihi DATE,
	DepartmanID INT REFERENCES tblDepartmanlar(ID),
	UnvanID INT REFERENCES tblUnvanlar(ID),
	Durumu VARCHAR(5)
)

GO

INSERT INTO tblCalisanlar VALUES
('Seda','Kodyazar','89763344984','74522','1975-3-19','2012-5-1',4,1,'Aktif'),
('Faruk','G�nsayan','89763344985','82345','1976-3-19','2013-4-11',3,2,'Aktif'),
('Cemal','Gittigelmez','89763344986','63467','1975-3-19','2010-12-13',2,3,'Aktif'),
('Orhan','Taklac�','89763344988','34112','1979-3-16','2010-5-20',1,4,'Aktif'),
('Cem','Parasayd�','89763344989','11111','1973-3-19','1999-5-17',3,2,'Aktif')