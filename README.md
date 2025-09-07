# 🛒 Sales Order Management System  

![.NET](https://img.shields.io/badge/.NET-8-blue)  
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET-Core%20MVC-purple)  
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green)  
![License](https://img.shields.io/badge/License-MIT-yellow)  

A **multi-tier ASP.NET Core MVC 8 web application** for managing **customers, sales orders, and inventory**.  
Includes **role-based authentication**, **dashboard with statistics**, **low-stock alerts**, and full **CRUD operations**.  

---

## 🚀 Features  

- 🔑 **Authentication & Authorization**  
  - Login & registration with ASP.NET Identity  
  - Roles: `Admin`, `Cashier`, `User`  

- 📊 **Admin Dashboard**  
  - Total Customers, Stock Items, Orders, Transactions  
  - Low stock item alerts  
  - Recent orders  

- 👥 **Customer Management** → Full CRUD operations  
- 📦 **Stock Management** → Monitor inventory and set thresholds  
- 📝 **Order Management** → Manage orders & order items  

---

## 🏗️ Project Architecture  

This project follows **N-Tier Layered Architecture**:  

- **Model Layer** → `Customer`, `Order`, `OrderItem`, `Stock`, `StockItem`, `Product`, `Payment`, `Transaction`  
- **Core Layer** → Repository interfaces/contracts  
- **Data Access Layer (DAL)** → EF Core implementations of repositories  
- **Business Logic Layer (BLL)** → Business services  
- **UI Layer** → ASP.NET Core MVC 8 (Views, Controllers, Identity)  

---

## 🛠️ Tech Stack  

- **Backend:** ASP.NET Core MVC 8  
- **Database:** SQL Server + EF Core  
- **Authentication:** ASP.NET Identity  
- **Architecture:** N-Tier layered  

---

## 📊 Dashboard Preview (Admin)  

| Statistic       | Description                       |
|-----------------|-----------------------------------|
| 👤 Customers    | Total number of registered users  |
| 📦 Stock Items  | Available products in inventory   |
| 🛒 Orders       | Recent sales orders               |
| 💳 Transactions | Completed payments & records      |
| ⚠️ Alerts       | Low-stock warnings                |

*(Add screenshot here: `![Dashboard Screenshot](assets/dashboard.png)`)*  

---

## 🔑 Roles  

| Role    | Permissions                  |
|---------|------------------------------|
| Admin   | Full control over the system |
| Cashier | Manage sales & transactions  |
| User    | Limited access               |

---

## 📂 Folder Structure  

```bash
SalesOrderSystem/
│── SalesOrderSystem.Models/        # Entities
│── SalesOrderSystem.Core/          # Repository Interfaces
│── SalesOrderSystem.DAL/           # EF Core Implementations
│── SalesOrderSystem.BLL/           # Business Logic Layer
│── SalesOrderSystemWebUI/          # ASP.NET Core MVC (UI Layer)
│── README.md
