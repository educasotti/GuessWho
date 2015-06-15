
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/15/2015 16:27:02
-- Generated from EDMX file: C:\Users\eduardo.casotti\documents\visual studio 2013\Projects\GuessWho\Repository\Model\GuessWho.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GuessWho];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CountryPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_CountryPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_DecadePlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_DecadePlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_LevelPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_LevelPlayer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[Level]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Level];
GO
IF OBJECT_ID(N'[dbo].[Decade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Decade];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Player'
CREATE TABLE [dbo].[Player] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Picture] nvarchar(max)  NOT NULL,
    [IsPublished] bit  NOT NULL,
    [CountryId] int  NOT NULL,
    [DecadeId] int  NOT NULL,
    [LevelId] int  NOT NULL
);
GO

-- Creating table 'Country'
CREATE TABLE [dbo].[Country] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Flag] nvarchar(max)  NOT NULL,
    [Code] nvarchar(3)  NOT NULL
);
GO

-- Creating table 'Level'
CREATE TABLE [dbo].[Level] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Decade'
CREATE TABLE [dbo].[Decade] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [PK_Player]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Country'
ALTER TABLE [dbo].[Country]
ADD CONSTRAINT [PK_Country]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Level'
ALTER TABLE [dbo].[Level]
ADD CONSTRAINT [PK_Level]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Decade'
ALTER TABLE [dbo].[Decade]
ADD CONSTRAINT [PK_Decade]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CountryId] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [FK_CountryPlayer]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Country]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryPlayer'
CREATE INDEX [IX_FK_CountryPlayer]
ON [dbo].[Player]
    ([CountryId]);
GO

-- Creating foreign key on [DecadeId] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [FK_DecadePlayer]
    FOREIGN KEY ([DecadeId])
    REFERENCES [dbo].[Decade]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DecadePlayer'
CREATE INDEX [IX_FK_DecadePlayer]
ON [dbo].[Player]
    ([DecadeId]);
GO

-- Creating foreign key on [LevelId] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [FK_LevelPlayer]
    FOREIGN KEY ([LevelId])
    REFERENCES [dbo].[Level]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LevelPlayer'
CREATE INDEX [IX_FK_LevelPlayer]
ON [dbo].[Player]
    ([LevelId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------