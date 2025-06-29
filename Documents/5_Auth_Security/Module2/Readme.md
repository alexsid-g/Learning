# Intro to RBAC (Role Based Access Control)
RBAC - is a security system to manage access to resources based on role of the user within organization. Key concepts;
1. Roles (Admin, Manager, Customer, etc)
2. JWT - tokens
3. Claims-based access control VS RBAC
4. RoleManager (creates and manages roles)

Design RBAC:
1. Identiffy role and its responcibilities
2. Assign permissions
3. Summarize permissions in table

## JWT Introduction
1. Structure
    - Header (algorithm, )
    - Payload (name, role, expiration time)
    - Signature
2. AuthN and AuthZ
3. Signing and verefying
4. JWT workflow
    - User authN and token generation
    - Token transmition
    - Request verification 

## Creating
var key = new SymmetricSecurityKey(...);
var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
var token = new JwtSecurityToken(
    issuer: "OAuthServer",
    audience: client_id,
    claims: new() { 
        new Claim("sub", "12345"), 
        new Claim("name", "John Doe") 
    },
    expires: DateTime.Now.AddMinutes(30),
    signingCredentials: creds
);

## Implement JWT AuthN in Asp.Net Core
1. JWT auth flow
    - Login
    - Token creation
    - API calls with token
    - Token validation
2. JWT middleware
    - Bearer schema
3. Securing API routes

## Securing Endpoints with JWT Token
1. JWT Validation
    - Signature check
    - Expiration check
2. JWT middleware
3. Role-based access
.AddAuthorizationBuilder().AddPolicy()

## Best Practisies
1. Shorten exp time to lower risk of token compromising
2. Caching of tokens to speedup access to tokens
3. Minimizaton of token size to speedup check logic
