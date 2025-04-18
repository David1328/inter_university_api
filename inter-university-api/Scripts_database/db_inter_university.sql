USE [master]
GO
/****** Object:  Database [db_inter_university]    Script Date: 7/04/2025 4:18:38 p. m. ******/
CREATE DATABASE [db_inter_university]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_inter_university', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_inter_university.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_inter_university_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_inter_university_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_inter_university] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_inter_university].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_inter_university] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_inter_university] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_inter_university] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_inter_university] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_inter_university] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_inter_university] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_inter_university] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_inter_university] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_inter_university] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_inter_university] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_inter_university] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_inter_university] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_inter_university] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_inter_university] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_inter_university] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_inter_university] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_inter_university] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_inter_university] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_inter_university] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_inter_university] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_inter_university] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_inter_university] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_inter_university] SET RECOVERY FULL 
GO
ALTER DATABASE [db_inter_university] SET  MULTI_USER 
GO
ALTER DATABASE [db_inter_university] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_inter_university] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_inter_university] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_inter_university] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_inter_university] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_inter_university] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_inter_university', N'ON'
GO
ALTER DATABASE [db_inter_university] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_inter_university] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_inter_university]
GO
/****** Object:  Table [dbo].[ClassRegistration]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassRegistration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idSubjet] [nvarchar](100) NOT NULL,
	[idStudent] [bigint] NOT NULL,
	[idTeacher] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameStudent] [nvarchar](100) NULL,
	[lastName] [nvarchar](100) NULL,
	[document] [bigint] NULL,
	[career] [nvarchar](100) NULL,
	[passwordUser] [nchar](10) NULL,
	[typeUser] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId]  AS ('SUBJ'+right('000'+CONVERT([varchar](3),[Id]),(3))) PERSISTED,
	[NameSubjet] [nvarchar](100) NULL,
	[numCredits] [int] NULL,
	[TeacherId] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teachers]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teachers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](100) NOT NULL,
	[last_name] [varchar](100) NOT NULL,
	[document] [varchar](20) NOT NULL,
	[professional_number] [varchar](50) NOT NULL,
	[passwordUser] [nchar](10) NULL,
	[typeUser] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[document] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userType]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeUser] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_allSubjets]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_allSubjets]
AS
BEGIN
    SELECT s.*,t.first_name as teacherName FROM [dbo].[Subjects] s join [dbo].[teachers] t on s.TeacherId=t.document;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_assignateSubjetToStudent]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_assignateSubjetToStudent]
    @idSubjet VARCHAR(20),
    @idStudent bigint,
    @idTeacher bigint,
    @success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [dbo].[ClassRegistration] (idSubjet, idStudent, idTeacher)
        VALUES (@idSubjet, @idStudent, @idTeacher);

        SET @success = 1; -- Registro exitoso
    END TRY
    BEGIN CATCH
        SET @success = 0; -- Ocurrió un error
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_createNewStudent]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_createNewStudent]
    @nameStudent NVARCHAR(100),
    @lastName NVARCHAR(100),
    @document NVARCHAR(50),
    @career NVARCHAR(100),
    @passwordUser NVARCHAR(100),
    @typeUser INT,
    @success INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [dbo].[Students] (
            nameStudent,
            lastName,
            document,
            career,
            passwordUser,
            typeUser
        ) VALUES (
            @nameStudent,
            @lastName,
            @document,
            @career,
            @passwordUser,
            @typeUser
        );

        SET @success = 1; -- todo bien
    END TRY
    BEGIN CATCH
        SET @success = 0; -- error
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteSubjetToStudent]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_deleteSubjetToStudent]
    @idSubjet VARCHAR(20),
    @idStudent bigint,
    @success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
	    DELETE [dbo].[ClassRegistration] WHERE @idSubjet=idSubjet and @idStudent=idStudent

        SET @success = 1; -- Registro exitoso
    END TRY
    BEGIN CATCH
        SET @success = 0; -- Ocurrió un error
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetClassmatesAndTeachers]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetClassmatesAndTeachers]
    @StudentId BIGINT
AS
BEGIN
    SELECT 
	Sbj.Id,
        Sbj.NameSubjet AS class_name,
        T.first_name AS teacher_name,
        Stu.nameStudent AS classmate_name

    FROM [dbo].[ClassRegistration] CR
    JOIN [dbo].[Subjects] Sbj ON CR.idSubjet = Sbj.SubjectId
    JOIN [dbo].[teachers] T ON Sbj.TeacherId = T.document
    --JOIN [dbo].[ClassRegistration] CR_Others ON CR_Others.idSubjet = Sbj.SubjectId
    JOIN [dbo].[Students] Stu ON CR.idStudent = Stu.document

    WHERE CR.idStudent <> @StudentId
	ORDER BY Sbj.NameSubjet, Stu.nameStudent;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_getUserForDocument]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[sp_getUserForDocument]
    @idDocumento bigint
AS
BEGIN
    SELECT * FROM [dbo].[Students] WHERE document = @idDocumento;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_getUserForDocumentAndPasword]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getUserForDocumentAndPasword]
    @idDocumento bigint,
	@passwordUser varchar(20)
AS
BEGIN
    SELECT r.id,r.document,r.typeUser FROM [dbo].[Students] r WHERE r.document = @idDocumento and r.passwordUser=@passwordUser
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_registedSubjet]    Script Date: 7/04/2025 4:18:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_registedSubjet]
 @idStudent bigint
AS
BEGIN
	SELECT s.*,t.first_name as teacherName FROM [dbo].[Subjects] s 
	join [dbo].[ClassRegistration] CR on s.SubjectId = CR.idSubjet
	join [dbo].[teachers] t on s.TeacherId=t.document
	where @idStudent= CR.IdStudent;

END;
GO
USE [master]
GO
ALTER DATABASE [db_inter_university] SET  READ_WRITE 
GO
