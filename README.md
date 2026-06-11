# 💰 SmartExpenseTracker

A secure, full-stack personal finance management system built with ASP.NET Core MVC, Entity Framework Core, and MySQL. SmartExpenseTracker enables users to efficiently manage income, expenses, and real-time financial balance with authentication, authorization, and structured reporting.

---

## 🚀 Features

### 🔐 Authentication & Authorization
- User Registration
- Secure Login & Logout
- Session-based authentication
- Protected routes (Income, Expense, Dashboard)
- Password hashing (PasswordHasher / BCrypt support)

---

### 💵 Income Management
- Add Income
- Edit Income
- Delete Income
- View Income List
- Category-based income tracking

---

### 💸 Expense Management
- Add Expense
- Edit Expense
- Delete Expense
- View Expense List
- Category-based expense tracking

---

### 📊 Dashboard
- Total Income calculation
- Total Expense calculation
- Current Balance display

Balance Formula:
Balance = Total Income - Total Expense

---

### 📅 Reports & Filtering
- Monthly reports
- Daily / weekly / yearly filtering
- Custom date range filtering
- Summary reports (Income, Expense, Balance)

---

### 🔎 Search System
- Search by Category
- Search by Description
- Search by Date

---

### ⚙️ Validation Rules
- Amount must be greater than 0
- Required fields: Amount, Category, Date
- Input validation on all forms

---

## 🧱 System Architecture

User
│
├── Income
└── Expense

One user can have many income and expense records.

---

## 🗄️ Database Design

### Users Table
- UserId (PK)
- FullName
- Email (Unique)
- UserName (Unique)
- Password (Hashed)

### Income Table
- IncomeId (PK)
- Amount
- Category
- Description
- Date
- UserId (FK)

### Expense Table
- ExpenseId (PK)
- Amount
- Category
- Description
- Date
- UserId (FK)

---

## 🏗️ Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- MySQL (Pomelo Provider)
- HTML5, CSS3, Bootstrap
- C#

---

## 📦 Project Setup

- Create project: SmartExpenseTracker
- Install packages:
  - Pomelo.EntityFrameworkCore.MySql
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Tools
- Create folders:
  - Models
  - Data
  - Controllers
  - Views
- Configure ApplicationDbContext
- Run migrations:
  - Add-Migration InitialCreate
  - Update-Database

---

## 🧠 Core Models

User:
- UserId
- FullName
- Email
- UserName
- Password

Income:
- IncomeId
- Amount
- Category
- Description
- Date
- UserId

Expense:
- ExpenseId
- Amount
- Category
- Description
- Date
- UserId

---

## 🔐 Security

- Password hashing (never store plain text passwords)
- Session-based authentication
- Authorization for all financial modules
- Input validation and safe queries via EF Core

---

## 🎨 UI Design

- Bootstrap responsive layout
- Dashboard cards
- Tables for data listing
- Alerts and notifications
- Clean navigation system

---

## 📊 Categories

Income:
- Salary
- Business
- Freelance
- Investment
- Other

Expense:
- Food
- Transport
- Shopping
- Bills
- Education
- Entertainment
- Health
- Other

---

## 📈 Example

Total Income = 5000  
Total Expense = 3200  
Balance = 1800  

---

## 🚀 Future Improvements

- Charts & analytics dashboard
- PDF/Excel export
- API version (REST)
- Role-based admin panel
- Dark mode UI

---

## 👨‍💻 Author

Muhammad Hammad

GitHub: https://github.com/HAM-MAD-7/-SmartExpenseTracker.git
