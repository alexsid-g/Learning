# Introduction

### Module 1: Securing APIs With ASP.NET Identity
- Describe the features and functionalities of ASP.NET Identity
- Explain the process of user registration and authentication in ASP.NET Identity
- Describe how to manage user roles and claims in ASP.NET Identity
- Explain the concept and implementation of token-based authentication
- Describe how to integrate ASP.NET Identity with external authentication providers

### Module 2: Role-Based Access Control and JWT Authentication
- Define role-based access control and its importance
- Explain the structure and use of JSON Web Tokens (JWT)
- Describe the steps to implement JWT authentication in ASP.NET Core
- Explain how to secure API endpoints using JWT
- Identify best practices for implementing JWT authentication

### Module 3: Data Protection
- Describe the basic principles of data protection
- Explain the processes of encryption and decryption
- Describe the techniques of data masking and obfuscation
- Explain best practices for secure data storage
- Describe methods for protecting data in transit

### Module 4: Using Microsoft Copilot for Implementing Security Features

- Use Microsoft Copilot to write secure code
- Utilize Microsoft Copilot to implement authentication and authorization
- Use Microsoft Copilot to debug and resolve security issues

Project: Using Microsoft Copilot for Implementing Security Features

For this project, you will leverage Microsoft Copilot to implement essential security features, applying your skills in writing secure code, integrating authentication and authorization, and debugging security vulnerabilities. You’ll design a secure application highlighting Copilot’s capabilities to enhance code security and streamline development.

## ASP.NET Identify
it is a membership system with Authentication and Authorization.
1. User authentication (AuthN, a12n) - verifies who the user is
2. User authorization (AuthZm a11n) - what can do once AuthN passed
3. User roles - groups of permissions assigned to users
4. Authentification support
    - Multi-factor AuthN (MFA)
    - Password recovery
    - Confirmation email
5. Modular integration
6. Data storage (EF)

### Key Components
1. UserManager - component in asp.net Identity to manage users.
2. SignInManager - component to manage sign-ins, sign-outs, AuthN.
3. RoleManager - component helps to define what different users can do.
4. IdentityDbContext - manages secure storage of information

### Registration and AuntN in ASP.NET Identity
1. Form submission
2. Password hashing
3. Email confirmation
4. Data storage

### Key AuthN steps
1. Credential submission
2. Password verification
3. Session creation (session - state that maintains logged in user)
4. "Remember me" option (cookie)

## User Roles and Claims
RBAC is a mechanizm to restrict system access based on user role within organization.
RBAC:
- RoleManager (Admin, Editor, User)
- Database storage

### Adding Role Management
1. Adding Role Management
    - Ensure ASP.Identity package is added
    - Register RoleManager<IdentityRole> service 
        (.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<DbContext>())
2. Create new role
    - RoleManager<IdentityRole> roleManager; 
    - roleManager.CreateAsync(new IdentityRole("Admin"));
3. Assign role to user
    - UserManager<IdentityUser> userManager;
    - user = _userManager.FindByEmailAsync("email@m.com");
    - userManager.AddToRoleAsync(user, ROLE);
4. Verify role assignment
    - userManager.IsInRoleAsync(user, "Admin")
5. Secure access
    - Use [Authorize(Roles = "Admin")] / FluentApi: RequireAuthorization()
    - Test access with differnt users to verify access rights

### Clamis-based authorization
Claims are name-value pairs that represent attribute of user or entity
CB auth is security model where access determined by associated Claims
1. Assign Claims (check existing Claims before)
    - await userManager.GetClaimsAsync(user)
    - userManager.AddClaimAsync(user, new Claim("Department", "HR"));
2. Storing Claims (in AspNetUserClaims table)
3. Controlling Claims (Authorization policies - rules who can access system and how)

### Comparing Roles and Claims
Roles: Predefined and static; ideal for broad access definitions.
Claims: Dynamic and user-specific, offering more granular and adaptable access management.
NOTE: Default redirect is "/account/login"
