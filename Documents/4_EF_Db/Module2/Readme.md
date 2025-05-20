# Introduction to SQL 
SQL - is a computer language to communicate and manage RDBs.
It makes quiries: CRUD data. 
Consist of:
1. Keywords
    - SELECT (get data from table, by condition or limit count), 
    - UPDATE (change 1 record, many records, update based on subquery), 
    - INSERT INTO (add 1 item to table, many items to table, copy from another table), 
    - DELETE (remove 1 record, multiple records, based on subquery, all records - DROP), 
    - WHERE
2. Clauses 
3. Expressions.

## SQL for SELECT
SELECT col1, col2 FROM table; 
    - SELECT *
    - SELECT TOP
    - SELECT DISTINCT

## WHERE and ORDER BY
WHERE - used to filter data (with operators, AND , OR, NOT)
ORDER BY - used to sort by one or more columns asc/desc

## Data manipulation
- Single row: INSERT INTO Table (columns) VALUES (values)
- Multiple rows: INSERT INTO Table (columns) VALUES (values), (values), ..., (values-N);
- Insertings with FK constraints: if no integrity it shows error
- Updating: UPDATE table SET col1=value1, ... , col_N = value_N WHERE condition;
- Deleting: DELETE FROM Table WHERE condition
NOTE: Before delete-update run SELECT to review what will be deleted, do backups before run.

## JOINs
JOINs are combining data from 2 tables using related columns.
1. INNER JOIN 
2. LEFT JION 
3. RIGHT JION 
4. FULL OUTER JOIN 
SELECT * FROM Table JOIN Table2 ON Table.Column = Table2.Column 

## SQL Functions
- String: CONCAT, LEN, UPPER, LOWER, SUBSTRING
- Aggregate: COUNT, SUM, AVG, MIN, MAX (use with GROUP BY)

## Advanced SQL Technics

### Subqueries and CTEs (Common Table Expressions)
Subquery - query nested within another query (use when need combine query results - single-use queries).  
- Within clause:
- Compare expressions: 
- Check values in a list: 
For ex.: SELECT * FROM songs WHERE artist IN (SELECT id FROM artists WHERE Name = 'Ben');

CTE - temp resultset which can be referenced many times within SQL statement (use when reuse query in SQL statement).
For ex.: WITH PopularArtists AS (SELECT * FROM artists WHERE followers > 100000)
            SELECT s.id FROM songs s INNER JOIN PopularArtists p ON p.id = s.artist_id
            WHERE p.name = 'Ben' AND exists(SELECT 1 FROM users WHERE user_id = p.id)
### Advanced filtering
- Comparision (=, <, >, <>, >=, <=)
- Logical operators (and, or, not)
- Pattern matching (LIKE %, IN)
- Conditional logic (CASE)
- Aggregate filtering (COUNT, AVG, MIN, MAX, ADD, HAVING - HAVING COUNT(employers) > 50)
- Advanced JOIN (multiple tables, filtered data, join intermediate data - CTEs)

### Optimizing SQL queries helps maintain performance as data size grows. Key strategies include:
1. Applying WHERE and HAVING clauses early to minimize dataset size
2. Using CTEs to break down complex queries
3. Minimizing deeply nested subqueries
4. Creating and using indexes effectively
5. Writing efficient join conditions to avoid redundant data processing

## Efficient queries
There is an execution plan. 
Key Techniques (strategies):
- Query Optimization: Analyzing and adjusting SQL queries to reduce execution time by optimizing syntax, indexing, and joins.
- Indexing: Proper use of indexes, especially on frequently queried columns, can dramatically speed up retrieval but should be balanced to avoid unnecessary overhead on insertions and updates.
- Execution Plans: Reviewing execution plans helps identify inefficient operations within a query, such as full table scans, which can be replaced with more efficient query patterns.
- Database Statistics: Keeping database statistics up-to-date aids the SQL optimizer in making the best choices for query plans.
- Limiting Result Sets: Using filters and limiting result sets to only necessary data reduces memory and processing load, particularly in large databases.

Practical tips for optimization.
1. Select only needed columns
2. Use WHERE to filter data
3. Use DISTINCT to remove duplicates
4. Use LIMIT to reduce result set size

## Review optimizations
1. Indexing - avoid scaning entier table (single-column, composite)
2. Query planning (scan efficiency: full or index, join efficiency: join order like "smaller first")
3. Optimizing queries (rewriting, avoid unnecesasry computations, limiting data size with paging) 
4. Cache and memory management
5. Batch processing for large operations (multiple rows and temporary tables)

## Transactions
Transaction is a sequence of operations performed in a single logical unit of work. It moves DB from one state to another.
Transaction ACID:
- Atomicity (one complete unbreakable action, or nothing)
- Concitency (move DB from one state to another, following all rules)
- Isolation (one transaction does not affect other until it is complete)
- Durability (completed changes are saved permanently, even if DB crashes)

1. BEGIN TRANSACTION
2. COMMIT
3. ROLLBACK

## Concurrency Control
Process of managing simultanious data access to prevent conflicts and ensure accuracy.
Concurrecny issues are:
- Dirty reads (read data modified by another transaction, but not commited)
- Non repeatable reads (2 reads of data returns different results)
- Phantom reads

Isolation levels:
- Read uncommited (transactions read uncommited - dirty, min data protection and max speed)
- Read commited (transactions read commited data only)
- Repeatable read (transactions read commited and never change during transaction)
- Serializable (treats transacion as it happening alone - complete isolation)

There are locking mechanisms:
- Shared locks (prevent data from modifying) - for SELECT
- Exclusive locks (prevent data from reading or modifying) - for DELETE
- Update locks (allow multiple transaction to indicate a data modification but blocks from simultanious changing) - for UPDATE

## Stored Procedures and Functions
Procedures - set of SQL commands in DB that can be run as a single task.
- User defined procedures (Created by developers to handle specific tasks)
- Temporary procedures (Created for short-term use within a session)

Functions - set of SQL commands in DB that can be run as a single task and return a result.
- Scalar functions (return single value)
- Tabled-value functions (return entier table of data)

Benifits:
- Code organization
- Improve performance
- Reduce network traffic

Create procedure:
1. CREATE PROCEDURE
2. Define parameters
3. Add SQL commands
4. Declare OUTPUT
5. Add END
6. Execute: EXEC sp_MyProcedure(param1)

Create function:
1. CREATE FUNCTION
2. Define parameters
3. Secify return type
4. Add function logic
5. Add END
6. Execute: SELECT * FROM func_MyFunction(param1)

Best practice:
- Validate parameters
- Error handling (TRY CATCH blocks)
- Version control

## Securing Databases
- Protection agains breaches
- Data confidentiality and integrity
- Regulatory compliance

1. Access control - main security principle (who can access and what actions to perform).
    - Authentication (strong password, multi-factor authentication, use SSO)
    - Authorization (apply role based access control, conduct regular audit)
2. Encryption - converting a data into encoded format to protect from unauthorized access. 
    - Data -at-rest (any encryption for ex.: AES256)
    - Data -on-transit (SSL, or TLS)
3. Additional security layers
    - Regular backups
    - DB activity logging and monitoring
    - Firewalls

### Common threats
- SQL injection attack (parametarized queries, input validation, stored procedures)
- Privilage escalation (PoLP - principle of least privilage)
- Unauthorized data access (MFA - multi-factor auth, SSO - single sign-on, RBAC - role based access)

### Additional Layers of Security
1. Regular Backups stored offsite and encrypted.
2. Continuous Monitoring and Logging detect unusual or unauthorized database activities.
3. Firewalls restrict access to trusted IP addresses.





