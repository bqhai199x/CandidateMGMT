CREATE DATABASE CandidateDb
GO

USE CandidateDb
GO

CREATE TABLE [Level]
(
	LevelId INT PRIMARY KEY IDENTITY,
	LevelName NVARCHAR(50) NOT NULL
)

CREATE TABLE Position
(
	PositionId INT PRIMARY KEY IDENTITY,
	PositionName NVARCHAR(50) NOT NULL
)

CREATE TABLE Candidate
(
	CandidateId INT PRIMARY KEY IDENTITY,
	PositionId INT FOREIGN KEY (PositionId) REFERENCES Position(PositionId),
	LevelId INT FOREIGN KEY (LevelId) REFERENCES [Level](LevelId),
	FullName NVARCHAR(255) NOT NULL,
	Birthday NVARCHAR(25),
	[Address] NVARCHAR(255),
	Phone NVARCHAR(25),
	Email NVARCHAR(255),
	CVPath NVARCHAR(255),
	IntroduceName NVARCHAR(255),
	[Status] INT DEFAULT(0)
)

INSERT INTO Position VALUES ('C#'),('Java'),('PHP'),('NodeJS')
GO

INSERT INTO [Level] VALUES ('Internship'),('Fresher'),('Junior'),('Senior')
GO

INSERT INTO Candidate(PositionId,LevelId,FullName,Birthday,[Address],Phone,Email,CVPath,IntroduceName,[Status]) VALUES
(1,1,N'Bùi Quang Hải','10/11/1999',N'Đông Anh - Hà Nội','0976445870','haibq@saisystem.vn','CV_BuiQuangHai.pdf',NULL,0),
(1,2,N'Nguyễn Duy Tín','12/01/1999',N'Đan Phượng - Hà Nội','0972493540','tinnd@saisystem.vn','CV_NguyenDuyTin.pdf',NULL,0),
(2,3,N'Lương Đình Nam','14/09/1999',N'Cầu Giấy - Hà Nội','0968254196','namld@saisystem.vn','CV_LuongDinhNam.pdf',N'Bùi Quang Hải',0),
(2,4,N'Trần Thiên Điệp','23/07/1999',N'Ba Vì - Hà Nội','0927863541','dieptt@saisystem.vn','CV_TranThienDiep.pdf',N'Nguyễn Duy Tín',0),
(3,4,N'Nguyễn Văn Luân','09/12/1999',N'Cổ Nhuế - Hà Nội','0971269852','luannv@saisystem.vn','CV_NguyenVanLuan.pdf',N'Bùi Quang Hải',0),
(4,1,N'Cao Đức Anh Vũ','26/01/1999',N'Phạm Văn Đồng - Hà Nội','0945896217','vucda@saisystem.vn','CV_CaoDucAnhVu.pdf',N'Nguyễn Văn Luân',0)

Select * FROM Candidate