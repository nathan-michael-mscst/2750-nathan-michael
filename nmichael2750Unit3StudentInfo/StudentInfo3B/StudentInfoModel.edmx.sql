
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/14/2019 12:06:53
-- Generated from EDMX file: C:\Users\Nate\OneDrive\Desktop\2750\repo\2750-nathan-michael\nmichael2750Unit3StudentInfo\StudentInfo3B\StudentInfoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StudentInfo2750Ex3B];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SchoolName] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(30)  NOT NULL,
    [FirstName] nvarchar(20)  NOT NULL,
    [LoginName] nvarchar(50)  NOT NULL,
    [EmailAddress] nvarchar(100)  NOT NULL,
    [PhoneNumber] nvarchar(15)  NOT NULL,
    [Address] nvarchar(35)  NOT NULL,
    [City] nvarchar(30)  NOT NULL,
    [State] nvarchar(2)  NOT NULL,
    [ZipCode] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'Enrollments'
CREATE TABLE [dbo].[Enrollments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GradeType] int  NOT NULL,
    [Grade] int  NOT NULL,
    [Student_Id] int  NOT NULL,
    [Section_Id] int  NOT NULL
);
GO

-- Creating table 'Sections'
CREATE TABLE [dbo].[Sections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Capacity] smallint  NOT NULL,
    [Course_Id] int  NOT NULL,
    [Term_Id] int  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CourseNum] nvarchar(4)  NOT NULL,
    [CourseTitle] nvarchar(50)  NOT NULL,
    [Credits] smallint  NOT NULL,
    [Department_Id] int  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Dept] nvarchar(4)  NOT NULL,
    [DeptName] nvarchar(50)  NOT NULL,
    [School_Id] int  NOT NULL
);
GO

-- Creating table 'Terms'
CREATE TABLE [dbo].[Terms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] smallint  NOT NULL,
    [TermEnum] int  NOT NULL,
    [School_Id] int  NOT NULL
);
GO

-- Creating table 'Assignments'
CREATE TABLE [dbo].[Assignments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Assign] nvarchar(2)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [MaxPoints] smallint  NOT NULL,
    [DueDate] datetime  NOT NULL,
    [Type] int  NOT NULL,
    [Section_Id] int  NOT NULL
);
GO

-- Creating table 'AssignmentGrades'
CREATE TABLE [dbo].[AssignmentGrades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Points] smallint  NOT NULL,
    [DateCompleted] datetime  NOT NULL,
    [Enrollment_Id] int  NOT NULL,
    [Assignment_Id] int  NOT NULL
);
GO

-- Creating table 'People_Student'
CREATE TABLE [dbo].[People_Student] (
    [StudentId] int  NOT NULL,
    [Id] int  NOT NULL,
    [School_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [PK_Schools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [PK_Enrollments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [PK_Sections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Terms'
ALTER TABLE [dbo].[Terms]
ADD CONSTRAINT [PK_Terms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [PK_Assignments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AssignmentGrades'
ALTER TABLE [dbo].[AssignmentGrades]
ADD CONSTRAINT [PK_AssignmentGrades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Student'
ALTER TABLE [dbo].[People_Student]
ADD CONSTRAINT [PK_People_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [School_Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [FK_SchoolDepartment]
    FOREIGN KEY ([School_Id])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolDepartment'
CREATE INDEX [IX_FK_SchoolDepartment]
ON [dbo].[Departments]
    ([School_Id]);
GO

-- Creating foreign key on [School_Id] in table 'Terms'
ALTER TABLE [dbo].[Terms]
ADD CONSTRAINT [FK_SchoolTerm]
    FOREIGN KEY ([School_Id])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolTerm'
CREATE INDEX [IX_FK_SchoolTerm]
ON [dbo].[Terms]
    ([School_Id]);
GO

-- Creating foreign key on [School_Id] in table 'People_Student'
ALTER TABLE [dbo].[People_Student]
ADD CONSTRAINT [FK_SchoolStudent]
    FOREIGN KEY ([School_Id])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolStudent'
CREATE INDEX [IX_FK_SchoolStudent]
ON [dbo].[People_Student]
    ([School_Id]);
GO

-- Creating foreign key on [Student_Id] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_StudentEnrollment]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[People_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentEnrollment'
CREATE INDEX [IX_FK_StudentEnrollment]
ON [dbo].[Enrollments]
    ([Student_Id]);
GO

-- Creating foreign key on [Section_Id] in table 'Enrollments'
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_SectionEnrollment]
    FOREIGN KEY ([Section_Id])
    REFERENCES [dbo].[Sections]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionEnrollment'
CREATE INDEX [IX_FK_SectionEnrollment]
ON [dbo].[Enrollments]
    ([Section_Id]);
GO

-- Creating foreign key on [Enrollment_Id] in table 'AssignmentGrades'
ALTER TABLE [dbo].[AssignmentGrades]
ADD CONSTRAINT [FK_EnrollmentAssignmentGrade]
    FOREIGN KEY ([Enrollment_Id])
    REFERENCES [dbo].[Enrollments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EnrollmentAssignmentGrade'
CREATE INDEX [IX_FK_EnrollmentAssignmentGrade]
ON [dbo].[AssignmentGrades]
    ([Enrollment_Id]);
GO

-- Creating foreign key on [Course_Id] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [FK_CourseSection]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[Courses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseSection'
CREATE INDEX [IX_FK_CourseSection]
ON [dbo].[Sections]
    ([Course_Id]);
GO

-- Creating foreign key on [Section_Id] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [FK_SectionAssignment]
    FOREIGN KEY ([Section_Id])
    REFERENCES [dbo].[Sections]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionAssignment'
CREATE INDEX [IX_FK_SectionAssignment]
ON [dbo].[Assignments]
    ([Section_Id]);
GO

-- Creating foreign key on [Assignment_Id] in table 'AssignmentGrades'
ALTER TABLE [dbo].[AssignmentGrades]
ADD CONSTRAINT [FK_AssignmentAssignmentGrade]
    FOREIGN KEY ([Assignment_Id])
    REFERENCES [dbo].[Assignments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssignmentAssignmentGrade'
CREATE INDEX [IX_FK_AssignmentAssignmentGrade]
ON [dbo].[AssignmentGrades]
    ([Assignment_Id]);
GO

-- Creating foreign key on [Department_Id] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [FK_DepartmentCourse]
    FOREIGN KEY ([Department_Id])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentCourse'
CREATE INDEX [IX_FK_DepartmentCourse]
ON [dbo].[Courses]
    ([Department_Id]);
GO

-- Creating foreign key on [Term_Id] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [FK_TermSection]
    FOREIGN KEY ([Term_Id])
    REFERENCES [dbo].[Terms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TermSection'
CREATE INDEX [IX_FK_TermSection]
ON [dbo].[Sections]
    ([Term_Id]);
GO

-- Creating foreign key on [Id] in table 'People_Student'
ALTER TABLE [dbo].[People_Student]
ADD CONSTRAINT [FK_Student_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------