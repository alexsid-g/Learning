# Serialization & Deserialization
Serialization is a process of converting data to format that can be easyly stored or transmitted.
## Purpose
1. Data storage.
2. Data transmittion.
3. Persistance.
4. Interoperability.
## Formats
1. Binary
2. XML
3. Json

## Deserialization 
It is a reverse process to serialization.

## Performance
- CPU usage
- Memory usage
- I/O operations

Data format:
- Binary (fast but not readable)
- Xml (slow and readable)
- Json (balancing performance and readability)

Serialization permormance is affecting by:
- Data format
- Object complexity
- Data size
- Serialization settings (ignoring - usually increase performance)
- Network latency

## Optimization
- Choose right serialization technics
- Simplify data structures
- Use efficient libruaries
- Minimize serialization scope (serialize what is necessary)

## Security Best Practices

Risks:
- Deserialization attacks
- Data tampering
- Expose a sensitive information

Managing risks:
- Validate and sanitize input
- Use secure serialization libraries
- Avoid deserializing untrusted data
- Implement access control
- Encrypt sensitive data
- Use data integrity check

