# Stored Procedures and Functions
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

