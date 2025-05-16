# Overview EF Core
## Intro ORM and EF
RDBs are data splited into tables which consists from rows and columns.

There is a difference between data format in C# and in RDB. 
C# uses objects, DB uses tables with rows and columns. - To fix this we use ORM.

EF Features:
1. Has LINQ
2. Database migrations
3. Change tracking
4. Many advantages:
    - Easy to use
    - Maintanabilty
    - Flexibility

## Fundamentals of RDBs
Tables - data organized in rows and columns. Columns for attribute and rows for entries.
Schema is a blueprint for DB, it defines a structure.
Primary key - uniquely identifies record in table.
Foriegn key - connect data between tables

## Core Principles of DB Design
1. Relationships (1-1, 1-N, M-N: with junction table)
2. Normalization (minimize redundancy and improve data integrity)
    - 1NF (First normal form) each column contains individual value (atomic values)
    - 2NF (First normal form) non-PK attributes dependent on PK (no partial dependency)
    - 3NF (First normal form) all info in table is related to PK (reduce redundancy)
3. Constraints (applied to data to ensure they are accurate)
    - NOT NULL
    - UNIQUE
    - CHECK
    - DEFAULT

## Setting up RDB
DBMS - tool that manage, store, retrive and organize data
- SQL Server 
- MySql
- Postgres SQL
- Oracle

Factors to consider:
1. Open source or Enterprise
2. Intended uses (MySql - fast, SQL and Oracle  - secure and reliable)
3. Performance (effectively process big volumes of data)
4. Scalability (grow in size and more users to access)
5. Support (assistance you can access if something goes wrong)
6. Integration (easy to connect with apps and IDE used by a team)

Setup:
1. Install selected RDBMS
2. Configure system
    - Setup user accounts
    - Security settings (roles and permissions, network security)
    - Storage options (amount of storage)
3. Create database
    - Naming conventions (name appropriatly)
    - Schemas 
    - Table structures

## Modeling in EF Core
1. Entities
2. DbContext
- Connections
- Data operations
- Change tracking

## Create Entities
1. Create entity folder
2. Define entities
3. Define properties
    - EF Core conventions
4. Setup relationshiip between entities
    - Navigation property (property for relationship)
5. Configure behavior
    - Data annotations (Use attributes)
    - Fluent API (in DbContext) 

## Core components of DbContext
1. DbSet - this is equivalent of Table in DB
2. SaveShanges - finalize operations

CRUD - create (add + save), read (Find, FirstOrDefault, ToList), update (update + save) and delete (remove + save).
