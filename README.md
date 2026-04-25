# Secure Login & Logging System (C# Console App)

## Overview

This is a console-based mini project built in C# that demonstrates secure user authentication using password hashing, role-based access control, and file-based logging.

---

## Features

* User registration with hashed passwords (SHA256)
* Secure login validation
* Role-based access (Admin/User)
* Error handling using try-catch
* Activity logging to file (`log.txt`)

---

## Technologies Used

* C#
* .NET Console Application
* System.Security.Cryptography (SHA256)
* File handling (System.IO)

---

## How It Works

1. User registers with username, password, and role
2. Password is hashed before being stored
3. During login, the entered password is hashed and compared with the stored hash
4. Access is granted based on the user’s role
5. All activities are recorded in `log.txt`

---

## How to Run

1. Clone the repository
2. Open the project in VS Code or Visual Studio
3. Run the application using:

```
dotnet run
```

---

## Log File

* Logs are stored in:

```
bin/Debug/netX.X/log.txt
```

* The file contains timestamps of user actions and error messages

---

## Purpose

This project demonstrates the implementation of:

* Authentication and basic security practices
* File-based logging
* Exception handling
* Modular and readable code structure

---

## Future Improvements

* Add password salting for stronger security
* Store user data in a database
* Build a graphical interface (ASP.NET or WinForms)
* Integrate a structured logging framework
