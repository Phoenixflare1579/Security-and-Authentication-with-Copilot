# Security-and-Authentication-with-Copilot
This is a repository for assignments regarding the Security and Authentication portion of the Microsoft .Net course.
Summary
Vulnerabilities Identified
SQL injection caused by SQL string concatenation.
XSS vulnerabilities caused by rendering user input without encoding.
Missing server-side input validation.
Potential credential exposure through weak password handling.
Insufficient access control checks on protected features.
Fixes Applied
Replaced dynamic SQL with parameterized queries.
Added strict username and email validation.
Added HTML encoding before displaying user-generated content.
Implemented BCrypt password hashing and verification.
Enforced role-based authorization for protected routes.
How Copilot Assisted
Identified insecure coding patterns.
Generated secure parameterized database access code.
Suggested input validation and output-encoding implementations.
Generated authentication and RBAC components.
Created NUnit security tests for SQL injection, XSS, authentication, and authorization scenarios.
Helped verify that security controls function correctly after remediation.
