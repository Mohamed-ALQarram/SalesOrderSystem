#🛒 Sales Order Management System

A multi-tier layered web application built with ASP.NET Core MVC 8 that helps manage customers, stock items, and sales orders. The system supports authentication, role-based authorization, dashboards, and CRUD operations for efficient business management.

#🚀 Features

Authentication & Authorization

User login & registration with ASP.NET Identity

Roles: Admin, Cashier, User

Admin Dashboard

View total counts: Customers, Stock Items, Orders, Transactions

Alerts for low stock items

List of recent orders

Customer Management

Create, Read, Update, Delete (CRUD) customers

Stock Management

Manage stock items and products

Monitor stock levels and set critical thresholds

Order Management

Create and manage orders

Order items linked with stock and customers

#🏗️ Project Architecture

This application follows an N-Tier Layered Architecture:

Model Layer

Customer, Order, OrderItem, Stock, StockItem, Product, Payment, Transaction

Core Layer

Repository interfaces and contracts

Data Access Layer (DAL)

Entity Framework (EF Core) implementation of repositories

Business Logic Layer (BLL)

Application services for handling core business logic

UI Layer (ASP.NET MVC 8)

Views, Controllers, and Identity integration

#🛠️ Tech Stack

Backend: ASP.NET Core MVC 8, Entity Framework Core

Authentication: ASP.NET Identity (NuGet package)

Database: SQL Server

Architecture: N-Tier (Models, Core, DAL, BLL, UI)

#📊 Dashboard Preview (Admin)

Total Customers

Total Stock Items

Total Orders

Total Transactions

Low Stock Alerts

Recent Orders

(Add a screenshot here when you push the repo — it makes it look much more professional!)

#🔑 Roles

Admin: Full access (manage users, stock, orders, dashboard)

Cashier: Manage orders and transactions

User: Limited access (basic system usage)
