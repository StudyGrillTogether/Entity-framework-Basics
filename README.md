# Entity framework

# 📘 Day 1 – EF Core Fundamentals & Setup

## 📖 Theory (To Learn)

### 🔹 What is ORM
### 🔹 What is Entity Framework Core
### 🔹 EF Core vs raw SQL (when to use)
### 🔹 EF Approaches:
- Code First (focus)
- Database First (concept only)
- Model First (why not used now)
### 🔹 What is DbContext
### 🔹 What is DbSet<T>
### 🔹 DbContext lifecycle (short-lived concept)

---

## 🛠️ Practice Problems

- Create a new ASP.NET Core project  
- Install EF Core packages  
- Create a simple DbContext  
- Add 1 entity (e.g., Student)  
- Configure connection string  
- Register DbContext using AddDbContext  

---

## 📦 GitHub Exercise

Create a project:  
`StudentManagementEF`

Add:
- Student model  
- AppDbContext  
- Push initial setup with working DB connection  


# 📘 Day 2 – Entity Modeling + Migrations

## 📖 Theory (To Learn)

### 🔹 Entity modeling basics
### 🔹 Primary keys
### 🔹 Required vs optional fields
### 🔹 Data Annotations:
- [Key]
- [Required]
- [MaxLength]
### 🔹 Conventions vs Configuration (basic idea)
### 🔹 What are Migrations
### 🔹 Why migrations are needed

---

## 🛠️ Practice Problems

- Expand Student model:
  - Name, Age, Email  
- Add validations using Data Annotations  
- Create first migration  
- Update database  
- Modify model → create another migration  

---

## 📦 GitHub Exercise

Update repo:
- Add proper Student model with annotations  
- Add migrations folder  
- Commit migration history  

---

## ❌ What NOT to Learn

- No Fluent API deep dive  
- No relationships yet  
- No advanced schema customization  
