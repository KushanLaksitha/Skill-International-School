Here is a **clean, professional, and suitable `README.md`** for your project, written clearly for **students, instructors, and GitHub viewers**.
It matches your use of **Microsoft SQL Server Management Studio 2022** and **Visual Studio 2026**.

---

````md
# Student Management System

A Windows-based **Student Management System** developed using **C# (WinForms)** and **Microsoft SQL Server**, designed to manage student records efficiently with full **CRUD operations** and validation.

---

## 📌 Features

- Add new student records
- Update existing student details
- Delete student records with confirmation
- Search students by First Name
- View all students in a DataGridView
- Input validation (required fields & gender selection)
- Secure database operations using parameterized queries

---

## 🛠 Technologies Used

- **Programming Language:** C#
- **Framework:** .NET (WinForms)
- **IDE:** Visual Studio 2026
- **Database:** Microsoft SQL Server
- **Database Tool:** SQL Server Management Studio (SSMS) 2022

---

## 🗄 Database Structure

**Database Name:** `Skill_international_db`

**Table:** `students`

| Column Name     | Data Type        |
|-----------------|------------------|
| RegNo           | INT (Primary Key, Identity) |
| fName           | VARCHAR(50)      |
| lName           | VARCHAR(50)      |
| dateOfBirth     | DATE             |
| gender          | VARCHAR(20)      |
| address         | VARCHAR(250)     |
| email           | VARCHAR(200)     |
| mobilePhone     | VARCHAR(20)      |
| homePhone       | VARCHAR(20)      |
| parentName      | VARCHAR(200)     |
| NIC             | VARCHAR(20)      |
| contactNo       | VARCHAR(20)      |

---

## ⚙ Setup Instructions

### 1️⃣ Database Setup
1. Open **SQL Server Management Studio 2022**
2. Execute the provided SQL script to create:
   - Database: `Skill_international_db`
   - Table: `students`

### 2️⃣ Application Setup
1. Open the project in **Visual Studio 2026**
2. Update the SQL connection string in the code:
   ```csharp
   SqlConnection con = new SqlConnection("your_connection_string_here");
````

3. Build and run the application

---

## 🖱 How to Use

* **Add**: Fill all required fields and click **Add**
* **Update**: Select a record from the table, edit fields, click **Update**
* **Delete**: Select a record and click **Delete**
* **Search**: Enter First Name and click **Search**
* **View**: All records are displayed in the DataGridView

---

## 🔐 Validation Rules

* All required fields must be filled
* Gender selection (Male/Female) is mandatory
* Confirmation required before Update and Delete
* Uses parameterized queries to prevent SQL Injection

---

## 📄 License

This project is developed for **educational purposes**.

---

## 👤 Author

Developed by **Kushan Kumarasiri**
Student Management System – C# & SQL Server

```

